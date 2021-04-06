using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutrunSharp.Models.ResponseModels.Message
{
    public class MessageListResponse : BaseResponse
    {
        public MessageListResponse() : base()
        {
            SetMessageList(new List<Obj.Message>(), new List<Obj.OperatorMessage>());
        }
        public MessageListResponse(string errMsg, int status) : base(errMsg, status)
        {
            SetMessageList(new List<Obj.Message>(), new List<Obj.OperatorMessage>());
        }

        public void SetMessageList(List<Obj.Message> messages, List<Obj.OperatorMessage> operatorMessages)
        {
            messageList = messages;
            totalMessage = messages.Count;
            operatorMessageList = operatorMessages;
            totalOperatorMessage = operatorMessages.Count;
        }

        public List<Obj.Message> messageList { get; private set; }
        public int totalMessage { get; private set; }

        public List<Obj.OperatorMessage> operatorMessageList { get; private set; }
        public int totalOperatorMessage { get; private set; }
    }
}
