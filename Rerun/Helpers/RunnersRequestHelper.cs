using System;
using System.Text.Json;
using System.Text.RegularExpressions;
using Rerun.Exceptions;
using Rerun.Models;
using Rerun.Models.RequestModels;
using Rerun.Models.ResponseModels;

namespace Rerun.Helpers
{
    public static class RunnersRequestHelper
    {
        /// <summary>
        /// Decrypts and deserializes the param of a request.
        /// </summary>
        /// <param name="param">The request's param.</param>
        /// <param name="key">The IV that should be used for decryption.</param>
        /// <typeparam name="T">The request model type that should be used to deserialize param.</typeparam>
        /// <returns>An object of type T representing the param data.</returns>
        public static T DecryptAndDeserializeParam<T>(string param, string key)
        {
            var decryptedParam = Regex.Replace(Cryptor.DecryptText(param, key).Trim(), @"\p{C}+", string.Empty);
            return JsonSerializer.Deserialize<T>(decryptedParam);
        }

		public static (T, XeenResponseMessage) TryDecryptParam<T>(string key, string param, int secure)
			where T : BaseRequest
		{
			T paramData;
			if (secure == 1)
			{
				try
				{
					paramData = DecryptAndDeserializeParam<T>(param, key);
				}
				catch (DecryptFailureException e)
				{
					// Decryption failed
					if (e.InnerException is not null)
						return (null, RunnersResponseHelper.CraftResponse(true,
							RunnersResponseHelper.CreateBaseResponse(
								$"Cannot decrypt param: {e.InnerException.Message}",
								RunnersResponseHelper.StatusCode.DecryptionFailure,
								0)));
					else
						return (null, RunnersResponseHelper.CraftResponse(true,
							RunnersResponseHelper.CreateBaseResponse(
								$"Cannot decrypt param",
								RunnersResponseHelper.StatusCode.DecryptionFailure,
								0)));
				}
				catch (JsonException e)
				{
					// Deserialization failed
					return (null, RunnersResponseHelper.CraftResponse(true,
						RunnersResponseHelper.CreateBaseResponse(
							$"Cannot deserialize: {e.Message}",
							RunnersResponseHelper.StatusCode.RequestParamError,
							0)));
				}
				catch (Exception e)
				{
					// Something else went wrong
					return (null, RunnersResponseHelper.CraftResponse(true,
						RunnersResponseHelper.CreateBaseResponse(
							$"{e.GetType().Name} while processing request",
							RunnersResponseHelper.StatusCode.ServerSystemError,
							0)));
				}
			}
			else
			{
				paramData = JsonSerializer.Deserialize<T>(param);
				if (paramData is null)
					return (null, RunnersResponseHelper.CraftResponse(true,
						RunnersResponseHelper.CreateBaseResponse(
							"Assertion failed: !(paramData != null)",
							RunnersResponseHelper.StatusCode.ServerSystemError,
							0)));
			}
			return (paramData, null);
		}
    }
}
