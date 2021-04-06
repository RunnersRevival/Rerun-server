using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

#pragma warning disable IDE1006 // Naming Styles

namespace OutrunSharp.Models.Obj
{
    public class Message
    {

        public string messageId { get; set; }
		public int messageType { get; set; } // possible values are in the MessageType enum
		public string friendId { get; set; } // user ID of the person who sent the message
		public string name { get; set; }
		public string url { get; set; } // unknown purpose
		public MessageItem item { get; set; }
		public long expireTime { get; set; } // unix timestamp
	}

	public enum MessageType
	{
		RequestEnergy = 0,
		ReturnRequestEnergy = 1,
		SendEnergy = 2,
		ReturnSendEnergy = 3,
		LentChao = 4,
		InviteCode = 5,
		Unknown = -1
	}

	public class MessageItem : Item
    {
		public MessageItem(string id, int amount) : base(id, amount)
        {
		}
        public MessageItem(string id, int amount, int extraInfo1, int extraInfo2) : base(id, amount)
        {
			additionalInfo1 = extraInfo1.ToString();
			additionalInfo2 = extraInfo2.ToString();
		}

		public string additionalInfo1 { get; set; }
		public string additionalInfo2 { get; set; }
	}
}
