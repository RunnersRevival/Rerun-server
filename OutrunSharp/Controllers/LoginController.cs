using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OutrunSharp.Exceptions;
using OutrunSharp.Helpers;
using OutrunSharp.Models;
using OutrunSharp.Models.ResponseModels.Login;
using OutrunSharp.Models.RequestModels;
using OutrunSharp.Models.RequestModels.Login;
using OutrunSharp.Models.DbModels;
using System;
using System.Diagnostics;
using System.Text.Json;

namespace OutrunSharp.Controllers
{
    [Route("Login")]
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger) => _logger = logger;

        [Route("login")]
        [HttpPost]
        public RunnersResponseMessage DoLogin(string key, string param, int secure)
        {
            var context = HttpContext.RequestServices.GetService(typeof(OutrunDbContext)) as OutrunDbContext;
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
                    _logger.LogError("Decryption failed! Details: " + e);
                    return RunnersResponseHelper.CraftResponse(true,
                        RunnersResponseHelper.CreateBaseResponse(
                            "Cannot decrypt",
                            RunnersResponseHelper.StatusCode.DecryptionFailure,
                            0));
                }
                catch(JsonException e)
                {
                    // Deserialization failed
                    _logger.LogError("Deserialization failed! Details: "+ e);
                    return RunnersResponseHelper.CraftResponse(true,
                        RunnersResponseHelper.CreateBaseResponse(
                            "Cannot deserialize",
                            RunnersResponseHelper.StatusCode.RequestParamError,
                            0));
                }
            } else
            {
                paramData = JsonSerializer.Deserialize<LoginRequest>(param);
                if (paramData is null)
                    return RunnersResponseHelper.CraftResponse(true,
                        RunnersResponseHelper.CreateBaseResponse(
                            "!(paramData != null)",
                            RunnersResponseHelper.StatusCode.ServerSystemError,
                            0));
            }
            
            if(paramData.lineAuth.userId.Length == 0)
            {
                // registration - create a new account and return its info
                _logger.LogDebug("Entering Registration");
                // TODO: add actual logic here
                return RunnersResponseHelper.CraftResponse(true,
                RunnersResponseHelper.CreateBaseResponse(
                    "Account creation NYI",
                    RunnersResponseHelper.StatusCode.MissingPlayer,
                    0));
            }
            if (paramData.lineAuth.password.Length == 0)
            {
                // pre-login - search for user by ID and return key
                _logger.LogDebug("Entering Pre-Login");
                try
                {
                    Debug.Assert(context != null, nameof(context) + " != null");
                    var pkey = context.GetPlayerKey(paramData.lineAuth.userId);
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
            // login - use user id in conjunction with a password to create a session id
            _logger.LogDebug("Entering Login");
            _logger.LogDebug(paramData.lineAuth.password);
            Debug.Assert(context != null, nameof(context) + " != null");
            if (context.ValidatePassword(paramData.lineAuth.userId, paramData.lineAuth.password))
            {
                _logger.LogDebug("Successful login");
                var sessionId = context.CreateSessionID(Convert.ToUInt64(paramData.lineAuth.userId));
                var playerinfo = context.GetPlayerInfo(paramData.lineAuth.userId);
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
                _logger.LogDebug("Auth failed!");
                var pkey = context.GetPlayerKey(paramData.lineAuth.userId);
                LoginCheckKeyResponse response = new("Bad password", (int)RunnersResponseHelper.StatusCode.PassWordError)
                {
                    key = pkey
                };
                return RunnersResponseHelper.CraftResponse(true, response);
            }
        }

        [Route("getVariousParameter")]
        [HttpPost]
        public RunnersResponseMessage GetVariousParameter(string key, string param, int secure)
        {
            var context = HttpContext.RequestServices.GetService(typeof(OutrunDbContext)) as OutrunDbContext;
            BaseRequest paramData;
            if (secure == 1)
            {
                try
                {
                    paramData = RunnersRequestHelper.DecryptAndDeserializeParam<BaseRequest>(param, key);
                }
                catch (DecryptFailureException e)
                {
                    // Decryption failed
                    _logger.LogError("Decryption failed! Details: " + e);
                    return RunnersResponseHelper.CraftResponse(true,
                        RunnersResponseHelper.CreateBaseResponse(
                            "Cannot decrypt",
                            RunnersResponseHelper.StatusCode.DecryptionFailure,
                            0));
                }
                catch (JsonException e)
                {
                    // Deserialization failed
                    _logger.LogError("Deserialization failed! Details: " + e);
                    return RunnersResponseHelper.CraftResponse(true,
                        RunnersResponseHelper.CreateBaseResponse(
                            "Cannot deserialize",
                            RunnersResponseHelper.StatusCode.RequestParamError,
                            0));
                }
            }
            else
            {
                paramData = JsonSerializer.Deserialize<BaseRequest>(param);
                if (paramData is null)
                    return RunnersResponseHelper.CraftResponse(true,
                        RunnersResponseHelper.CreateBaseResponse(
                            "!(paramData != null)",
                            RunnersResponseHelper.StatusCode.ServerSystemError,
                            0));
            }

            Debug.Assert(context != null, nameof(context) + " != null");
            var playerId = context.CheckSessionID(paramData.sessionId);
            if (playerId.Length == 0)
                return RunnersResponseHelper.CraftResponse(true,
                    RunnersResponseHelper.CreateBaseResponse(
                        "Expired session",
                        RunnersResponseHelper.StatusCode.ExpirationSession,
                        0));
            // agnostic
            VariousParamsResponse response = new();
            return RunnersResponseHelper.CraftResponse(true, response);
        }
    }
}
