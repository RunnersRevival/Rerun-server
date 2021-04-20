using System;

// ReSharper disable InconsistentNaming
#pragma warning disable IDE1006 // Naming Styles

namespace OutrunSharp.Models.Obj
{
    public class MapState
    {
        public MapState()
        {
            episode = 1;
            chapter = 1;
            point = 0;
            stageTotalScore = 0;
            chapterStartTime = DateTimeOffset.Now.ToUnixTimeSeconds();
        }
        public int episode { get; set; }
        public int chapter { get; set; }
        public int point { get; set; } // value from 0 to 5, depending on which point you've reached
        public long stageTotalScore { get; set; }
        public long chapterStartTime { get; set; } // unix timestamp indicating when the chapter has started, for limited time item durations
    }
}
