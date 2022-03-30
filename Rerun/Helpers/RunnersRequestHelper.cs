using System.Text.Json;
using System.Text.RegularExpressions;

namespace Rerun.Helpers
{
    public class RunnersRequestHelper
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
    }
}
