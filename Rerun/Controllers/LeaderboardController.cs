using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Rerun.Controllers
{
    [Route("Leaderboard")]
    public class LeaderboardController : Controller
    {
        private readonly ILogger<LeaderboardController> _logger;

        public LeaderboardController(ILogger<LeaderboardController> logger) => _logger = logger;

    }
}