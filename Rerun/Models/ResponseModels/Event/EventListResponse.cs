using System.Collections.Generic;

// ReSharper disable InconsistentNaming
#pragma warning disable IDE1006 // Naming Styles

namespace Rerun.Models.ResponseModels.Event
{
    public class EventListResponse : BaseResponse
    {
        public EventListResponse() : base()
        {
            eventList = new List<Obj.Event>();
        }

        public EventListResponse(string errMsg, int status) : base(errMsg, status)
        {
            eventList = new List<Obj.Event>();
        }

        public List<Obj.Event> eventList { get; set; }
    }
}
