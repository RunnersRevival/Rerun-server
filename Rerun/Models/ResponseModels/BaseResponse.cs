using System;

// ReSharper disable InconsistentNaming
#pragma warning disable IDE1006 // Naming Styles

namespace Rerun.Models.ResponseModels
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
            errorMessage = "OK";
			statusCode = 0;
            seq = "0";
            serverTime = DateTimeOffset.Now.ToUnixTimeSeconds();
            closeTime = ct.ToUnixTimeSeconds();
            // TODO: Make the below options configurable!
            assets_version = "054";
            client_data_version = "0";
            data_version = "15";
            info_version = "017";
            version = "2.2.2";
        }

        public BaseResponse(string errMsg, int status)
        {
            DateTimeOffset ct = new DateTime(
                DateTime.Now.Year,
                DateTime.Now.Month,
                DateTime.Now.Day,
                23, 59, 59, 999);
            errorMessage = errMsg;
            statusCode = status;
            seq = "0";
            serverTime = DateTimeOffset.Now.ToUnixTimeSeconds();
            closeTime = ct.ToUnixTimeSeconds();
            // TODO: Make the below options configurable!
            assets_version = "054";
            client_data_version = "0";
            data_version = "15";
            info_version = "017";
            version = "2.2.2";
        }

        /// <summary>
        /// A human-readable string meant to indicate the error status.
        /// </summary>
        /// <remarks>
        /// This value is not actually used by the game; it's just there for debugging.
        /// </remarks>
        public string errorMessage { get; set; }
        
        /// <summary>
        /// Unix timestamp indicating the end of the day.
        /// </summary>
        public long closeTime { get; set; } // indicates end of day
        
        /// <summary>
        /// The current sequence number.
        /// </summary>
        /// <remarks>
        /// Should be converted from an int, since the game internally converts this string back into an int.
        /// </remarks>
        public string seq { get; set; } // int, indicates sequence number
        
        /// <summary>
        /// Unix timestamp indicating the current server time. Used for keeping timed stuff such as events, energy refresh, and timed mileage rewards in sync with the server.
        /// </summary>
        public long serverTime { get; set; }
        
        /// <summary>
        /// The status code for the response.
        /// </summary>
        /// <remarks>
        /// It is recommended that the <see cref="Rerun.Helpers.RunnersResponseHelper.StatusCode"/> enum be used as to prevent instability.
        /// </remarks>
        public int statusCode { get; set; } // indicates status code

        public string assets_version { get; set; }
        /// <summary>
        /// A value with an unknown purpose. It is read by the game as an int.
        /// </summary>
        public string client_data_version { get; set; }
        /// <summary>
        /// The server data file's version.
        /// </summary>
        public string data_version { get; set; }
        /// <summary>
        /// The info version.
        /// </summary>
        public string info_version { get; set; }
        /// <summary>
        /// The server version. Ideally should match the client version.
        /// </summary>
        public string version { get; set; }
    }
}
