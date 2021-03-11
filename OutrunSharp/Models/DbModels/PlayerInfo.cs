using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutrunSharp.Models.DbModels
{
    public class PlayerInfo
    {
        public uint Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; } // internal password stored with the ID in the save file
        public string Migrate_password { get; set; } // Transfer ID
        public string User_password { get; set; } // hashed transfer password
        public string Player_key { get; set; } // returned as part of the pre-login phase, combined with password to create special auth string
        public ulong Last_login { get; set; } // unix timestamp indicating the time of the last successful login
        public Language Language { get; set; } // value indicating the current language of the user
        public Character[] Characters { get; set; } // json containing all character data for player
        public Chao[] Chao { get; set; } // json containing all chao data for player
        public ulong Suspended_until { get; set; }
        public int Suspend_reason { get; set; }
        public string Last_login_device { get; set; }
        public Platform Last_login_platform { get; set; }
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
