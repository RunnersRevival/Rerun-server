using System;
using Rerun.Models.Obj;
// ReSharper disable InconsistentNaming

namespace Rerun.Models.ResponseModels.Chao
{
    public class ChaoWheelOptionsResponse
    {
    }

    public class ChaoWheelOptionsModel
    {
        public RouletteRarity[] rarity { get; set; }
        public int[] itemWeight { get; set; }

        public Campaign[] campaignList { get; set; }

        public int spinCost { get; set; }
        public ChaoWheelType chaoRouletteType { get; set; }
        public int numSpecialEgg { get; set; }
        public byte rouletteAvailable { get; set; } // flag
        public int numChaoRouletteToken { get; set; } // number of roulette tickets
        public int numChaoRoulette { get; set; } // not sure if this is actually used for anything meaningful, but it might have something to do with a tutorial flag???
        public long startTime { get; set; } // the time that this chao roulette becomes active
        public long endTime { get; set; } // the time that this chao roulette is scheduled to expire

        public ChaoWheelOptionsModel()
        {
            DateTimeOffset st = new DateTime(
                DateTime.Now.Year,
                DateTime.Now.Month,
                DateTime.Now.Day,
                0, 0, 0, 0);
            var stUnix = st.ToUnixTimeSeconds(); // beginning of current day
            DateTimeOffset et = new DateTime(
                DateTime.Now.Year,
                DateTime.Now.Month,
                DateTime.Now.Day,
                23, 59, 59, 999);
            var etUnix = et.ToUnixTimeSeconds(); // end of current day

            rarity = new[]
            {
                RouletteRarity.SuperRareChao,
                RouletteRarity.RareChao,
                RouletteRarity.Character,
                RouletteRarity.NormalChao,
                RouletteRarity.SuperRareChao,
                RouletteRarity.NormalChao,
                RouletteRarity.Character,
                RouletteRarity.RareChao
            };
            itemWeight = new[] { 6, 17, 5, 17, 16, 17, 5, 17 };
            campaignList = Array.Empty<Campaign>();
            chaoRouletteType = ChaoWheelType.ChaoWheelTypeNormal;
            numSpecialEgg = 0;
            rouletteAvailable = 1;
            numChaoRouletteToken = 0;
            numChaoRoulette = 1;
            startTime = stUnix;
            endTime = etUnix;
        }
    }

    public enum ChaoWheelType
    {
        ChaoWheelTypeNormal,
        ChaoWheelTypeSpecial
    }

    public enum RouletteRarity
    {
        NormalChao,
        RareChao,
        SuperRareChao,
        Character = 100,
        // TODO: implement Promotion eggs
    }
}
