using Microsoft.AspNetCore.Mvc;
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
        public RunnersResponseMessage GetRedStarExchangeList(string key, string param, int secure)
        {
            var context = HttpContext.RequestServices.GetService(typeof(OutrunDbContext)) as OutrunDbContext;
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
                paramData = JsonSerializer.Deserialize<GetRedstarExchangeListRequest>(param);
                if (paramData is null)
                    return RunnersResponseHelper.CraftResponse(true,
                        RunnersResponseHelper.CreateBaseResponse(
                            "Assertion failed: !(paramData != null)",
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
    }
}
