using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutrunSharp.Models.ParamModels
{
    public class BaseResponse
    {
        public string errorMessage { get; set; } // indicates error status (in the original, it was in Japanese, but it seems to not be checked by the game)
        public long closeTime { get; set; } // indicates end of day
        public string seq { get; set; } // int, indicates sequence number - does this even matter?
        public long serverTime { get; set; } // indicates current server time
        public int statusCode { get; set; } // indicates status code

        public string assets_version { get; set; }
        public string client_data_version { get; set; }
        public string data_version { get; set; }
        public string info_version { get; set; }
        public string version { get; set; }
    }
}
