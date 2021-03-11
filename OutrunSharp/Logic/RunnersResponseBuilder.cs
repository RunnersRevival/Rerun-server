﻿using OutrunSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;
using OutrunSharp.Models.ParamModels;

namespace OutrunSharp.Logic
{
    public class RunnersResponseBuilder
    {

		public enum StatusCode
		{
			Ok = 0,
			ServerSecurityError = -19001,
			VersionDifference = -19002,
			DecryptionFailure = -19003,
			ParamHashDifference = -19004,
			ServerNextVersion = -19990,
			ServerMaintenance = -19997,
			ServerBusyError = -19998,
			ServerSystemError = -19999,
			RequestParamError = -10100,
			NotAvailablePlayer = -10101,
			MissingPlayer = -10102,
			ExpirationSession = -10103,
			PassWordError = -10104,
			InvalidSerialCode = -10105,
			UsedSerialCode = -10106,
			HspWebApiError = -10110,
			ApolloWebApiError = -10115,
			DataMismatch = -30120,
			MasterDataMismatch = -10121,
			NotEnoughRedStarRings = -20130,
			NotEnoughRings = -20131,
			NotEnoughEnergy = -20132,
			RouletteUseLimit = -30401,
			RouletteBoardReset = -30411,
			CharacterLevelLimit = -20601,
			AllChaoLevelLimit = -20602,
			AlreadyInvitedFriend = -30801,
			AlreadyRequestedEnergy = -30901,
			AlreadySentEnergy = -30902,
			ReceiveFailureMessage = -30910,
			AlreadyExistedPrePurchase = -11001,
			AlreadyRemovedPrePurchase = -11002,
			InvalidReceiptData = -11003,
			AlreadyProcessedReceipt = -11004,
			EnergyLimitPurchaseTrigger = -21010,
			NotStartEvent = -10201,
			AlreadyEndEvent = -10202,
			UsernameInvalidChars = -31000,
			UsernameTooLong = -31001,
			UsernameHasNGWord = -31002,
			VersionForApplication = -999002,
			TimeOut = -7,
			OtherError = -8,
			NotReachability = -10,
			InvalidResponse = -20,
			CliendError = -400,
			InternalServerError = -500,
			HspPurchaseError = -600,
			ServerBusy = -700
		}

		public static RunnersResponseMessage CraftResponse(bool wantSecure, object responseObj)
        {
            short isSecure = 0;
            string aesKey = null;
            object outputParam = responseObj;
            if (wantSecure) {
                isSecure = 1;
                aesKey = System.Text.Encoding.Default.GetString(Cryptor.CryptoIV);
                outputParam = Cryptor.EncryptText(JsonSerializer.Serialize(responseObj));
            }
            return new RunnersResponseMessage
            {
                key = aesKey,
                param = outputParam,
                secure = isSecure
            };
        }

		public static object DecryptAndDeserializeParam(string param, string key)
        {
			string decryptedParam = Cryptor.DecryptText(param, key);
			return JsonSerializer.Deserialize<object>(decryptedParam);
		}

		public static BaseResponse CreateBaseResponse(string errMessage, StatusCode statusCode, int seq)
        {
			DateTimeOffset closeTime = DateTime.Now.AddTicks(-1).AddDays(1);
			long closeTimeUnix = closeTime.ToUnixTimeSeconds();
			return new BaseResponse
			{
				errorMessage = errMessage,
				statusCode = (int)statusCode,
				seq = seq.ToString(),
				serverTime = DateTimeOffset.Now.ToUnixTimeSeconds(),
				closeTime = closeTimeUnix
			};
		}
    }
}
