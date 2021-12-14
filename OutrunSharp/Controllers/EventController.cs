﻿using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OutrunSharp.Exceptions;
using OutrunSharp.Helpers;
using OutrunSharp.Models;
using OutrunSharp.Models.DbModels;
using OutrunSharp.Models.RequestModels;
using OutrunSharp.Models.ResponseModels.Event;

namespace OutrunSharp.Controllers
{
    // These endpoints cover event-specific functions.
    [Route("Event")]
    public class EventController : Controller
    {
        private readonly ILogger<EventController> _logger;
        public EventController(ILogger<EventController> logger) => _logger = logger;

        [Route("getEventList")]
        [HttpPost]
        public RunnersResponseMessage GetEventList(string key, string param, int secure)
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
                            "Assertion failed: !(paramData != null)",
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
            EventListResponse response = new();
            return RunnersResponseHelper.CraftResponse(true, response);
        }

        /* TODO: Remaining event endpoints:
         * getEventReward - for special stages, raid bosses, and object collection events; a list of rewards
         * getEventState - for special stages, raid bosses, and object collection events; player's event-specific data
         */

        /* TODO: Remaining raid boss endpoints:
         * getEventUserRaidboss
         * getEventUserRaidbossList
         * getEventRaidbossDesiredList
         * getEventRaidbossUserList
         * eventActStart
         * eventPostGameResults
         * eventUpdateGameResults
         */
    }
}
