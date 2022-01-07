using System;

// ReSharper disable InconsistentNaming
#pragma warning disable IDE1006 // Naming Styles

namespace Rerun.Models.Obj
{
    public class Information
    {
        public Information()
        {
            id = 1;
            priority = 1;
            start = DateTimeOffset.Now.ToUnixTimeSeconds();
            end = DateTimeOffset.Now.AddDays(1).ToUnixTimeSeconds();
            SetContent(InfoDisplayType.FullTime, "This is a test information. Welcome to OutrunSharp!", "10600001", InfoType.Text, "~");
        }

        public Information(InfoDisplayType displayType, string message, string imageID, InfoType infoType, string extra)
        {
            id = 1;
            priority = 1;
            start = DateTimeOffset.Now.ToUnixTimeSeconds();
            end = DateTimeOffset.Now.AddDays(1).ToUnixTimeSeconds();
            SetContent(displayType, message, imageID, infoType, extra);
        }

        public long id { get; set; }
        public int priority { get; set; } // for arranging them on the information list screen
        public long start { get; set; }
        public long end { get; set; }
        public string param { get; private set; }

        public void SetContent(InfoDisplayType displayType, string message, string imageID, InfoType infoType, string extra)
        {
            param = ((int)displayType).ToString();
            param += "_" + message;
            param += "_" + imageID;
            param += "_" + (int)infoType;
            param += "_" + extra;
        }
    }

    public enum InfoDisplayType
    {
        EveryDay,
        Once,
        FullTime,
        OnlyInfoPage
    }

    public enum InfoType
    {
        Text,
        Image,
        Feed, // share button
        ShopCancel,
        FeedURL,
        FeedRoulette,
        FeedShop,
        FeedEvent,
        FeedEventList,
        URL,
        Roulette,
        Shop,
        Event,
        EventList,
        RouletteInfo,
        QuickInfo, // timed mode banner
        CountryText,
        CountryImage
    }
}
