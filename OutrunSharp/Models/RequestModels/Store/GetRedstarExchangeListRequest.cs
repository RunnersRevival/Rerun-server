using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#pragma warning disable IDE1006 // Naming Styles

namespace OutrunSharp.Models.RequestModels.Store
{
    public class GetRedstarExchangeListRequest : BaseRequest
    {
        public string itemType { get; set; } // convert string into int
    }
}
