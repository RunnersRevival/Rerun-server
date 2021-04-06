using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OutrunSharp.Exceptions;
using OutrunSharp.Helpers;
using OutrunSharp.Models;
using OutrunSharp.Models.DbModels;
using OutrunSharp.Models.Obj;
using OutrunSharp.Models.RequestModels;
using OutrunSharp.Models.RequestModels.Store;
using OutrunSharp.Models.ResponseModels.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace OutrunSharp.Controllers
{
    public class StoreController : Controller
    {
        private readonly ILogger<StoreController> _logger;

        public StoreController(ILogger<StoreController> logger)
        {
            _logger = logger;
        }

        [Route("Store/getRedstarExchangeList")]
        [HttpPost]
        public RunnersResponseMessage GetRedStarExchangeList(string key, string param, int secure)
        {
            OutrunDbContext context = HttpContext.RequestServices.GetService(typeof(OutrunDbContext)) as OutrunDbContext;
            GetRedstarExchangeListRequest paramData;
            if (secure == 1)
            {
                try
                {
                    paramData = RunnersRequestHelper.DecryptAndDeserializeParam<GetRedstarExchangeListRequest>(param, key);
                }
                catch (DecryptFailureException e)
                {
                    // Decryption failed
                    _logger.LogError("Decryption failed! Details: " + e.ToString());
                    return RunnersResponseHelper.CraftResponse(true,
                        RunnersResponseHelper.CreateBaseResponse(
                            "Cannot decrypt",
                            RunnersResponseHelper.StatusCode.DecryptionFailure,
                            0));
                }
                catch (JsonException e)
                {
                    // Deserialization failed
                    _logger.LogError("Deserialization failed! Details: " + e.ToString());
                    return RunnersResponseHelper.CraftResponse(true,
                        RunnersResponseHelper.CreateBaseResponse(
                            "Cannot deserialize",
                            RunnersResponseHelper.StatusCode.RequestParamError,
                            0));
                }
            }
            else
            {
                paramData = JsonSerializer.Deserialize<GetRedstarExchangeListRequest>(param);
            }
            string playerId = context.CheckSessionID(paramData.sessionId);
            if (playerId.Length != 0)
            {
                GetRedstarExchangeListResponse response = new();
                switch (int.Parse(paramData.itemType))
                {
                    case 0:
                        response.SetItemList(RedStarExchangeDefaults.DefaultRedStarItems0);
                        break;
                    case 1:
                        response.SetItemList(RedStarExchangeDefaults.DefaultRedStarItems1);
                        break;
                    case 2:
                        response.SetItemList(RedStarExchangeDefaults.DefaultRedStarItems2);
                        break;
                    case 4:
                        response.SetItemList(RedStarExchangeDefaults.DefaultRedStarItems4);
                        break;
                    default:
                        return RunnersResponseHelper.CraftResponse(true,
                            RunnersResponseHelper.CreateBaseResponse(
                                "Invalid itemType",
                                RunnersResponseHelper.StatusCode.ClientError,
                                0));
                }
                return RunnersResponseHelper.CraftResponse(true, response);
            }
            else
            {
                return RunnersResponseHelper.CraftResponse(true,
                    RunnersResponseHelper.CreateBaseResponse(
                        "Expired session",
                        RunnersResponseHelper.StatusCode.ExpirationSession,
                        0));
            }
        }
    }
}
