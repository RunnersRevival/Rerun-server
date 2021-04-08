﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OutrunSharp.Helpers
{
    public class RunnersRequestHelper
    {
        public static T DecryptAndDeserializeParam<T>(string param, string key)
        {
            var decryptedParam = Regex.Replace(Cryptor.DecryptText(param, key).Trim(), @"\p{C}+", string.Empty);
            return JsonSerializer.Deserialize<T>(decryptedParam);
        }
    }
}
