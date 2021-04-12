using OutrunSharp.Models.Obj;
using System;
using System.Collections.Generic;
using System.Globalization;

// ReSharper disable InconsistentNaming
#pragma warning disable IDE1006 // Naming Styles

namespace OutrunSharp.Models.ResponseModels.Game
{
    public class DailyChallengeDataResponse : BaseResponse
    {
        public DailyChallengeDataResponse() : base()
        {
            var defaultCultureInfo = CultureInfo.CurrentCulture;
            var firstDayOfWeek = defaultCultureInfo.DateTimeFormat.FirstDayOfWeek;
            DateTimeOffset beginningOfNextWeek = GetFirstDayOfWeek(DateTime.UtcNow.AddDays(7), firstDayOfWeek);

            incentiveList = new List<Incentive>()
            {
                new(((int)ItemIDs.ItemIDRing).ToString(), 100),
                new(((int)ItemIDs.ItemIDBarrier).ToString(), 5),
                new(((int)ItemIDs.ItemIDMagnet).ToString(), 5),
                new(((int)ItemIDs.ItemIDTrampoline).ToString(), 5),
                new(((int)ItemIDs.ItemIDAsteroid).ToString(), 5),
                new(((int)ItemIDs.ItemIDDrill).ToString(), 5),
                new(((int)ItemIDs.ItemIDRedRing).ToString(), 15),
            };
            incentiveListCont = incentiveList.Count;
            numDilayChalCont = 0;
            numDailyChalDay = 1;
            maxDailyChalDay = 7;
            chalEndTime = beginningOfNextWeek.AddSeconds(-1).ToUnixTimeSeconds();
        }
        public DailyChallengeDataResponse(string errMsg, int status) : base(errMsg, status)
        {
            var defaultCultureInfo = CultureInfo.CurrentCulture;
            var firstDayOfWeek = defaultCultureInfo.DateTimeFormat.FirstDayOfWeek;
            DateTimeOffset beginningOfNextWeek = GetFirstDayOfWeek(DateTime.UtcNow.AddDays(7), firstDayOfWeek);

            incentiveList = new List<Incentive>()
            {
                new(((int)ItemIDs.ItemIDRing).ToString(), 100),
                new(((int)ItemIDs.ItemIDBarrier).ToString(), 5),
                new(((int)ItemIDs.ItemIDMagnet).ToString(), 5),
                new(((int)ItemIDs.ItemIDTrampoline).ToString(), 5),
                new(((int)ItemIDs.ItemIDAsteroid).ToString(), 5),
                new(((int)ItemIDs.ItemIDDrill).ToString(), 5),
                new(((int)ItemIDs.ItemIDRedRing).ToString(), 15),
            };
            incentiveListCont = incentiveList.Count;
            numDilayChalCont = 0;
            numDailyChalDay = 1;
            maxDailyChalDay = 7;
            chalEndTime = beginningOfNextWeek.AddSeconds(-1).ToUnixTimeSeconds();
        }

        public void SetIncentiveList(List<Incentive> incentives)
        {
            if (incentives.Count > 7)
                throw new Exception("incentives must be length 7 or less");
            incentiveList = incentives;
            incentiveListCont = incentiveList.Count;
        }

        private static DateTime GetFirstDayOfWeek(DateTime dayInWeek, DayOfWeek firstDay)
        {
            var firstDayInWeek = dayInWeek.Date;

            while (firstDayInWeek.DayOfWeek != firstDay)
            {
                firstDayInWeek = firstDayInWeek.AddDays(-1);
            }

            return firstDayInWeek;
        }

        public List<Incentive> incentiveList { get; private set; }
        public int incentiveListCont { get; private set; } // should be determined by incentiveList.Count - also why does the game need this when it could in theory just get the length of the list...?

        public int numDilayChalCont { get; set; } // yes this is how it's really spelled out in game
        public int numDailyChalDay { get; set; }
        public int maxDailyChalDay { get; set; }
        public long chalEndTime { get; set; } // unix timestamp
    }
}
