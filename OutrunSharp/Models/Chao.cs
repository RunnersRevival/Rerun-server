using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutrunSharp.Models
{
    // Chao are the internal name of companions/buddies
    public class Chao
    {
        public string chaoId { get; set; }
        public ChaoRarity rarity { get; set; }
        public int hidden { get; set; } // flag
        public ChaoStatus status { get; set; }
        public int level { get; set; }
        public ChaoDealing setStatus { get; set; }
        public int acquired { get; set; } // flag
    }

    public enum ChaoRarity
    {
        ChaoRarityNormal,
        ChaoRarityRare,
        ChaoRaritySuperRare,
        ChaoRarityNone
    }

    public enum ChaoStatus
    {
        ChaoStatusLocked,
        ChaoStatusUnlocked,
        ChaoStatusMaxLevel
    }

    public enum ChaoDealing
    {
        ChaoDealingNone, // not selected
        ChaoDealingLeader, // primary chao
        ChaoDealingSub // secondary chao
    }
}
