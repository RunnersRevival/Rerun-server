using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rerun.Helpers;
using Rerun.Models;
using Rerun.Models.DbModels;
using System.Diagnostics;
using Rerun.Models.RequestModels.Leaderboard;
using Rerun.Models.ResponseModels.Leaderboard;

namespace Rerun.Controllers
{
    [Route("Leaderboard")]
    public class LeaderboardController : Controller
    {
        private readonly ILogger<LeaderboardController> _logger;

        public LeaderboardController(ILogger<LeaderboardController> logger) => _logger = logger;

        [HttpPost]
        [Route("getWeeklyLeaderboardOptions")]
        public XeenResponseMessage GetWeeklyLeaderboardOptions(string key, string param, int secure)
        {
            var context = HttpContext.RequestServices.GetService(typeof(OutrunDbContext)) as OutrunDbContext;
            var (paramData, errorResponseMsg) = RunnersRequestHelper.TryDecryptParam<WeeklyLeaderboardOptionsRequest>(key, param, secure);
            if (errorResponseMsg is not null) return errorResponseMsg; // something went wrong

            Debug.Assert(context != null, nameof(context) + " != null");
            var playerId = context.CheckSessionID(paramData.sessionId);
            if (playerId.Length == 0)
                return RunnersResponseHelper.CraftResponse(true,
                    RunnersResponseHelper.CreateBaseResponse(
                        "Expired session",
                        RunnersResponseHelper.StatusCode.ExpirationSession,
                        int.Parse(paramData.seq)));
            WeeklyLeaderboardOptionsResponse response = new()
            {
                seq = paramData.seq
            };
            return RunnersResponseHelper.CraftResponse(true, response);
        }

        /*[HttpPost]
        [Route("getWeeklyLeaderboardEntries")]
        public XeenResponseMessage GetWeeklyLeaderboardEntries(string key, string param, int secure)
        {

        }

        [HttpPost]
        [Route("getLeagueData")]
        public XeenResponseMessage GetLeagueData(string key, string param, int secure)
        {

        }*/
    }
}