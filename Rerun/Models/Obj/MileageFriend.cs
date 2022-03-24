
// ReSharper disable InconsistentNaming
#pragma warning disable IDE1006 // Naming Styles

namespace Rerun.Models.Obj
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
        public string url { get; set; } // not sure if this is used anywhere in the game
        public MapState mapState { get; set; }
    }
}
