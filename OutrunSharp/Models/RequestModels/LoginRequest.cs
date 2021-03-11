using OutrunSharp.Models.RequestModels.Obj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutrunSharp.Models.RequestModels
{
    public class LoginRequest : BaseRequest
    {
        public string device { get; set; } // Device information
        public string platform { get; set; }
        public string language { get; set; }
        public string salesLocate { get; set; }
        public string storeId { get; set; }
        public string platform_sns { get; set; }

        public LineAuth lineAuth { get; set; }
    }
}
