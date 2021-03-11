using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutrunSharp.Models
{
    public class PlayCharacter
    {
        public string characterId { get; set; }
        public int star { get; set; } // current limit break level
        public int starMax { get; set; } // maximum limit break level (usually 10)
        public int priceNumRings { get; set; } // set to 0 to not be purchasable with rings
        public int priceNumRedRings { get; set; } // set to 0 to not be purchasable with red rings
    }
    public class Character : PlayCharacter
    {
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
}
