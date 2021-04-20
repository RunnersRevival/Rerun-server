using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// ReSharper disable InconsistentNaming
#pragma warning disable IDE1006 // Naming Styles

namespace OutrunSharp.Models.Obj
{
    public class MileageFriend
    {
        public MileageFriend()
        {
            friendId = "1234567890";
            name = "dummy";
            url = "";
            mapState = new MapState();
        }

        public string friendId { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public MapState mapState { get; set; }
    }
}
