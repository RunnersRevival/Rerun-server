using OutrunSharp.Models.Obj;
using System.Collections.Generic;

// ReSharper disable InconsistentNaming
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

        public List<RedStarItem> itemList { get; private set; } // this is expected to be zero-length in the case of the RSR list in 2.0.3 and later if you don't want the RSR shop to show up - having it zero length in earlier versions just softlocks the game when going into the shop
        public int totalItems { get; private set; } // length of itemList
        public int monthPurchase { get; set; }
        public string birthday { get; set; } // normally this would be set to the stored birthday in the server-side user data, but we kinda don't do that
    }
}
