using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutrunSharp.Models.ResponseModels
{
    public class MessageListResponse : BaseResponse
    {
        public MessageListResponse() : base()
        {
            SetMessageList(new List<Message>(), new List<OperatorMessage>());
        }
        public MessageListResponse(string errMsg, int status) : base(errMsg, status)
        {
            SetMessageList(new List<Message>(), new List<OperatorMessage>());
        }

        public void SetMessageList(List<Message> messages, List<OperatorMessage> operatorMessages)
        {
            messageList = messages;
            totalMessage = messages.Count;
            operatorMessageList = operatorMessages;
            totalOperatorMessage = operatorMessages.Count;
        }

        public List<Message> messageList { get; private set; }
        public int totalMessage { get; private set; }

        public List<OperatorMessage> operatorMessageList { get; private set; }
        public int totalOperatorMessage { get; private set; }
    }
}
