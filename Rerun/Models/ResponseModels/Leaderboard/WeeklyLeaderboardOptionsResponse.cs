using System;

namespace Rerun.Models.ResponseModels.Leaderboard
{
    public class WeeklyLeaderboardOptionsResponse : BaseResponse
    {
        public WeeklyLeaderboardOptionsResponse() : base()
        {
            mode = 0;
            type = 0;
            param = 0;
            startTime = ((DateTimeOffset)GetFirstDayOfWeek(DateTime.Now, DayOfWeek.Sunday)).ToUnixTimeSeconds();
            endTime = ((DateTimeOffset)GetFirstDayOfWeek(DateTime.Now.AddDays(7), DayOfWeek.Sunday)).ToUnixTimeSeconds();
        }
        
        public WeeklyLeaderboardOptionsResponse(string errMsg, int status) : base(errMsg, status)
        {
            mode = 0;
            type = 0;
            param = 0;
            startTime = ((DateTimeOffset)GetFirstDayOfWeek(DateTime.Now, DayOfWeek.Sunday)).ToUnixTimeSeconds();
            endTime = ((DateTimeOffset)GetFirstDayOfWeek(DateTime.Now.AddDays(7), DayOfWeek.Sunday)).ToUnixTimeSeconds();
        }
        
        public int mode { get; set; }
        public int type { get; set; }
        public int param { get; set; }
        public long startTime { get; set; }
        public long endTime { get; set; }
    
        private static DateTime GetFirstDayOfWeek(DateTime dayInWeek, DayOfWeek firstDay)
        {
            var firstDayInWeek = dayInWeek.Date;

            while (firstDayInWeek.DayOfWeek != firstDay)
            {
                firstDayInWeek = firstDayInWeek.AddDays(-1);
            }

            return firstDayInWeek;
        }
    }

    public enum RankingMode
    {
        ENDLESS,
        QUICK,
        COUNT
    }

    public enum RankingScoreType
    {
        HIGH_SCORE,
        TOTAL_SCORE,
        NONE
    }
}