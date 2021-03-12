using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutrunSharp.Models.ResponseModels
{
    public class VariousParamsResponse : BaseResponse
    {
        public VariousParamsResponse() : base()
        {
            cmSkipCount = 0;
            energyRecoveryMax = 10;
            energyRecveryTime = 600;
            onePlayCmCount = 0;
            onePlayContinueCount = 2;
            isPurchased = 0;
        }
        public VariousParamsResponse(string errMsg, int status) : base(errMsg, status)
        {
            cmSkipCount = 0;
            energyRecoveryMax = 10;
            energyRecveryTime = 600;
            onePlayCmCount = 0;
            onePlayContinueCount = 2;
            isPurchased = 0;
        }

        public int cmSkipCount { get; set; }
        public int energyRecoveryMax { get; set; }
        public int energyRecveryTime { get; set; }
        public int onePlayCmCount { get; set; }
        public int onePlayContinueCount { get; set; } // maximum continues
        public int isPurchased { get; set; }
    }
}
