using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace OutrunSharp.Helpers
{
    public class RunnersRequestHelper
    {
        public static T DecryptAndDeserializeParam<T>(string param, string key)
        {
            string decryptedParam = Cryptor.DecryptText(param, key).Trim();
            return JsonSerializer.Deserialize<T>(decryptedParam);
        }
    }
}
