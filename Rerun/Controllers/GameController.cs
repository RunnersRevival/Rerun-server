using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rerun.Exceptions;
using Rerun.Helpers;
using Rerun.Models;
using Rerun.Models.DbModels;
using Rerun.Models.RequestModels;
using Rerun.Models.ResponseModels.Game;
using System.Diagnostics;
using System.Text.Json;

namespace Rerun.Controllers
{
    // These endpoints cover gameplay-related elements.
    [Route("Game")]
    public class GameController : Controller
    {
        private readonly ILogger<GameController> _logger;

        public GameController(ILogger<GameController> logger) => _logger = logger;

        [Route("getDailyChalData")]
        [HttpPost]
        public XeenResponseMessage GetDailyChallengeData(string key, string param, int secure)
        {
            var context = HttpContext.RequestServices.GetService(typeof(OutrunDbContext)) as OutrunDbContext;
            var (paramData, errorResponseMsg) = RunnersRequestHelper.TryDecryptParam<BaseRequest>(key, param, secure);
            if (errorResponseMsg is not null) return errorResponseMsg; // something went wrong

            Debug.Assert(context != null, nameof(context) + " != null");
            var playerId = context.CheckSessionID(paramData.sessionId);
            if (playerId.Length == 0)
                return RunnersResponseHelper.CraftResponse(true,
                    RunnersResponseHelper.CreateBaseResponse(
                        "Expired session",
                        RunnersResponseHelper.StatusCode.ExpirationSession,
                        int.Parse(paramData.seq)));
            DailyChallengeDataResponse response = new() {
                seq = paramData.seq
            };
            return RunnersResponseHelper.CraftResponse(true, response);
        }

        [Route("getCostList")]
        [HttpPost]
        public XeenResponseMessage GetCostList(string key, string param, int secure)
        {
            var context = HttpContext.RequestServices.GetService(typeof(OutrunDbContext)) as OutrunDbContext;
            var (paramData, errorResponseMsg) = RunnersRequestHelper.TryDecryptParam<BaseRequest>(key, param, secure);
            if (errorResponseMsg is not null) return errorResponseMsg; // something went wrong

            Debug.Assert(context != null, nameof(context) + " != null");
            var playerId = context.CheckSessionID(paramData.sessionId);
            if (playerId.Length == 0)
                return RunnersResponseHelper.CraftResponse(true,
                    RunnersResponseHelper.CreateBaseResponse(
                        "Expired session",
                        RunnersResponseHelper.StatusCode.ExpirationSession,
                        int.Parse(paramData.seq)));
            CostListResponse response = new() {
                seq = paramData.seq
            };
            return RunnersResponseHelper.CraftResponse(true, response);
        }

        [Route("getMileageData")]
        [HttpPost]
        public XeenResponseMessage GetMileageData(string key, string param, int secure)
        {
            var context = HttpContext.RequestServices.GetService(typeof(OutrunDbContext)) as OutrunDbContext;
            var (paramData, errorResponseMsg) = RunnersRequestHelper.TryDecryptParam<BaseRequest>(key, param, secure);
            if (errorResponseMsg is not null) return errorResponseMsg; // something went wrong

            Debug.Assert(context != null, nameof(context) + " != null");
            var playerId = context.CheckSessionID(paramData.sessionId);
            if (playerId.Length == 0)
                return RunnersResponseHelper.CraftResponse(true,
                    RunnersResponseHelper.CreateBaseResponse(
                        "Expired session",
                        RunnersResponseHelper.StatusCode.ExpirationSession,
                        int.Parse(paramData.seq)));
            // TODO: get this from player data
            MileageDataResponse response = new()
            {
                seq = paramData.seq
            };
            return RunnersResponseHelper.CraftResponse(true, response);
        }

        [Route("getCampaignList")]
        [HttpPost]
        public XeenResponseMessage GetCampaignList(string key, string param, int secure)
        {
            var context = HttpContext.RequestServices.GetService(typeof(OutrunDbContext)) as OutrunDbContext;
            var (paramData, errorResponseMsg) = RunnersRequestHelper.TryDecryptParam<BaseRequest>(key, param, secure);
            if (errorResponseMsg is not null) return errorResponseMsg; // something went wrong

            Debug.Assert(context != null, nameof(context) + " != null");
            var playerId = context.CheckSessionID(paramData.sessionId);
            if (playerId.Length == 0)
                return RunnersResponseHelper.CraftResponse(true,
                    RunnersResponseHelper.CreateBaseResponse(
                        "Expired session",
                        RunnersResponseHelper.StatusCode.ExpirationSession,
                        int.Parse(paramData.seq)));
            CampaignListResponse response = new()
            {
                seq = paramData.seq
            };
            return RunnersResponseHelper.CraftResponse(true, response);
        }
    }
}
