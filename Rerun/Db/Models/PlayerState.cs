using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rerun.Db.Models
{
    public class PlayerState
    {
        [Column("id")]
        [Key]
        public ulong Id { get; set; }
        
        [Column("items")]
        public List<Rerun.Models.Obj.Item> Items { get; set; }
        [Column("equipped_items")]
        public List<string> EquippedItems { get; set; }

        // characters
        [Column("mainchara_id")]
        public string MainCharaID { get; set; }
        [Column("subchara_id")]
        public string SubCharaID { get; set; }

        // chao
        [Column("mainchao_id")]
        public string MainChaoID { get; set; }
        [Column("subchao_id")]
        public string SubChaoID { get; set; }

        // rings
        [Column("num_rings")]
        public long NumRings { get; set; }
        [Column("num_buy_rings")]
        public long NumBuyRings { get; set; } // number of rings purchased using red rings

        // red rings
        [Column("num_red_rings")]
        public int NumRedRings { get; set; }
        [Column("num_buy_red_rings")]
        public int NumBuyRedRings { get; set; } // number of red rings purchased using real money; not used in Rerun

        // revive tokens
        [Column("energy")]
        public int Energy { get; set; }
        [Column("energy_buy")]
        public int EnergyBuy { get; set; } // number of revive tokens purchased using red rings
        [Column("energy_renews_at")]
        public long EnergyRenewsAt { get; set; }

        // gift box
        [Column("num_messages")]
        public int NumMessages { get; set; } // number of items in the gift box; investigate if this is used properly in-game

        [Column("ranking_league")]
        public RankingLeague RankingLeague { get; set; }
        [Column("quick_ranking_league")]
        public RankingLeague QuickRankingLeague { get; set; }

        // roulette tickets & chao eggs
        [Column("num_roulette_ticket")]
        public int NumRouletteTicket { get; set; }
        [Column("num_chao_roulette_ticket")]
        public int NumChaoRouletteTicket { get; set; }
        [Column("chao_eggs")]
        public int ChaoEggs { get; set; }

        [Column("high_score")]
        public long HighScore { get; set; } // this is a long since people are getting billion point scores which would overflow an int
        [Column("quick_high_score")]
        public long TimedHighScore { get; set; } // this is a long since people are getting billion point scores which would overflow an int

        [Column("total_distance")]
        public long TotalDistance { get; set; }
        [Column("best_distance")]
        public long HighDistance { get; set; }

        [Column("daily_mission_id")]
        public uint DailyMissionID { get; set; }
        [Column("daily_mission_end_time")]
        public long DailyMissionEndTime { get; set; }
        [Column("daily_challenge_value")]
        public int DailyChallengeValue { get; set; }
        [Column("daily_challenge_complete")]
        public byte DailyChallengeComplete { get; set; }
        [Column("num_daily_chal_cont")]
        public int NumDailyChallenge { get; set; }

        [Column("num_plays")]
        public int NumPlaying { get; set; } // number of games played
        [Column("num_animals")]
        public int Animals { get; set; }
        [Column("rank")]
        public ushort Rank { get; set; } // from 0 to 998; this is incremented by 1 internally by the game

        // internal use for daily challenge id calculation - in the future this should be moved to a separate table
        [Column("dm_cat")]
        public int DailyChalCatNum { get; set; }
        [Column("dm_set")]
        public int DailyChalSetNum { get; set; }
        [Column("dm_pos")]
        public int DailyChalPosNum { get; set; }
        [Column("dm_nextcont")]
        public int NextNumDailyChallenge { get; set; }

        // runners' league high scores
        [Column("league_high_score")]
        public long LeagueHighScore { get; set; }
        [Column("quick_league_high_score")]
        public long TimedLeagueHighScore { get; set; }

        // runners' league data
        [Column("league_start_time")]
        public long LeagueStartTime { get; set; }
        [Column("league_reset_time")]
        public long LeagueResetTime { get; set; }
        [Column("ranking_league_group")]
        public int RankingLeagueGroup { get; set; }
        [Column("timed_ranking_league_group")]
        public int TimedRankingLeagueGroup { get; set; }

        // total score
        [Column("total_score")]
        public long TotalScore { get; set; }
        [Column("quick_total_score")]
        public long TimedTotalScore { get; set; }
        [Column("best_total_score")]
        public long HighTotalScore { get; set; }
        [Column("best_quick_total_score")]
        public long TimedHighTotalScore { get; set; }

        // event state - moving this to EventState.cs at some point, as that will be moved to another table
        [Column("event_param")]
        public long EventParam { get; set; }
        [Column("event_rewardid")]
        public int EventRewardProgress { get; set; }
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
