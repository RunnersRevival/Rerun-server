using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutrunSharp.Controllers
{
    public class SpinController : Controller
    {

        private readonly ILogger<SpinController> _logger;

        public SpinController(ILogger<SpinController> logger)
        {
            _logger = logger;
        }
    }
}
