using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutrunSharp.Models
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
        ItemIDEventRouletteTicket = 260000,

        ItemIDRedRing = 900000,
        ItemIDRing = 910000,
        ItemIDEnergy = 920000,
    }
}
