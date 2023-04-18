using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rerun.Exceptions;
using Rerun.Helpers;
using Rerun.Models;
using Rerun.Models.DbModels;
using Rerun.Models.Obj;
using Rerun.Models.RequestModels;
using Rerun.Models.ResponseModels.Information;

namespace Rerun.Controllers
{
    // These endpoints cover news banners, tickers, and event result messages.
    // At one point these were located in a separate route from Login? The lack of capitalization suggests that this may have been a sloppy change in response to SEGA merging the Login and Information routes.
    [Route("login")]
    public class InformationController : Controller
    {
        private readonly ILogger<InformationController> _logger;
        public InformationController(ILogger<InformationController> logger) => _logger = logger;

        [Route("getInformation")]
        [HttpPost]
        public XeenResponseMessage GetInformation(string key, string param, int secure)
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
            InformationResponse response = new()
            {
                informations = new List<Information>
                {
                    new()
                },
                seq = paramData.seq
            };
            return RunnersResponseHelper.CraftResponse(true, response);
        }

        [Route("getTicker")]
        [HttpPost]
        public XeenResponseMessage GetTicker(string key, string param, int secure)
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
            TickerResponse response = new()
            {
                tickerList = new List<Ticker>
                {
                    new()
                },
                seq = paramData.seq
            };
            return RunnersResponseHelper.CraftResponse(true, response);
        }
    }
}
