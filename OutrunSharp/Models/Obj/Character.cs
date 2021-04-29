using System;

// ReSharper disable InconsistentNaming
#pragma warning disable IDE1006 // Naming Styles

namespace OutrunSharp.Models.Obj
{
    public class PlayCharacter
    {
        public PlayCharacter(string id)
        {
            characterId = id;
            star = 0;
            starMax = 10;
            priceNumRings = 120000;
            priceNumRedRings = 100;
        }
        public string characterId { get; set; }
        public int star { get; set; } // current limit break level
        public int starMax { get; set; } // maximum limit break level (usually 10)
        public int priceNumRings { get; set; } // set to 0 to not be purchasable with rings
        public int priceNumRedRings { get; set; } // set to 0 to not be purchasable with red rings
    }
    public class Character : PlayCharacter
    {
        public Character(string id) : base(id)
        {
            status = CharacterStatus.CharacterStatusUnlocked;
            level = 0;
            exp = 0;
            abilityLevel = new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            abilityNumRings = new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            abilityLevelup = Array.Empty<int>();
            abilityLevelupExp = Array.Empty<int>();
        }
        public CharacterStatus status { get; set; }
        public int level { get; set; }
        public int exp { get; set; }
        public int[] abilityLevel { get; set; }
        public int[] abilityNumRings { get; set; }
        public int[] abilityLevelup { get; set; }
        public int[] abilityLevelupExp { get; set; }
    }

    public enum CharacterStatus
    {
        CharacterStatusLocked,
        CharacterStatusUnlocked,
        CharacterStatusMaxLevel
    }

    public enum CharaIDs
    {
        Sonic = 300000, // core
        Tails, // core
        Knuckles, // core
        Amy,
        Shadow,
        Blaze,
        Rouge,
        Omega,
        Big, // easy
        Cream, // easy
        Espio, // chaotix
        Charmy, // chaotix
        Vector, // chaotix
        Silver, // easy
        MetalSonic,
        ClassicSonic, // birthday event
        Werehog, // sonic unleashed event
        Sticks,
        Tikal, // sonic adventure event
        Mephiles, // sonic wars/forces event?
        PSISilver,
        Chara0021, // 2.0.4 launch event
        Chara0022, // ??? event
        Chara0023, // ??? event
        Chara0024, // ??? event
        Chara0025, // TBD
        Chara0026, // TBD
        Chara0027, // TBD
        Chara0028, // TBD
        Chara0029, // TBD
        Chara0030, // TBD

        // special event characters
        AmitieAmy = 301000,
        GothicAmy,
        HalloweenShadow,
        HalloweenRouge,
        HalloweenOmega,
        XMasSonic,
        XMasTails,
        XMasKnuckles,
    }
}
