﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rerun.Exceptions;
using Rerun.Helpers;
using Rerun.Models;
using Rerun.Models.DbModels;
using Rerun.Models.Obj;
using Rerun.Models.RequestModels.Store;
using Rerun.Models.ResponseModels.Store;
using System.Diagnostics;
using System.Text.Json;

namespace Rerun.Controllers
{
    // These endpoints cover shop-related operations
    [Route("Store")]
    public class StoreController : Controller
    {
        private readonly ILogger<StoreController> _logger;

        public StoreController(ILogger<StoreController> logger) => _logger = logger;

        [Route("getRedstarExchangeList")]
        [HttpPost]
        public XeenResponseMessage GetRedStarExchangeList(string key, string param, int secure)
        {
            var context = HttpContext.RequestServices.GetService(typeof(OutrunDbContext)) as OutrunDbContext;
            var (paramData, errorResponseMsg) = RunnersRequestHelper.TryDecryptParam<GetRedstarExchangeListRequest>(key, param, secure);
            if (errorResponseMsg is not null) return errorResponseMsg; // something went wrong

            Debug.Assert(context != null, nameof(context) + " != null");
            var playerId = context.CheckSessionID(paramData.sessionId);
            if (playerId.Length == 0)
                return RunnersResponseHelper.CraftResponse(true,
                    RunnersResponseHelper.CreateBaseResponse(
                        "Expired session",
                        RunnersResponseHelper.StatusCode.ExpirationSession,
                        int.Parse(paramData.seq)));
            GetRedstarExchangeListResponse response = new()
            {
                seq = paramData.seq
            };
            switch (int.Parse(paramData.itemType))
            {
                case 0: // red star rings
                    response.SetItemList(RedStarExchangeDefaults.DefaultRedStarItems0);
                    break;
                case 1: // rings
                    response.SetItemList(RedStarExchangeDefaults.DefaultRedStarItems1);
                    break;
                case 2: // revive tokens
                    response.SetItemList(RedStarExchangeDefaults.DefaultRedStarItems2);
                    break;
                case 4: // boss challenge tokens
                    response.SetItemList(RedStarExchangeDefaults.DefaultRedStarItems4);
                    break;
                default:
                    return RunnersResponseHelper.CraftResponse(true,
                        RunnersResponseHelper.CreateBaseResponse(
                            "Invalid itemType",
                            RunnersResponseHelper.StatusCode.ClientError,
                            int.Parse(paramData.seq)));
            }
            return RunnersResponseHelper.CraftResponse(true, response);
        }
    }
}
