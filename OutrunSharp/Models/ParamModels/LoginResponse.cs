using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutrunSharp.Models.ParamModels
{
    public class LoginCheckKeyResponse : BaseResponse
    {
        public string key { get; set; }
    }
    public class LoginRegisterResponse : LoginCheckKeyResponse
    {
        public string userId { get; set; }
        public string password { get; set; }
        public string countryId { get; set; }
        public string countryCode { get; set; }
    }
    public class LoginSuccessResponse : BaseResponse
    {
        public string userName { get; set; }
        public string sessionId { get; set; }
        public long sessionTimeLimit { get; set; }

        public string energyRecveryTime { get; set; }
        public string energyRecoveryMax { get; set; }
    }
}
