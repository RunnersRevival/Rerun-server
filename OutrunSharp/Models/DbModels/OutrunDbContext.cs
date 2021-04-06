using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Org.BouncyCastle.Bcpg.Sig;
using OutrunSharp.Exceptions;
using OutrunSharp.Helpers;
using OutrunSharp.Models.Obj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OutrunSharp.Models.DbModels
{
    public class OutrunDbContext
    {
        public string ConnectionString { get; set; }

        public OutrunDbContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        const string validRandChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

        static string GetRandomString(int length)
        {
            string s = "";
            using (RNGCryptoServiceProvider provider = new())
            {
                while (s.Length != length)
                {
                    byte[] oneByte = new byte[1];
                    provider.GetBytes(oneByte);
                    char character = (char)oneByte[0];
                    if (validRandChars.Contains(character))
                    {
                        s += character;
                    }
                }
            }
            return s;
        }

        public PlayerInfo GetPlayerInfo(string id)
        {
            PlayerInfo info = new();

            bool onFirstEntry = true;

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new("SELECT * FROM player_info WHERE id = " + id, conn);

                using var reader = cmd.ExecuteReader();
                if (!reader.HasRows)
                {
                    throw new NoSuchPlayerException("Player ID " + id + " does not exist in the database.");
                }
                while (reader.Read())
                {
                    if (!onFirstEntry)
                    {
                        throw new PlayerIDConflictException("Player ID " + id + " has multiple entries in the database. This may indicate a conflict.");
                    }
                    else
                    {
                        info.Id = Convert.ToUInt64(reader["id"]);
                        info.Username = reader["username"].ToString();
                        info.Password = reader["password"].ToString();
                        info.MigratePassword = reader["migrate_password"].ToString();
                        info.UserPassword = reader["user_password"].ToString();
                        info.PlayerKey = reader["player_key"].ToString();
                        info.LastLogin = Convert.ToInt64(reader["last_login"]);
                        info.Language = (Language)Convert.ToInt32(reader["language"]);
                        info.Characters = JsonConvert.DeserializeObject<List<Character>>(reader["characters"].ToString());
                        info.Chao = JsonConvert.DeserializeObject<List<Chao>>(reader["chao"].ToString());
                        info.SuspendedUntil = Convert.ToInt64(reader["suspended_until"]);
                        info.SuspendReason = Convert.ToInt32(reader["suspend_reason"]);
                        info.LastLoginDevice = reader["last_login_device"].ToString();
                        info.LastLoginPlatform = (Platform)Convert.ToInt32(reader["last_login_platform"]);

                        onFirstEntry = false;
                    }
                }
            }
            return info;
        }

        public string GetPlayerKey(string id)
        {
            string key = string.Empty;

            bool onFirstEntry = true;

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new("SELECT player_key FROM player_info WHERE id = " + id, conn);

                using var reader = cmd.ExecuteReader();
                if (!reader.HasRows)
                {
                    throw new NoSuchPlayerException("Player ID " + id + " does not exist in the database.");
                }
                while (reader.Read())
                {
                    if (!onFirstEntry)
                    {
                        throw new PlayerIDConflictException("Player ID " + id + " has multiple entries in the database. This may indicate a conflict.");
                    }
                    else
                    {
                        key = reader["player_key"].ToString();
                        onFirstEntry = false;
                    }
                }
            }
            if(key.Length != 16)
            {
                UpdatePlayerInfo(id, "player_key", GetRandomString(16));
            }
            return key;
        }

        public bool ValidatePassword(string id, string pass)
        {
            string key = string.Empty;
            string password = string.Empty;
            string gameId = "dho5v5yy7n2uswa5iblb";

            bool onFirstEntry = true;

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new("SELECT password, player_key FROM player_info WHERE id = " + id, conn);

                using var reader = cmd.ExecuteReader();
                if (!reader.HasRows)
                {
                    throw new NoSuchPlayerException("Player ID " + id + " does not exist in the database.");
                }
                while (reader.Read())
                {
                    if (!onFirstEntry)
                    {
                        throw new PlayerIDConflictException("Player ID " + id + " has multiple entries in the database. This may indicate a conflict.");
                    }
                    else
                    {
                        password = reader["password"].ToString();
                        key = reader["player_key"].ToString();
                        onFirstEntry = false;
                    }
                }
            }
            return (pass == Cryptor.CalcMD5String(key + ":" + gameId + ":" + id + ":" + password));
        }

        public int UpdatePlayerInfo(string id, string column, string value)
        {
            using var conn = GetConnection();
            conn.Open();

            var sql = "UPDATE player_info SET " + column + " = '" + value + "' WHERE id = @id";

            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();

            int rowsUpdated = cmd.ExecuteNonQuery();
            return rowsUpdated;
        }

        public string CreateSessionID(ulong uid)
        {
            string sessionId = "REVIVAL_" + GetRandomString(40);
            long nowUnix = DateTimeOffset.Now.ToUnixTimeSeconds();

            using var conn = GetConnection();
            conn.Open();

            var sql = "INSERT INTO session_ids(sid, uid, assigned_at_time) VALUES(@sid, @uid, @now)";

            using MySqlCommand cmd = new(sql, conn);
            cmd.Parameters.AddWithValue("@sid", sessionId);
            cmd.Parameters.AddWithValue("@uid", uid);
            cmd.Parameters.AddWithValue("@now", nowUnix);
            cmd.Prepare();

            cmd.ExecuteNonQuery();

            return sessionId;
        }

        public bool InvalidateSessionID(string sessionId) // returns true if there was a session with that ID, false otherwise
        {
            using MySqlConnection conn = GetConnection();
            conn.Open();

            string sql = "DELETE FROM session_ids WHERE sid = @target";

            using MySqlCommand cmd = new(sql, conn);
            cmd.Parameters.AddWithValue("@target", sessionId);
            cmd.Prepare();

            int rows = cmd.ExecuteNonQuery();

            return !(rows == 0);
        }

        public string CheckSessionID(string sessionId) // returns user ID if session is valid; empty otherwise
        {
            using var conn = GetConnection();
            conn.Open();

            var sql = "SELECT uid, assigned_at_time FROM session_ids WHERE sid = @sid";

            using MySqlCommand cmd = new(sql, conn);
            cmd.Parameters.AddWithValue("@sid", sessionId);
            cmd.Prepare();

            using MySqlDataReader reader = cmd.ExecuteReader();
            if (!reader.Read())
            {
                // no such session exists
                return string.Empty;
            }
            long expirationTime = Convert.ToInt64(reader["assigned_at_time"]) + 3600;
            if (DateTimeOffset.Now.ToUnixTimeSeconds() <= expirationTime)
            {
                return reader["uid"].ToString();
            } else
            {
                InvalidateSessionID(sessionId);
                return string.Empty;
            }
        }

        public void InvalidateAllExpiredSessionIDs()
        {
            using MySqlConnection conn = GetConnection();
            conn.Open();
            MySqlCommand cmd = new("SELECT sid, assigned_at_time FROM session_ids", conn);
            long expirationTime;
            long now = DateTimeOffset.Now.ToUnixTimeSeconds();
            using MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                expirationTime = Convert.ToInt64(reader["assigned_at_time"]) + 3600;
                if (now > expirationTime)
                {
                    InvalidateSessionID(reader["sid"].ToString());
                }
            }
        }
        public async Task InvalidateAllExpiredSessionIDsAsync()
        {
            using MySqlConnection conn = GetConnection();
            conn.Open();
            MySqlCommand cmd = new("SELECT sid, assigned_at_time FROM session_ids", conn);
            long expirationTime;
            long now = DateTimeOffset.Now.ToUnixTimeSeconds();
            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                expirationTime = Convert.ToInt64(reader["assigned_at_time"]) + 3600;
                if (now > expirationTime)
                {
                    InvalidateSessionID(reader["sid"].ToString());
                }
            }
        }
    }
}
