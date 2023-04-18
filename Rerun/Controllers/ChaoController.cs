using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rerun.Models;

namespace Rerun.Controllers
{
    [Route("Chao")]
    public class ChaoController : Controller
    {
        private readonly ILogger<ChaoController> _logger;

        public ChaoController(ILogger<ChaoController> logger) => _logger = logger;

        /*[Route("getChaoWheelOptions")]
        [HttpPost]
        public XeenResponseMessage GetChaoWheelOptions(string key, string param, int secure)
        {
        }*/
    }
}
