using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// ReSharper disable InconsistentNaming
#pragma warning disable IDE1006 // Naming Styles

namespace OutrunSharp.Models.Obj
{
    public class Campaign
    {
        public int campaignType { get; set; }
        public int campaignContent { get; set; }
        public int campaignSubContent { get; set; }
        public long campaignStartTime { get; set; }
        public long campaignEndTime { get; set; }
    }

    public enum CampaignTypes
    {
        CampaignTypeBankedRingBonus = 1, // directly influences gameplay by boosting ring bonus
        CampaignTypeDailyMissionBonus,
        CampaignTypeChaoRouletteCost, // puts discount on premium roulette
        CampaignTypeGameItemCost, // puts discount on specified item
        CampaignTypeCharacterUpgradeCost, // puts discount notice on specified character's upgrade button
        CampaignTypePurchaseAddRings, // ring sale
        CampaignTypeJackpotValueBonus,
        CampaignTypeMileagePassingRingBonus,
        CampaignTypePurchaseAddEnergies, // revive token sale
        CampaignTypePurchaseAddRedRings, // red ring sale
        CampaignTypePurchaseAddRedRingsNoChargeUser,
        CampaignTypeSendAddEnergies,
        CampaignTypeInviteCount,
        CampaignTypePremiumRouletteOdds, // puts boosted odds notice on premium roulette
        CampaignTypeFreeWheelSpinCount, // boosts free spins on item roulette
        CampaignTypeContinueCost, // puts discount on continues
        CampaignTypePurchaseAddRaidEnergies, // boss challenge token sale
    }
}
