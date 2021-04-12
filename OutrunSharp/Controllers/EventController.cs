using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace OutrunSharp.Controllers
{
    [Route("Event")]
    public class EventController : Controller
    {
        private readonly ILogger<EventController> _logger;
        public EventController(ILogger<EventController> logger) => _logger = logger;
    }
}
