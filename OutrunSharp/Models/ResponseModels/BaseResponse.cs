﻿using System;

#pragma warning disable IDE1006 // Naming Styles

namespace OutrunSharp.Models.ResponseModels
{
    public class BaseResponse
    {
        public BaseResponse()
        {
            DateTimeOffset ct = new DateTime(
                DateTime.Now.Year,
                DateTime.Now.Month,
                DateTime.Now.Day,
                23, 59, 59, 999);
            long ctUnix = ct.ToUnixTimeSeconds();
            errorMessage = "OK";
			statusCode = 0;
            seq = "0";
            serverTime = DateTimeOffset.Now.ToUnixTimeSeconds();
            closeTime = ctUnix;
            // TODO: Make the below options configurable!
            assets_version = "050";
            client_data_version = "2.0.4";
            data_version = "15";
            info_version = "017";
            version = "2.0.4";
        }

        public BaseResponse(string errMsg, int status)
        {
            DateTimeOffset ct = new DateTime(
                DateTime.Now.Year,
                DateTime.Now.Month,
                DateTime.Now.Day,
                23, 59, 59, 999);
            long ctUnix = ct.ToUnixTimeSeconds();
            errorMessage = errMsg;
            statusCode = status;
            seq = "0";
            serverTime = DateTimeOffset.Now.ToUnixTimeSeconds();
            closeTime = ctUnix;
            // TODO: Make the below options configurable!
            assets_version = "050";
            client_data_version = "2.0.4";
            data_version = "15";
            info_version = "017";
            version = "2.0.4";
        }

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
