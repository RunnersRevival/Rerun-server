
// ReSharper disable InconsistentNaming
#pragma warning disable IDE1006 // Naming Styles

namespace OutrunSharp.Models.Obj
{
    public class ConsumedItem : Item
    {
        public ConsumedItem(string id, int price, string consumableItemId) : base(id, price)
        {
            consumedItemId = consumableItemId;
        }

        public string consumedItemId { get; set; }
    }
}
