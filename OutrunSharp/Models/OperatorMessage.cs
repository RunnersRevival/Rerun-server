using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutrunSharp.Models
{
    public class OperatorMessage
    {
        public string messageId { get; set; }
        public string content { get; set; } // description shown for the gift
        public MessageItem item { get; set; }
        public long expireTime { get; set; } // unix timestamp
    }
}
