using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutrunSharp.Models
{
    public class RunnersResponseMessage
    {
        public string key { get; set; } // AES decryption key, if necessary
        public object param { get; set; } // type depends on the value of secure: if it's 0, it can be a JSON array; if it's 1, it's a string containing the encrypted JSON data
        public short secure { get; set; } // indicates whether AES encryption is used in response
    }
}
