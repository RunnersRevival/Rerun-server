// ReSharper disable InconsistentNaming
#pragma warning disable IDE1006 // Naming Styles

namespace OutrunSharp.Models.ResponseModels.Login
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
            isPurchased = 1;
        }
        public VariousParamsResponse(string errMsg, int status) : base(errMsg, status)
        {
            cmSkipCount = 0;
            energyRecoveryMax = 10;
            energyRecveryTime = 600;
            onePlayCmCount = 0;
            onePlayContinueCount = 2;
            isPurchased = 1;
        }

        public int cmSkipCount { get; set; }
        public int energyRecoveryMax { get; set; }
        public int energyRecveryTime { get; set; }
        public int onePlayCmCount { get; set; }
        public int onePlayContinueCount { get; set; } // maximum continues
        public int isPurchased { get; set; } // flag
    }
}
