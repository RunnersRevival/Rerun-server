
// ReSharper disable InconsistentNaming
#pragma warning disable IDE1006 // Naming Styles

namespace Rerun.Models.Obj
{
    public class Item
    {
        public Item(string id, int amount)
        {
            itemId = id;
            numItem = amount.ToString();
        }
        public string itemId { get; set; }
        public string numItem { get; set; }
    }

    public enum ItemIDs
    {
        ItemIDBoostScore = 110000,
        ItemIDBoostTrampoline,
        ItemIDBoostSubChara,

        ItemIDInvincible = 120000,
        ItemIDBarrier, // Shield
        ItemIDMagnet,
        ItemIDTrampoline, // Springs
        ItemIDCombo,
        ItemIDLaser,
        ItemIDDrill,
        ItemIDAsteroid,
        ItemIDRingBonus,
        ItemIDDistanceBonus,
        ItemIDAnimalBonus,

        ItemIDChaoRouletteTicket = 230000,
        ItemIDRouletteTicket = 240000,
        ItemIDRaidBossRouletteTicket = 250000,
        ItemIDEventRouletteTicket = 260000, // event roulette apparently didn't make it into any events...?

        ItemIDRedRing = 900000,
        ItemIDRing = 910000,
        ItemIDEnergy = 920000,

        ItemIDContinue = 950000,
        ItemIDDailyBattleReset = 980000,  // not clear what this one's used for, if at all
        ItemIDDailyBattleReset1 = 980001, // find new opponent
        ItemIDDailyBattleReset2 = 980002, // find beatable opponent
    }
}
