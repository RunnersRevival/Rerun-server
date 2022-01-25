using System.Collections.Generic;

namespace Rerun.Models.DbModels
{
    public class PlayerState
    {
        public List<Obj.Item> Items { get; set; }
        public List<string> EquippedItems { get; set; }

        // 
        public string MainCharaID { get; set; }
        public string SubCharaID { get; set; }

        public string MainChaoID { get; set; }
        public string SubChaoID { get; set; }

        // rings
        public long NumRings { get; set; }
        public long NumBuyRings { get; set; } // number of rings purchased using red rings

        // red rings
        public int NumRedRings { get; set; }
        public int NumBuyRedRings { get; set; } // number of red rings purchased using real money; not used by Rerun

        // 
        public int Energy { get; set; }
        public int EnergyBuy { get; set; } // number of revive tokens purchased using red rings
        public long EnergyRenewsAt { get; set; }

        // gift box
        public int NumMessages { get; set; } // number of items in the gift box; investigate if this is used properly in-game

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
        public ushort Rank { get; set; } // from 0 to 998; this is incremented by 1 internally by the game

        // internal use for daily challenge id calculation
        public int DailyChalCatNum { get; set; }
        public int DailyChalSetNum { get; set; }
        public int DailyChalPosNum { get; set; }
        public int NextNumDailyChallenge { get; set; }

        // runners' league high scores
        public long LeagueHighScore { get; set; }
        public long QuickLeagueHighScore { get; set; }

        // runners' league data
        public long LeagueStartTime { get; set; }
        public long LeagueResetTime { get; set; }
        public int RankingLeagueGroup { get; set; }
        public int QuickRankingLeagueGroup { get; set; }

        // total score
        public long TotalScore { get; set; }
        public long TimedTotalScore { get; set; }
        public long HighTotalScore { get; set; }
        public long TimedHighTotalScore { get; set; }

        // event state
        public long EventParam { get; set; }
        public long EventRewardProgress { get; set; }
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
