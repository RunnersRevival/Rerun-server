﻿
// ReSharper disable InconsistentNaming
#pragma warning disable IDE1006 // Naming Styles

namespace Rerun.Models.RequestModels.Login.Obj
{
    public class LineAuth
    {
        public string userId { get; set; }
        public string password { get; set; } // actually a special auth hash combining the player key, game key, and player password
        public string migrationPassword { get; set; } // sent to set the migration password
    }
}