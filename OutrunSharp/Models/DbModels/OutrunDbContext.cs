using MySql.Data.MySqlClient;
using OutrunSharp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public PlayerInfo GetPlayerInfo(string id)
        {
            PlayerInfo info = new();

            bool onFirstEntry = true;

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM player_info WHERE id == "+id, conn);

                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        throw new NoSuchPlayerException("Player ID " + id + " does not exist in the database.");
                    }
                    while (reader.Read())
                    {
                        if (!onFirstEntry)
                        {
                            throw new PlayerIDConflictException("Player ID " +id + " has multiple entries in the database. This may indicate a conflict.");
                        } else
                        {
                            info.Id = Convert.ToUInt32(reader["id"]);
                            info.Username = reader["username"].ToString();
                            info.Password = reader["password"].ToString();
                            info.Migrate_password = reader["migrate_password"].ToString();
                            info.User_password = reader["user_password"].ToString();
                            info.Player_key = reader["player_key"].ToString();
                            onFirstEntry = false;
                        }
                    }
                }
            }
            return info;
        }
    }
}
