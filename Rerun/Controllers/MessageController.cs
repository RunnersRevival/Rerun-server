﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rerun.Exceptions;
using Rerun.Helpers;
using Rerun.Models;
using Rerun.Models.DbModels;
using Rerun.Models.RequestModels;
using Rerun.Models.ResponseModels.Message;
using System.Diagnostics;
using System.Text.Json;

namespace Rerun.Controllers
{
    // These endpoints cover the present box.
    [Route("Message")]
    public class MessageController : Controller
    {
        private readonly ILogger<MessageController> _logger;

        public MessageController(ILogger<MessageController> logger) => _logger = logger;

        [Route("getMessageList")]
        [HttpPost]
        public XeenResponseMessage GetMessageList(string key, string param, int secure)
        {
            var context = HttpContext.RequestServices.GetService(typeof(OutrunDbContext)) as OutrunDbContext;
            var (paramData, errorResponseMsg) = RunnersRequestHelper.TryDecryptParam<BaseRequest>(key, param, secure);
            if (errorResponseMsg is not null) return errorResponseMsg; // something went wrong

            Debug.Assert(context != null, nameof(context) + " != null");
            var playerId = context.CheckSessionID(paramData.sessionId);
            if (playerId.Length == 0)
                return RunnersResponseHelper.CraftResponse(true,
                    RunnersResponseHelper.CreateBaseResponse(
                        "Expired session",
                        RunnersResponseHelper.StatusCode.ExpirationSession,
                        int.Parse(paramData.seq)));
            MessageListResponse response = new()
            {
                seq = paramData.seq
            };
            return RunnersResponseHelper.CraftResponse(true, response);
        }
    }
}
