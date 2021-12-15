using OutrunSharp.Models.Obj;
using System.Collections.Generic;

namespace OutrunSharp.Models.DbModels
{
    public class PlayerInfo
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; } // internal password stored with the ID in the save file
        public string MigratePassword { get; set; } // Transfer ID
        public string UserPassword { get; set; } // hashed transfer password
        public string PlayerKey { get; set; } // returned as part of the pre-login phase, combined with password to create special auth string
        public long LastLogin { get; set; } // unix timestamp indicating the time of the last successful login
        public Language Language { get; set; } // value indicating the current language of the user
        public List<Character> Characters { get; set; } // json containing all character data for player
        public List<Chao> Chao { get; set; } // json containing all chao data for player
        public long SuspendedUntil { get; set; }
        public int SuspendReason { get; set; }
        public string LastLoginDevice { get; set; }
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
