using System;

// ReSharper disable InconsistentNaming
#pragma warning disable IDE1006 // Naming Styles

namespace Rerun.Models.Obj
{
    public class Event
    {
        public Event(int evType, int evId)
        {
            if (evId is < 0 or > 9999)
                throw new ArgumentOutOfRangeException(nameof(evId));
            if (evType < 0)
                throw new ArgumentOutOfRangeException(nameof(evType));
            eventId = evType * 10000 + evId;
            eventType = evType;
        }
        public long eventId { get; } // this is apparently used to get the event type
        public int eventType { get; } // isn't used in game, but required

        // base the below on the current timezone of the server!
        public long eventStartTime { get; set; } // unix timestamp marking the start time of the event
        public long eventEndTime { get; set; } // unix timestamp marking the end time of the event
        public long eventCloseTime { get; set; } // unix timestamp marking the server time the event closes
    }

    public enum EventTypes
    {
        EventTypeSpecialStage = 1,  // Broken in 2.0 (and fixed in 2.2), provided a special endless stage and special event objects to collect
        EventTypeRaidBoss,          // Broken in 2.0 (and fixed in 2.2, but not reintroduced yet), a boss would strike randomly, and you and other people have to face off against it
        EventTypeCollectObject,     // Partially broken in 2.0 (and fixed in 2.2), a notable example is the Animal Rescue Event
        EventTypeGacha,             // Showcase buddies on the roulette for a limited time - it seems Sonic Team was working on a minor revamp for this type for 2.0 but never finished it; it has been restored for 2.2 however
        EventTypeAdvert,            // Like gacha, but without new music? Needs to be documented better.
        EventTypeQuick,             // Introduced in 2.0, provided a limited-time quick mode stage
        EventTypeBGM                // Introduced in 2.0, replaced some tracks in-game with event-specific tracks
    }
}
