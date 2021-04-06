using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#pragma warning disable IDE1006 // Naming Styles

namespace OutrunSharp.Models.ResponseModels.Spin
{
    public class WheelOptionsResponse : BaseResponse
    {
        public WheelOptionsResponse() : base()
        {
            wheelOptions = new();
        }
        public WheelOptionsResponse(string errMsg, int status) : base(errMsg, status)
        {
            wheelOptions = new();
        }

        public WheelOptionsModel wheelOptions { get; set; }
    }

    public class WheelOptionsModel
    {
        public WheelOptionsModel()
        {
            DateTimeOffset rt = new DateTime(
                DateTime.Now.Year,
                DateTime.Now.Month,
                DateTime.Now.Day,
                23, 59, 59, 999).AddMilliseconds(1);
            long rtUnix = rt.ToUnixTimeSeconds();
            items = new string[] { "200000", "120000", "120001", "120002", "200000", "900000", "120003", "120004" };
            item = new int[] { 1, 1, 1, 1, 1, 1, 1, 1 };
            itemWeight = new uint[] { 1250, 1250, 1250, 1250, 1250, 1250, 1250, 1250 };
            itemWon = 0;
            nextFreeSpin = rtUnix;
            spinId = 0;
            spinCost = 1;
            rouletteRank = 0;
            numRouletteToken = 0;
            numJackpotRing = 99999;
            numRemainingRoulette = 0;
        }

        public string[] items { get; set; } // item IDs
        public int[] item { get; set; } // item quantities
        public uint[] itemWeight { get; set; } // the chances of getting each item

        public int itemWon { get; set; } // index of item won

        public long nextFreeSpin { get; set; } // reset time for roulette
        public int spinId { get; set; }
        public int spinCost { get; set; } // typically 1 in the case of the item roulette

        public int rouletteRank { get; set; } // 0: normal, 1: big, 2: super
        public int numRouletteToken { get; set; } // number of roulette tickets

        public int numJackpotRing { get; set; } // number of rings on the jackpot
        public int numRemainingRoulette { get; set; } // number of spins left
    }


}
