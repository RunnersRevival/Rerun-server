
// ReSharper disable InconsistentNaming
#pragma warning disable IDE1006 // Naming Styles

namespace Rerun.Models.RequestModels.Leaderboard
{
    public class WeeklyLeaderboardOptionsRequest : BaseRequest
    {
        public string mode { get; set; } // int :: 0 = ENDLESS, 1 = QUICK
        public string first { get; set; } // int
        public string count { get; set; } // int
        public string type { get; set; } // int
        public string[] friendIdList { get; set; }
    }
}