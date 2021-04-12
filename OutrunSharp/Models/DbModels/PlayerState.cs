using System.Collections.Generic;

namespace OutrunSharp.Models.DbModels
{
    public class PlayerState
    {
        public List<Obj.Item> Items { get; set; }
        public List<string> EquippedItems { get; set; }

        public string MainCharaID { get; set; }
        public string SubCharaID { get; set; }

        public string MainChaoID { get; set; }
        public string SubChaoID { get; set; }

        public long NumRings { get; set; }
        public long NumBuyRings { get; set; }

        public int NumRedRings { get; set; }
        public int NumBuyRedRings { get; set; }

        public int Energy { get; set; }
        public int EnergyBuy { get; set; }
        public long EnergyRenewsAt { get; set; }

        public int NumMessages { get; set; }

        public RankingLeague RankingLeague { get; set; }
        public RankingLeague QuickRankingLeague { get; set; }

        public int NumRouletteTicket { get; set; }
        public int NumChaoRouletteTicket { get; set; }
        public int ChaoEggs { get; set; }

        public long HighScore { get; set; } // this is a long since people are getting billion point scores
        public long TimedHighScore { get; set; } // this is a long since people are getting billion point scores

        public long TotalDistance { get; set; }
        public long HighDistance { get; set; }

        public int DailyMissionID { get; set; }
        public long DailyMissionEndTime { get; set; }
        public int DailyChallengeValue { get; set; }
        public byte DailyChallengeComplete { get; set; }
        public int NumDailyChallenge { get; set; }

        public int NumPlaying { get; set; } // number of games played
        public int Animals { get; set; }
        public ushort Rank { get; set; } // from 0 to 998

        public int DailyChalCatNum { get; set; }
        public int DailyChalSetNum { get; set; }
        public int DailyChalPosNum { get; set; }
        public int NextNumDailyChallenge { get; set; }

        public long LeagueHighScore { get; set; }
        public long QuickLeagueHighScore { get; set; }

        public long LeagueStartTime { get; set; }
        public long LeagueResetTime { get; set; }
        public int RankingLeagueGroup { get; set; }
        public int QuickRankingLeagueGroup { get; set; }

        public long TotalScore { get; set; }
        public long TimedTotalScore { get; set; }
        public long HighTotalScore { get; set; }
        public long TimedHighTotalScore { get; set; }
    }

    public enum RankingLeague
    {
        RankingLeagueNone,
        RankingLeagueF_M,
        RankingLeagueF,
        RankingLeagueF_P,
        RankingLeagueE_M,
        RankingLeagueE,
        RankingLeagueE_P,
        RankingLeagueD_M,
        RankingLeagueD,
        RankingLeagueD_P,
        RankingLeagueC_M,
        RankingLeagueC,
        RankingLeagueC_P,
        RankingLeagueB_M,
        RankingLeagueB,
        RankingLeagueB_P,
        RankingLeagueA_M,
        RankingLeagueA,
        RankingLeagueA_P,
        RankingLeagueS_M,
        RankingLeagueS,
        RankingLeagueS_P
    }
}
