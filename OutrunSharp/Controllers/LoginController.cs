using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OutrunSharp.Exceptions;
using OutrunSharp.Helpers;
using OutrunSharp.Models;
using OutrunSharp.Models.ParamModels;
using OutrunSharp.Models.RequestModels;
using OutrunSharp.Models.DbModels;
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
            OutrunDbContext context = HttpContext.RequestServices.GetService(typeof(OutrunDbContext)) as OutrunDbContext;
            LoginRequest paramData;
            if(secure == 1)
            {
                try
                {
                    paramData = RunnersRequestHelper.DecryptAndDeserializeParam<LoginRequest>(param, key);
                }
                catch(DecryptFailureException e)
                {
                    // Decryption failed
                    _logger.LogError("Decryption failed! Details: " + e.ToString());
                    return RunnersResponseHelper.CraftResponse(true,
                        RunnersResponseHelper.CreateBaseResponse(
                            "Cannot decrypt",
                            RunnersResponseHelper.StatusCode.DecryptionFailure,
                            0));
                }
                catch(JsonException e)
                {
                    // Deserialization failed
                    _logger.LogError("Deserialization failed! Details: "+ e.ToString());
                    return RunnersResponseHelper.CraftResponse(true,
                        RunnersResponseHelper.CreateBaseResponse(
                            "Cannot deserialize",
                            RunnersResponseHelper.StatusCode.ParamHashDifference,
                            0));
                }
            } else
            {
                paramData = JsonSerializer.Deserialize<LoginRequest>(param);
            }

            if(paramData.lineAuth.userId.Length == 0)
            {
                // registration - create a new account and return its info
                _logger.LogInformation("Entering Registration");
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
                    // pre-login - search for user by ID and return key
                    _logger.LogInformation("Entering Pre-Login");
                    try
                    {
                        PlayerInfo playerinfo = context.GetPlayerInfo(paramData.lineAuth.userId);
                        LoginCheckKeyResponse response = new("Bad password", (int)RunnersResponseHelper.StatusCode.PassWordError)
                        {
                            key = playerinfo.Player_key
                        };
                        return RunnersResponseHelper.CraftResponse(true, response);
                    }
                    catch (NoSuchPlayerException)
                    {
                        return RunnersResponseHelper.CraftResponse(true,
                            RunnersResponseHelper.CreateBaseResponse(
                            "Nonexistant player",
                            RunnersResponseHelper.StatusCode.MissingPlayer,
                            0));
                    }
                }
                else
                {
                    // login - use user id in conjunction with a password to create a session id
                    _logger.LogInformation("Entering Login");
                    _logger.LogInformation(paramData.lineAuth.password);
                    PlayerInfo playerinfo = context.GetPlayerInfo(paramData.lineAuth.userId);
                    return RunnersResponseHelper.CraftResponse(true,
                        RunnersResponseHelper.CreateBaseResponse(
                        "Not yet",
                        RunnersResponseHelper.StatusCode.MissingPlayer,
                        0));
                }
            }
        }
    }
}
