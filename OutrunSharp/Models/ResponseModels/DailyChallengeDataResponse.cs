using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

#pragma warning disable IDE1006 // Naming Styles

namespace OutrunSharp.Models.ResponseModels
{
    public class DailyChallengeDataResponse : BaseResponse
    {
        public DailyChallengeDataResponse() : base()
        {
            CultureInfo defaultCultureInfo = CultureInfo.CurrentCulture;
            DayOfWeek firstDayOfWeek = defaultCultureInfo.DateTimeFormat.FirstDayOfWeek;
            DateTimeOffset beginningOfNextWeek = GetFirstDayOfWeek(DateTime.UtcNow.AddDays(7), firstDayOfWeek);

            incentiveList = new()
            {
                new Incentive(((int)ItemIDs.ItemIDRing).ToString(), 100),
                new Incentive(((int)ItemIDs.ItemIDBarrier).ToString(), 5),
                new Incentive(((int)ItemIDs.ItemIDMagnet).ToString(), 5),
                new Incentive(((int)ItemIDs.ItemIDTrampoline).ToString(), 5),
                new Incentive(((int)ItemIDs.ItemIDAsteroid).ToString(), 5),
                new Incentive(((int)ItemIDs.ItemIDDrill).ToString(), 5),
                new Incentive(((int)ItemIDs.ItemIDRedRing).ToString(), 15),
            };
            incentiveListCont = incentiveList.Count;
            numDilayChalCont = 0;
            numDailyChalDay = 1;
            maxDailyChalDay = 7;
            chalEndTime = beginningOfNextWeek.AddSeconds(-1).ToUnixTimeSeconds();
        }
        public DailyChallengeDataResponse(string errMsg, int status) : base(errMsg, status)
        {
            CultureInfo defaultCultureInfo = CultureInfo.CurrentCulture;
            DayOfWeek firstDayOfWeek = defaultCultureInfo.DateTimeFormat.FirstDayOfWeek;
            DateTimeOffset beginningOfNextWeek = GetFirstDayOfWeek(DateTime.UtcNow.AddDays(7), firstDayOfWeek);

            incentiveList = new()
            {
                new Incentive(((int)ItemIDs.ItemIDRing).ToString(), 100),
                new Incentive(((int)ItemIDs.ItemIDBarrier).ToString(), 5),
                new Incentive(((int)ItemIDs.ItemIDMagnet).ToString(), 5),
                new Incentive(((int)ItemIDs.ItemIDTrampoline).ToString(), 5),
                new Incentive(((int)ItemIDs.ItemIDAsteroid).ToString(), 5),
                new Incentive(((int)ItemIDs.ItemIDDrill).ToString(), 5),
                new Incentive(((int)ItemIDs.ItemIDRedRing).ToString(), 15),
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
            DateTime firstDayInWeek = dayInWeek.Date;

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
