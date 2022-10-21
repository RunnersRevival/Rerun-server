using Rerun.Models;
using System;
using System.Text.Json;
using Rerun.Models.ResponseModels;

namespace Rerun.Helpers
{
    public static class RunnersResponseHelper
    {

		public enum StatusCode
        {
            /// <summary>Returned to the client when no error has occurred.</summary>
            Ok = 0,
            /// <summary>Returned to the client when a security error has occurred.</summary>
			ServerSecurityError = -19001,
            /// <summary>Returned to the client when the Rerun version and the client version don't match.</summary>
			VersionDifference = -19002, // server/client version mismatch
            /// <summary>Returned to the client when the param was unable to be decrypted, likely due to a key mismatch.</summary>
            DecryptionFailure = -19003,
            /// <summary>Returned to the client when the client's key was not what was expected.</summary>
			ParamHashDifference = -19004,
			/// <summary>Returned to the client when the server is in maintenance mode in preparation for a new client version.</summary>
			ServerNextVersion = -19990, // show next version maintenance window
            /// <summary>Returned to the client when the game server is undergoing maintenance.</summary>
			ServerMaintenance = -19997,
            /// <summary>Returned to the client when the game server is too busy to handle requests at this time.</summary>
			ServerBusyError = -19998,
            /// <summary>Returned to the client when the game server encounters a system error.</summary>
			ServerSystemError = -19999,
            /// <summary>Returned to the client when the param was unable to be deserialized.</summary>
			RequestParamError = -10100,

            #region Login/Session Status Codes
            /// <summary>Returned to the client when the requested player ID is not available at this time.</summary>
            NotAvailablePlayer = -10101,
            /// <summary>Returned to the client when the requested player ID does not exist.</summary>
			MissingPlayer = -10102,
            /// <summary>Returned to the client when the session ID expired.</summary>
            /// <remarks>There seems to be a bug in the client where it will not attempt to create a new login session when this error code is returned until the session was supposed to expire. This results in a partial hang.</remarks>
			ExpirationSession = -10103,
            /// <summary>Returned to the client when the incorrect password was provided.</summary>
            PassWordError = -10104,
            /// <summary>Returned to the client when the seq number does not match what is expected for the current session.</summary>
            SequenceIDError = -10107, // Not yet fully implemented.
            #endregion

            #region Atom Serial Status Codes
            /// <summary>Returned to the client when the specified Atom serial is invalid.</summary>
            InvalidSerialCode = -10105,
            /// <summary>Returned to the client when the specified Atom serial has already been used.</summary>
			UsedSerialCode = -10106,
            #endregion

            #region Web API Status Codes
            /// <summary>Returned to the client when an error occurs during communication with the HSP web API.</summary>
            HspWebApiError = -10110,
            /// <summary>Returned to the client when an error occurs during communication with the Apollo web API.</summary>
			ApolloWebApiError = -10115,
            #endregion

            #region Data Mismatch Status Codes
            DataMismatch = -30120,
			MasterDataMismatch = -10121,
            #endregion

            #region Insufficient Currency Status Codes
            /// <summary>Returned to the client when the player does not have enough red star rings for the specified operation.</summary>
            /// <remarks>This error code will be displayed to the user if the client-side check fails for whatever reason.</remarks>
            NotEnoughRedStarRings = -20130,
            /// <summary>Returned to the client when the player does not have enough rings for the specified operation.</summary>
            /// <remarks>This error code will be displayed to the user if the client-side check fails for whatever reason.</remarks>
			NotEnoughRings = -20131,
            /// <summary>Returned to the client when the player does not have enough energy for the specified operation.</summary>
            /// <remarks>This error code will be displayed to the user if the client-side check fails for whatever reason.</remarks>
			NotEnoughEnergy = -20132,
            /// <summary>Returned to the client when the player does not have enough boss challenge tokens for the specified operation.</summary>
            /// <remarks>This error code will be displayed to the user if the client-side check fails for whatever reason.</remarks>
			NotEnoughChallenge = -20133,
            #endregion

            #region Roulette Status Codes
            /// <summary>Returned to the client when there are no more free spins and the player has no roulette tickets.</summary>
            /// <remarks>This error code will be displayed to the user if the client-side check fails for whatever reason.</remarks>
            RouletteUseLimit = -30401,
            /// <summary>Returned to the client when the roulette board was reset.</summary>
			RouletteBoardReset = -30411,
            /// <summary>Returned to the client when a character is maxed out.</summary>
			CharacterLevelLimit = -20601,
            /// <summary>Returned to the client when every single character and Chao is maxed out on the current account.</summary>
			AllChaoLevelLimit = -20602,
            #endregion

            #region Friend Status Codes
            AlreadyInvitedFriend = -30801,
            /// <summary>Returned to the client when an energy request has already been sent.</summary>
			AlreadyRequestedEnergy = -30901,
            /// <summary>Returned to the client when the specified friend has already received energy.</summary>
			AlreadySentEnergy = -30902,
            /// <summary>Returned to the client when gift receiving failed for whatever reason.</summary>
			ReceiveFailureMessage = -30910,
            #endregion

            #region IAP Status Codes
            AlreadyExistedPrePurchase = -11001,
			AlreadyRemovedPrePurchase = -11002,
			InvalidReceiptData = -11003,
			AlreadyProcessedReceipt = -11004,
			EnergyLimitPurchaseTrigger = -21010,
			AmountExceedingLimit = -31001,
            #endregion

            #region Event Status Codes
            /// <summary>Returned to the client when the specified event has not started yet (or is invalid).</summary>
            NotStartEvent = -10201,
            /// <summary>Returned to the client when the specified event has already ended.</summary>
			AlreadyEndEvent = -10202,
            #endregion

            #region Username Status Codes
            UsernameInvalidChars = -40000, // for 2.1.0 and later
			UsernameTooLong = -40001, // for 2.1.0 and later
			UsernameHasNGWord = -40002, // for 2.1.0 and later
            #endregion

            #region Internal Use Status Codes
            /// <summary>Returned to the client when the current client version needs to use the Application server instead of the Release or Staging servers.</summary>
            VersionForApplication = -999002,
			#endregion

			/// <summary>The client internally sets this code if the request timed out.</summary>
			TimeOut = -7,
			OtherError = -8,
			NotReachability = -10,
			InvalidResponse = -20,
            /// <summary>The client internally sets this code if HTTP 4xx codes are returned.</summary>
			ClientError = -400,
            /// <summary>The client internally sets this code if HTTP 5xx codes are returned.</summary>
			InternalServerError = -500,
			HspPurchaseError = -600,
			ServerBusy = -700
		}

        /// <summary>
        /// Crafts a response message, optionally serializing and encrypting the param data.
        /// </summary>
        /// <param name="wantSecure">If true, the param will be serialized and encrypted.</param>
        /// <param name="responseObj">The object which represents the param data.</param>
        /// <returns>A XeenResponseMessage representing the response to send to the client.</returns>
		public static XeenResponseMessage CraftResponse(bool wantSecure, object responseObj)
        {
            short isSecure = 0;
            var outputParam = responseObj;
			// TODO: ensure that every value in every key-value pair in param is a string; game doesn't like it if you send non-string values
            if (!wantSecure)
                return new XeenResponseMessage
                {
                    key = null,
                    param = outputParam,
                    secure = isSecure
                };
            isSecure = 1;
            var aesKey = System.Text.Encoding.Default.GetString(Cryptor.GetCryptoIV());
            outputParam = Cryptor.EncryptText(JsonSerializer.Serialize(responseObj));
            return new XeenResponseMessage
            {
                key = aesKey,
                param = outputParam,
                secure = isSecure
            };
        }

        /// <summary>
        /// Creates a BaseResponse with the specified error message, status code, and sequence number.
        /// </summary>
        /// <param name="errMessage">An error message string, primarily used for debugging.</param>
        /// <param name="statusCode">The numerical status code to return.</param>
        /// <param name="seq">The current sequence number. Ideally this would be incremented for every request.</param>
        /// <returns>A BaseResponse with the specified data.</returns>
		public static BaseResponse CreateBaseResponse(string errMessage, StatusCode statusCode, int seq)
        {
			DateTimeOffset closeTime = DateTime.Now.AddTicks(-1).AddDays(1);
			var closeTimeUnix = closeTime.ToUnixTimeSeconds();
			return new BaseResponse
			{
				errorMessage = errMessage,
				statusCode = (int)statusCode,
				seq = seq.ToString(),
				serverTime = DateTimeOffset.Now.ToUnixTimeSeconds(),
				closeTime = closeTimeUnix,
				// TODO: Make the below options configurable!
				assets_version = "051",
				client_data_version = "2.2.2",
				data_version = "15",
				info_version = "017",
				version = "2.2.2"
			};
		}
    }
}
