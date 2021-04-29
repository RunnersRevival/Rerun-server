using OutrunSharp.Models.DbModels;
using OutrunSharp.Models.Obj;
using System;
using System.Collections.Generic;

// ReSharper disable InconsistentNaming
#pragma warning disable IDE1006 // Naming Styles

namespace OutrunSharp.Models.ResponseModels.Player
{
    public class PlayerStateResponse : BaseResponse
    {
        public PlayerStateResponse() : base()
        {
            playerState = new PlayerStateModel();
        }
        public PlayerStateResponse(string errMsg, int status) : base(errMsg, status)
        {
            playerState = new PlayerStateModel();
        }

        public PlayerStateModel playerState { get; set; }
    }

    public class PlayerStateModel
    {
        public PlayerStateModel()
        {
            DateTimeOffset endOfDay = new DateTime(
                DateTime.Now.Year,
                DateTime.Now.Month,
                DateTime.Now.Day,
                23, 59, 59, 999);
            var endOfDayUnix = endOfDay.ToUnixTimeSeconds();
            Random random = new();
            items = new List<Item>()
            {
                new(((int)ItemIDs.ItemIDInvincible).ToString(), 0),
                new(((int)ItemIDs.ItemIDBarrier).ToString(), 0),
                new(((int)ItemIDs.ItemIDMagnet).ToString(), 0),
                new(((int)ItemIDs.ItemIDTrampoline).ToString(), 0),
                new(((int)ItemIDs.ItemIDCombo).ToString(), 0),
                new(((int)ItemIDs.ItemIDLaser).ToString(), 0),
                new(((int)ItemIDs.ItemIDDrill).ToString(), 0),
                new(((int)ItemIDs.ItemIDAsteroid).ToString(), 0),
                new(((int)ItemIDs.ItemIDRingBonus).ToString(), 0),
                new(((int)ItemIDs.ItemIDDistanceBonus).ToString(), 0),
                new(((int)ItemIDs.ItemIDAnimalBonus).ToString(), 0)
            };
            equipItemList = new[] { "-1", "-1", "-1" };
            mainCharaID = ((int)CharaIDs.Sonic).ToString();
            subCharaID = "-1";
            mainChaoID = "-1";
            subChaoID = "-1";
            numRings = "50000";
            numBuyRings = "0";
            numRedRings = "50";
            numBuyRedRings = "0";
            energy = "10";
            energyBuy = "0";
            energyRenewsAt = DateTimeOffset.Now.AddMinutes(10).ToUnixTimeSeconds();
            mumMessages = 0;
            rankingLeague = ((int)RankingLeague.RankingLeagueF_M).ToString();
            quickRankingLeague = ((int)RankingLeague.RankingLeagueF_M).ToString();
            numRouletteTicket = "0";
            chaoEggs = 0;
            totalHighScore = "0";
            quickTotalHighScore = "0";
            totalDistance = "0";
            maximumDistance = "0";
            dailyMissionId = random.Next(1, 198).ToString();
            dailyMissionEndTime = endOfDayUnix;
            dailyChallengeValue = 0;
            dailyChallengeComplete = 0;
            numDailyChalCont = 0;
            numPlaying = "0";
            animals = "0";
            rank = "0";
        }

        public void GetDataFromDatabase(PlayerState playerState)
        {
            items = playerState.Items;
            equipItemList = playerState.EquippedItems.ToArray();
            mainCharaID = playerState.MainCharaID;
            subCharaID = playerState.SubCharaID;
            mainChaoID = playerState.MainChaoID;
            subChaoID = playerState.SubChaoID;
            numRings = playerState.NumRings.ToString();
            numBuyRings = playerState.NumBuyRings.ToString();
            numRedRings = playerState.NumRedRings.ToString();
            numBuyRedRings = playerState.NumBuyRedRings.ToString();
            energy = playerState.Energy.ToString();
            energyBuy = playerState.EnergyBuy.ToString();
            energyRenewsAt = playerState.EnergyRenewsAt;
            mumMessages = playerState.NumMessages;
            rankingLeague = playerState.RankingLeague.ToString();
            quickRankingLeague = playerState.QuickRankingLeague.ToString();
            numRouletteTicket = playerState.NumRouletteTicket.ToString();
            chaoEggs = playerState.ChaoEggs;
            totalHighScore = playerState.HighScore.ToString();
            quickTotalHighScore = playerState.TimedHighScore.ToString();
            totalDistance = playerState.TotalDistance.ToString();
            maximumDistance = playerState.HighDistance.ToString();
            dailyMissionId = playerState.DailyMissionID.ToString();
            dailyMissionEndTime = playerState.DailyMissionEndTime;
            dailyChallengeValue = playerState.DailyChallengeValue;
            dailyChallengeComplete = playerState.DailyChallengeComplete;
            numDailyChalCont = playerState.NumDailyChallenge;
            numPlaying = playerState.NumPlaying.ToString();
            animals = playerState.Animals.ToString();
            rank = playerState.Rank.ToString();
        }

        public List<Item> items { get; set; }
        public string[] equipItemList { get; set; }

        public string mainCharaID { get; set; }
        public string subCharaID { get; set; }

        public string mainChaoID { get; set; }
        public string subChaoID { get; set; }

        public string numRings { get; set; }
        public string numBuyRings { get; set; }

        public string numRedRings { get; set; }
        public string numBuyRedRings { get; set; }

        public string energy { get; set; }
        public string energyBuy { get; set; }
        public long energyRenewsAt { get; set; }

        public int mumMessages { get; set; }

        public string rankingLeague { get; set; }
        public string quickRankingLeague { get; set; }

        public string numRouletteTicket { get; set; }
        public int chaoEggs { get; set; }

        public string totalHighScore { get; set; }
        public string quickTotalHighScore { get; set; }

        public string totalDistance { get; set; }
        public string maximumDistance { get; set; }

        public string dailyMissionId { get; set; }
        public long dailyMissionEndTime { get; set; }
        public int dailyChallengeValue { get; set; }
        public int dailyChallengeComplete { get; set; }
        public int numDailyChalCont { get; set; }

        public string numPlaying { get; set; } // number of games played
        public string animals { get; set; } // total animals acquired
        public string rank { get; set; } // from 0 to 998
    }
}
