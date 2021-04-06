using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#pragma warning disable IDE1006 // Naming Styles

namespace OutrunSharp.Models.RequestModels.Login.Obj
{
    public class LineAuth
    {
        public string userId { get; set; }
        public string password { get; set; } // actually a special auth string combining the player key, game key, and player password
        public string migrationPassword { get; set; } // sent to set the migration password
    }
}
