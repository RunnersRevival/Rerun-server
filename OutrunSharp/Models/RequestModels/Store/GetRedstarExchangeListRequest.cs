

// ReSharper disable InconsistentNaming
#pragma warning disable IDE1006 // Naming Styles

namespace OutrunSharp.Models.RequestModels.Store
{
    public class GetRedstarExchangeListRequest : BaseRequest
    {
        public string itemType { get; set; } // convert string into int
    }
}
