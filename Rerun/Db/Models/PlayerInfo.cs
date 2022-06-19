using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Rerun.Models.Obj;

namespace Rerun.Db.Models
{
    public class PlayerInfo
    {
        [Column("id")]
        public ulong Id { get; set; }
        
        [Column("username")]
        [MaxLength(12)]
        public string Username { get; set; }
        
        [Column("password")]
        [MaxLength(10)]
        public string Password { get; set; } // internal password stored with the ID in the save file
        
        [Column("migrate_password")]
        [MaxLength(12)]
        public string MigratePassword { get; set; } // Transfer ID
        
        [Column("user_password")]
        public string UserPassword { get; set; } // hashed transfer password
        
        [Column("player_key")]
        [MaxLength(32)]
        public string PlayerKey { get; set; } // returned as part of the pre-login phase, combined with password to create special auth string
        
        [Column("last_login")]
        public long LastLogin { get; set; } // unix timestamp indicating the time of the last successful login
        
        [Column("language")]
        public Language Language { get; set; } // value indicating the current language of the user
        
        [Column("characters")]
        public List<Character> Characters { get; set; } // json containing all character data for player
        
        [Column("chao")]
        public List<Chao> Chao { get; set; } // json containing all chao data for player
        
        [Column("suspended_until")]
        public long SuspendedUntil { get; set; }
        
        [Column("suspend_reason")]
        public int SuspendReason { get; set; }
        
        [Column("last_login_device")]
        public string LastLoginDevice { get; set; }
        
        [Column("last_login_platform")]
        public Platform LastLoginPlatform { get; set; }
    }

    public enum Language
    {
        LangJapanese,
        LangEnglish,
        LangChineseZHJ,
        LangChineseZH,
        LangKorean,
        LangFrench,
        LangGerman,
        LangSpanish,
        LangPortuguese,
        LangItalian,
        LangRussian
    }
    public enum Platform
    {
        PlatformNone,
        PlatformIphone,
        PlatformAndroid
    }
}
