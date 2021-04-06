using OutrunSharp.Models.RequestModels.Obj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#pragma warning disable IDE1006 // Naming Styles

namespace OutrunSharp.Models.RequestModels
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
