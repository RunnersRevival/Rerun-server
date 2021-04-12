using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace OutrunSharp.Controllers
{
    [Route("login")]
    public class InformationController : Controller
    {
        private readonly ILogger<InformationController> _logger;
        public InformationController(ILogger<InformationController> logger) => _logger = logger;
    }
}
