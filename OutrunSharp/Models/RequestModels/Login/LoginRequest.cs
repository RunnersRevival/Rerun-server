using OutrunSharp.Models.RequestModels.Login.Obj;

// ReSharper disable InconsistentNaming
#pragma warning disable IDE1006 // Naming Styles

namespace OutrunSharp.Models.RequestModels.Login
{
    public class LoginRequest : BaseRequest
    {
        public string device { get; set; } // Device information
        public string platform { get; set; } // int
        public string language { get; set; } // number from 0 to 8
        public string salesLocate { get; set; } // int
        public string storeId { get; set; } // int
        public string platform_sns { get; set; } // int

        public LineAuth lineAuth { get; set; }
    }
}
