using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rerun.Exceptions;
using Rerun.Helpers;
using Rerun.Models;
using Rerun.Models.DbModels;
using Rerun.Models.RequestModels;
using Rerun.Models.ResponseModels.Spin;
using System.Diagnostics;
using System.Text.Json;

namespace Rerun.Controllers
{
    // These endpoints cover roulette-specific operations
    [Route("Spin")]
    public class SpinController : Controller
    {
        private readonly ILogger<SpinController> _logger;

        public SpinController(ILogger<SpinController> logger) => _logger = logger;

        [Route("getWheelOptions")]
        [HttpPost]
        public XeenResponseMessage GetWheelOptions(string key, string param, int secure)
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
            WheelOptionsResponse response = new()
            {
                seq = paramData.seq
            };
            // TODO: get player data
            return RunnersResponseHelper.CraftResponse(true, response);
        }
    }
}
