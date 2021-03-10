using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OutrunSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutrunSharp.Controllers
{
    public class LoginController : Controller
    {
        [Route("Login/login")]
        [HttpGet]
        public RunnersResponseMessage DoLogin()
        {
            return new RunnersResponseMessage {
                key = "",
                param = { },
                secure = 0
            };
        }
    }
}
