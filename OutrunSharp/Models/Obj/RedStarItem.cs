using System.Collections.Generic;

#pragma warning disable IDE1006 // Naming Styles

namespace OutrunSharp.Models.Obj
{
    public class RedStarItem
    {
        public string storeItemId { get; set; }
        public string itemId { get; set; }
        public string priceDisp { get; set; }
        public string productId { get; set; }
        public int numItem { get; set; }
        public int price { get; set; }
    }

    public class RedStarExchangeDefaults
    {
        public static readonly List<RedStarItem> DefaultRedStarItems0 = new(); // red star rings - not used
        public static readonly List<RedStarItem> DefaultRedStarItems1 = new() // rings
        {
            new RedStarItem
            {
                storeItemId = "915001",
                itemId = "910000",
                numItem = 20000,
                price = 10
            },
            new RedStarItem
            {
                storeItemId = "915002",
                itemId = "910000",
                numItem = 42000,
                price = 20
            },
            new RedStarItem
            {
                storeItemId = "915003",
                itemId = "910000",
                numItem = 108000,
                price = 50
            },
            new RedStarItem
            {
                storeItemId = "915004",
                itemId = "910000",
                numItem = 224000,
                price = 100
            },
            new RedStarItem
            {
                storeItemId = "915005",
                itemId = "910000",
                numItem = 600000,
                price = 250
            }
        };
        public static readonly List<RedStarItem> DefaultRedStarItems2 = new() // revive tokens
        {
            new RedStarItem
            {
                storeItemId = "920005",
                itemId = "920000",
                numItem = 5,
                price = 10
            },
            new RedStarItem
            {
                storeItemId = "920020",
                itemId = "920000",
                numItem = 20,
                price = 35
            },
            new RedStarItem
            {
                storeItemId = "920030",
                itemId = "920000",
                numItem = 30,
                price = 50
            },
            new RedStarItem
            {
                storeItemId = "920050",
                itemId = "920000",
                numItem = 50,
                price = 80
            },
            new RedStarItem
            {
                storeItemId = "920100",
                itemId = "920000",
                numItem = 100,
                price = 150
            }
        };
        public static readonly List<RedStarItem> DefaultRedStarItems4 = new() // boss challenge tokens
        {
            new RedStarItem
            {
                storeItemId = "940005",
                itemId = "940000",
                numItem = 5,
                price = 10
            },
            new RedStarItem
            {
                storeItemId = "940020",
                itemId = "940000",
                numItem = 20,
                price = 35
            },
            new RedStarItem
            {
                storeItemId = "940030",
                itemId = "940000",
                numItem = 30,
                price = 50
            },
            new RedStarItem
            {
                storeItemId = "940050",
                itemId = "940000",
                numItem = 50,
                price = 80
            },
            new RedStarItem
            {
                storeItemId = "940100",
                itemId = "940000",
                numItem = 100,
                price = 150
            }
        };
    }
}
