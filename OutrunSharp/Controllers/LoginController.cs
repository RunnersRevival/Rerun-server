using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OutrunSharp.Exceptions;
using OutrunSharp.Helpers;
using OutrunSharp.Models;
using OutrunSharp.Models.ResponseModels;
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
                        string pkey = context.GetPlayerKey(paramData.lineAuth.userId);
                        LoginCheckKeyResponse response = new("Bad password", (int)RunnersResponseHelper.StatusCode.PassWordError)
                        {
                            key = pkey
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
                    if (context.ValidatePassword(paramData.lineAuth.userId, paramData.lineAuth.password))
                    {
                        _logger.LogInformation("Successful login");
                        string sessionId = context.CreateSessionID(Convert.ToUInt64(paramData.lineAuth.userId));
                        PlayerInfo playerinfo = context.GetPlayerInfo(paramData.lineAuth.userId);
                        context.UpdatePlayerInfo(paramData.lineAuth.userId, "last_login", DateTimeOffset.Now.ToUnixTimeSeconds().ToString());
                        LoginSuccessResponse response = new()
                        {
                            userName = playerinfo.Username,
                            sessionId = sessionId,
                            sessionTimeLimit = 3600, // TODO: Have this in a config file!
                            energyRecveryTime = "600", // TODO: Have this in a config file!
                            energyRecoveryMax = "10" // TODO: Have this in a config file!
                        };
                        return RunnersResponseHelper.CraftResponse(true, response);
                    }
                    else
                    {
                        _logger.LogInformation("Auth failed!");
                        string pkey = context.GetPlayerKey(paramData.lineAuth.userId);
                        LoginCheckKeyResponse response = new("Bad password", (int)RunnersResponseHelper.StatusCode.PassWordError)
                        {
                            key = pkey
                        };
                        return RunnersResponseHelper.CraftResponse(true, response);
                    }
                }
            }
        }

        [Route("Login/getVariousParameters")]
        [HttpPost]
        public RunnersResponseMessage GetVariousParameters(string key, string param, int secure)
        {
            // agnostic; we do not need to get anything from param here
            VariousParamsResponse response = new();
            return RunnersResponseHelper.CraftResponse(true, response);
        }
    }
}
