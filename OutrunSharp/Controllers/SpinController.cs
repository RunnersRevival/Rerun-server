﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OutrunSharp.Exceptions;
using OutrunSharp.Helpers;
using OutrunSharp.Models;
using OutrunSharp.Models.DbModels;
using OutrunSharp.Models.RequestModels;
using OutrunSharp.Models.ResponseModels.Spin;
using System.Diagnostics;
using System.Text.Json;

namespace OutrunSharp.Controllers
{
    [Route("Spin")]
    public class SpinController : Controller
    {
        private readonly ILogger<SpinController> _logger;

        public SpinController(ILogger<SpinController> logger) => _logger = logger;

        [Route("getWheelOptions")]
        [HttpPost]
        public RunnersResponseMessage GetWheelOptions(string key, string param, int secure)
        {
            var context = HttpContext.RequestServices.GetService(typeof(OutrunDbContext)) as OutrunDbContext;
            BaseRequest paramData;
            if (secure == 1)
            {
                try
                {
                    paramData = RunnersRequestHelper.DecryptAndDeserializeParam<BaseRequest>(param, key);
                }
                catch (DecryptFailureException e)
                {
                    // Decryption failed
                    _logger.LogError("Decryption failed! Details: " + e);
                    return RunnersResponseHelper.CraftResponse(true,
                        RunnersResponseHelper.CreateBaseResponse(
                            "Cannot decrypt",
                            RunnersResponseHelper.StatusCode.DecryptionFailure,
                            0));
                }
                catch (JsonException e)
                {
                    // Deserialization failed
                    _logger.LogError("Deserialization failed! Details: " + e);
                    return RunnersResponseHelper.CraftResponse(true,
                        RunnersResponseHelper.CreateBaseResponse(
                            "Cannot deserialize",
                            RunnersResponseHelper.StatusCode.RequestParamError,
                            0));
                }
            }
            else
            {
                paramData = JsonSerializer.Deserialize<BaseRequest>(param);
                if (paramData is null)
                    return RunnersResponseHelper.CraftResponse(true,
                        RunnersResponseHelper.CreateBaseResponse(
                            "!(paramData != null)",
                            RunnersResponseHelper.StatusCode.ServerSystemError,
                            0));
            }

            Debug.Assert(context != null, nameof(context) + " != null");
            var playerId = context.CheckSessionID(paramData.sessionId);
            if (playerId.Length == 0)
                return RunnersResponseHelper.CraftResponse(true,
                    RunnersResponseHelper.CreateBaseResponse(
                        "Expired session",
                        RunnersResponseHelper.StatusCode.ExpirationSession,
                        0));
            WheelOptionsResponse response = new();
            // TODO: get player data
            return RunnersResponseHelper.CraftResponse(true, response);
        }
    }
}
