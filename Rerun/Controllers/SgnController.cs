using Microsoft.AspNetCore.Mvc;
using Rerun.Helpers;
using Rerun.Models.DbModels;
using Rerun.Models.RequestModels;
using Rerun.Models.ResponseModels.Game;
using Rerun.Models;
using System.Diagnostics;
using Rerun.Models.ResponseModels;

namespace Rerun.Controllers
{
    // These endpoints cover SEGA Networks telemetry. These will all be agnostic.
    [Route("Sgn")]
    public class SgnController : Controller
    {
        [Route("sendApollo")]
        [HttpPost]
        public XeenResponseMessage SendApollo(string key, string param, int secure)
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
            BaseResponse response = new()
            {
                seq = paramData.seq
            };
            return RunnersResponseHelper.CraftResponse(true, response);
        }
    }
}
