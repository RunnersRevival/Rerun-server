using System.Collections.Generic;

// ReSharper disable InconsistentNaming
#pragma warning disable IDE1006 // Naming Styles

namespace Rerun.Models.ResponseModels.Information
{
    public class TickerResponse : BaseResponse
    {
        public TickerResponse() : base()
        {
            tickerList = new List<Obj.Ticker>();
        }
        public TickerResponse(string errMsg, int status) : base(errMsg, status)
        {
            tickerList = new List<Obj.Ticker>();
        }

        public List<Obj.Ticker> tickerList { get; set; }
    }
}
