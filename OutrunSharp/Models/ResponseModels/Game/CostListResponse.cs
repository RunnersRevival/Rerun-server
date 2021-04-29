using OutrunSharp.Models.Obj;
using System;
using System.Collections.Generic;

// ReSharper disable InconsistentNaming
#pragma warning disable IDE1006 // Naming Styles

namespace OutrunSharp.Models.ResponseModels.Game
{
    public class CostListResponse : BaseResponse
    {
        public CostListResponse() : base()
        {
            consumedCostList = DefaultCostList;
        }
        public CostListResponse(string errMsg, int status) : base(errMsg, status)
        {
            consumedCostList = DefaultCostList;
        }

        private readonly List<ConsumedItem> DefaultCostList = new()
        {
            // boosters
            new ConsumedItem(((int)ItemIDs.ItemIDBoostScore).ToString(), 6000, ((int)ItemIDs.ItemIDRing).ToString()),
            new ConsumedItem(((int)ItemIDs.ItemIDBoostTrampoline).ToString(), 1000, ((int)ItemIDs.ItemIDRing).ToString()),
            new ConsumedItem(((int)ItemIDs.ItemIDBoostSubChara).ToString(), 4000, ((int)ItemIDs.ItemIDRing).ToString()),

            // items
            new ConsumedItem(((int)ItemIDs.ItemIDInvincible).ToString(), 3000, ((int)ItemIDs.ItemIDRing).ToString()),
            new ConsumedItem(((int)ItemIDs.ItemIDBarrier).ToString(), 1000, ((int)ItemIDs.ItemIDRing).ToString()),
            new ConsumedItem(((int)ItemIDs.ItemIDMagnet).ToString(), 3000, ((int)ItemIDs.ItemIDRing).ToString()),
            new ConsumedItem(((int)ItemIDs.ItemIDTrampoline).ToString(), 2000, ((int)ItemIDs.ItemIDRing).ToString()),
            new ConsumedItem(((int)ItemIDs.ItemIDCombo).ToString(), 3000, ((int)ItemIDs.ItemIDRing).ToString()),
            new ConsumedItem(((int)ItemIDs.ItemIDLaser).ToString(), 5000, ((int)ItemIDs.ItemIDRing).ToString()),
            new ConsumedItem(((int)ItemIDs.ItemIDDrill).ToString(), 4000, ((int)ItemIDs.ItemIDRing).ToString()),
            new ConsumedItem(((int)ItemIDs.ItemIDAsteroid).ToString(), 5000, ((int)ItemIDs.ItemIDRing).ToString()),
            new ConsumedItem(((int)ItemIDs.ItemIDRingBonus).ToString(), 0, ((int)ItemIDs.ItemIDRing).ToString()),
            new ConsumedItem(((int)ItemIDs.ItemIDDistanceBonus).ToString(), 0, ((int)ItemIDs.ItemIDRing).ToString()),
            new ConsumedItem(((int)ItemIDs.ItemIDAnimalBonus).ToString(), 0, ((int)ItemIDs.ItemIDRing).ToString()),

            // misc.
            new ConsumedItem(((int)ItemIDs.ItemIDContinue).ToString(), 5, ((int)ItemIDs.ItemIDRedRing).ToString()), // TODO: implement code to be able to change this from settings
            new ConsumedItem(((int)ItemIDs.ItemIDDailyBattleReset).ToString(), 2, ((int)ItemIDs.ItemIDRedRing).ToString()),
            new ConsumedItem(((int)ItemIDs.ItemIDDailyBattleReset1).ToString(), 5, ((int)ItemIDs.ItemIDRedRing).ToString()),
            new ConsumedItem(((int)ItemIDs.ItemIDDailyBattleReset2).ToString(), 15, ((int)ItemIDs.ItemIDRedRing).ToString()),
        };

        public bool TryModifyPrice(string iid, int newPrice, string consumableId)
        {
            var index = 0;
            foreach(var item in consumedCostList)
            {
                if(item.itemId == iid)
                {
                    if (consumedCostList[index].itemId != item.itemId)
                        throw new Exception("Mismatched IDs in TryModifyPrice - this may be due to a bug in the code");
                    consumedCostList[index].numItem = newPrice.ToString();
                    consumedCostList[index].consumedItemId = consumableId;
                    return true;
                }
                index++;
            }
            // no such id
            return false;
        }

        public List<ConsumedItem> consumedCostList { get; set; }
    }
}
