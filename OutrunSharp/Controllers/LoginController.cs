using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OutrunSharp.Exceptions;
using OutrunSharp.Logic;
using OutrunSharp.Models;
using OutrunSharp.Models.ParamModels;
using OutrunSharp.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace OutrunSharp.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        [Route("Login/login")]
        [HttpPost]
        public RunnersResponseMessage DoLogin(string key, string param, int secure)
        {
            _logger.LogInformation("Key: "+ key +", Secure = "+secure+",  Param = "+ param);

            LoginRequest paramData;

            if(secure == 1)
            {
                try
                {
                    paramData = RunnersRequestHelper.DecryptAndDeserializeParam<LoginRequest>(param, key);
                }
                catch(DecryptFailureException e)
                {
                    return RunnersResponseHelper.CraftResponse(true,
                        RunnersResponseHelper.CreateBaseResponse(
                            e.Message,
                            RunnersResponseHelper.StatusCode.DecryptionFailure,
                            0));
                }
                catch(JsonException e)
                {
                    return RunnersResponseHelper.CraftResponse(true,
                        RunnersResponseHelper.CreateBaseResponse(
                            e.Message,
                            RunnersResponseHelper.StatusCode.ParamHashDifference,
                            0));
                }
            } else
            {
                paramData = JsonSerializer.Deserialize<LoginRequest>(param);
            }

            if(paramData.lineAuth.userId.Length == 0)
            {
                // this must be a new account!
                _logger.LogInformation("Entering LoginAlpha (registration)");
                // TODO: add actual logic here
                return RunnersResponseHelper.CraftResponse(true,
                RunnersResponseHelper.CreateBaseResponse(
                    "Account creation NYI",
                    RunnersResponseHelper.StatusCode.MissingPlayer,
                    0));
            }
            else
            {
                if (paramData.lineAuth.password.Length == 0)
                {
                    // initial sign in attempt
                    _logger.LogInformation("Entering LoginBeta (pre-login)");
                    // TODO: add actual logic here
                    return RunnersResponseHelper.CraftResponse(true,
                        RunnersResponseHelper.CreateBaseResponse(
                        "Player does not exist",
                        RunnersResponseHelper.StatusCode.MissingPlayer,
                        0));
                }
                else
                {
                    _logger.LogInformation("Entering LoginGamma (login)");
                    // TODO: add actual logic here
                    return RunnersResponseHelper.CraftResponse(true,
                        RunnersResponseHelper.CreateBaseResponse(
                        "Player does not exist",
                        RunnersResponseHelper.StatusCode.MissingPlayer,
                        0));
                }
            }
        }
    }
}
