using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#pragma warning disable IDE1006 // Naming Styles

namespace OutrunSharp.Models.Obj
{
    public class OperatorMessage
    {
        public string messageId { get; set; }
        public string content { get; set; } // description shown for the gift
        public MessageItem item { get; set; }
        public long expireTime { get; set; } // unix timestamp
    }
}
