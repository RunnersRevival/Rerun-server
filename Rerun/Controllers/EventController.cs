using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rerun.Exceptions;
using Rerun.Helpers;
using Rerun.Models;
using Rerun.Models.DbModels;
using Rerun.Models.RequestModels;
using Rerun.Models.ResponseModels.Event;

namespace Rerun.Controllers
{
    // These endpoints cover event-specific functions.
    [Route("Event")]
    public class EventController : Controller
    {
        private readonly ILogger<EventController> _logger;
        public EventController(ILogger<EventController> logger) => _logger = logger;

        [Route("getEventList")]
        [HttpPost]
        public XeenResponseMessage GetEventList(string key, string param, int secure)
        {
            var context = HttpContext.RequestServices.GetService(typeof(OutrunDbContext)) as OutrunDbContext;
            var (paramData, errorResponseMsg) = RunnersRequestHelper.TryDecryptParam<BaseRequest>(key, param, secure);
            if (errorResponseMsg is not null)
                return errorResponseMsg; // something went wrong

            Debug.Assert(context != null, nameof(context) + " != null");
            var playerId = context.CheckSessionID(paramData.sessionId);
            if (playerId.Length == 0)
                return RunnersResponseHelper.CraftResponse(true,
                    RunnersResponseHelper.CreateBaseResponse(
                        "Expired session",
                        RunnersResponseHelper.StatusCode.ExpirationSession,
                        int.Parse(paramData.seq)));
            EventListResponse response = new()
            {
                seq = paramData.seq
            };
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
