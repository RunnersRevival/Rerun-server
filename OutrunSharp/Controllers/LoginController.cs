using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OutrunSharp.Logic;
using OutrunSharp.Models;
using OutrunSharp.Models.ParamModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutrunSharp.Controllers
{
    public class LoginController : Controller
    {
        [Route("Login/login")]
        [HttpPost]
        public RunnersResponseMessage DoLogin()
        {
            return RunnersResponseBuilder.CraftResponse(true,
                RunnersResponseBuilder.CreateBaseResponse(
                    "Login not implemented",
                    RunnersResponseBuilder.StatusCode.NotAvailablePlayer,
                    1));
        }
    }
}
