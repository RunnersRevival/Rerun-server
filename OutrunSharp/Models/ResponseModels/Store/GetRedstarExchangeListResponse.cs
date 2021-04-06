using OutrunSharp.Models.Obj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#pragma warning disable IDE1006 // Naming Styles

namespace OutrunSharp.Models.ResponseModels.Store
{
    public class GetRedstarExchangeListResponse : BaseResponse
    {
        public GetRedstarExchangeListResponse() : base()
        {
            SetItemList(new List<RedStarItem>());
            monthPurchase = 0;
            birthday = "2000-1-1";
        }
        public GetRedstarExchangeListResponse(string errMsg, int status) : base(errMsg, status)
        {
            SetItemList(new List<RedStarItem>());
            monthPurchase = 0;
            birthday = "2000-1-1";
        }

        public void SetItemList(List<RedStarItem> items)
        {
            itemList = items;
            totalItems = items.Count;
        }

        public List<RedStarItem> itemList { get; private set; } // this is expected to be zero-length in 2.0.3 and later if you don't want the RSR shop to show up
        public int totalItems { get; private set; }
        public int monthPurchase { get; set; }
        public string birthday { get; set; }
    }
}
