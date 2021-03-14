using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace OutrunSharp.Models
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
            abilityLevel = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            abilityNumRings = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            abilityLevelup = new int[] { };
            abilityLevelupExp = new int[] { };
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

        // special event characters
        AmitieAmy = 301000,
        GothicAmy,
        HalloweenShadow,
        HalloweenBlaze,
        HalloweenRouge,
        XMasSonic,
        XMasTails,
        XMasKnuckles,
    }
}
