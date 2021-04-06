using System;

#pragma warning disable IDE1006 // Naming Styles

namespace OutrunSharp.Models.ResponseModels.Login
{
    public class LoginCheckKeyResponse : BaseResponse
    {
        public LoginCheckKeyResponse() : base()
        {
        }
        public LoginCheckKeyResponse(string errMsg, int status) : base(errMsg, status)
        {
        }

        public string key { get; set; }
    }
    public class LoginRegisterResponse : LoginCheckKeyResponse
    {
        public LoginRegisterResponse() : base()
        {
        }
        public LoginRegisterResponse(string errMsg, int status) : base(errMsg, status)
        {
        }

        public string userId { get; set; }
        public string password { get; set; }
        public string countryId { get; set; }
        public string countryCode { get; set; }
    }
    public class LoginSuccessResponse : BaseResponse
    {
        public LoginSuccessResponse() : base()
        {
        }
        public LoginSuccessResponse(string errMsg, int status) : base(errMsg, status)
        {
        }

        public string userName { get; set; }
        public string sessionId { get; set; }
        public long sessionTimeLimit { get; set; }

        public string energyRecveryTime { get; set; }
        public string energyRecoveryMax { get; set; }
    }
}
