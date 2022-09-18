using System.Collections.Generic;
using Rerun.Models.Obj;

namespace Rerun.Models;

/// <summary>A set of configuration options for many server-side features.</summary>
public class RerunDataTable
{
    public RerunDataTable()
    {
    }
    
    public int dataVersion { get; set; }
    
    public Dictionary<string, int> charaGroup { get; set; }
    
    public Dictionary<int, int[]> charaLevelupCostGroups { get; set; }
    
    public int chaoRouletteCost { get; set; }
    
    public List<ConsumedItem> costList { get; set; }
    
    public int maxContinues { get; set; }
    
    public static RerunDataTable DefaultRerunData()
    {
        return new RerunDataTable()
        {
            dataVersion = 0,
            charaGroup = new Dictionary<string, int>()
            {
                { ((int)CharaIDs.Sonic).ToString(), 0 },
                { ((int)CharaIDs.Tails).ToString(), 0 },
                { ((int)CharaIDs.Knuckles).ToString(), 0 },
                { ((int)CharaIDs.Amy).ToString(), 1 },
                { ((int)CharaIDs.Shadow).ToString(), 1 },
                { ((int)CharaIDs.Blaze).ToString(), 1 },
                { ((int)CharaIDs.Rouge).ToString(), 1 },
                { ((int)CharaIDs.Omega).ToString(), 1 },
                { ((int)CharaIDs.Big).ToString(), 1 },
                { ((int)CharaIDs.Cream).ToString(), 1 },
                { ((int)CharaIDs.Espio).ToString(), 1 },
                { ((int)CharaIDs.Charmy).ToString(), 1 },
                { ((int)CharaIDs.Vector).ToString(), 1 },
                { ((int)CharaIDs.Silver).ToString(), 1 },
                { ((int)CharaIDs.MetalSonic).ToString(), 1 },
                { ((int)CharaIDs.ClassicSonic).ToString(), 1 },
                { ((int)CharaIDs.Werehog).ToString(), 1 },
                { ((int)CharaIDs.Sticks).ToString(), 1 },
                { ((int)CharaIDs.Tikal).ToString(), 1 },
                { ((int)CharaIDs.Mephiles).ToString(), 1 },
                { ((int)CharaIDs.PSISilver).ToString(), 1 },
                { ((int)CharaIDs.Marine).ToString(), 1 },
                { ((int)CharaIDs.Chara0025).ToString(), 1 },
                { ((int)CharaIDs.Chara0026).ToString(), 1 },
                { ((int)CharaIDs.Chara0027).ToString(), 1 }
            },
            charaLevelupCostGroups = new Dictionary<int, int[]>()
            {
                { 0, new[] {
                        200, 400, 600, 800, 1000, 1200, 1400, 1600, 1800, 2000,
                        2400, 2800, 3200, 3600, 4000, 4400, 4800, 5200, 5600, 6000,
                        6600, 7200, 7800, 8400, 9000, 9600, 10200, 10800, 11400, 12000,
                        12800, 13600, 14400, 15200, 16000, 16800, 17600, 18400, 19200, 20000,
                        21000, 22000, 23000, 24000, 25000, 26000, 27000, 28000, 29000, 30000,
                        31200, 32400, 33600, 34800, 36000, 37200, 38400, 39600, 40800, 42000,
                        43400, 44800, 46200, 47600, 49000, 50400, 51800, 53200, 54600, 56000,
                        57600, 59200, 60800, 62400, 64000, 65600, 67200, 68800, 70400, 72000,
                        73800, 75600, 77400, 79200, 81000, 82800, 84600, 86400, 88200, 90000,
                        92000, 94000, 96000, 98000, 100000, 102000, 104000, 106000, 108000, 110000,
                        112000
                    }
                },
                { 1, new[] {
                        300, 600, 900, 1200, 1500, 1800, 2100, 2400, 2700, 3000,
                        3600, 4200, 4800, 5400, 6000, 6600, 7200, 7800, 8400, 9000,
                        9900, 10800, 11700, 12600, 13500, 14400, 15300, 16200, 17100, 18000,
                        19200, 20400, 21600, 22800, 24000, 25200, 26400, 27600, 28800, 30000,
                        31500, 33000, 34500, 36000, 37500, 39000, 40500, 42000, 43500, 45000,
                        46800, 48600, 50400, 52200, 54000, 55800, 57600, 59400, 61200, 63000,
                        65100, 67200, 69300, 71400, 73500, 75600, 77700, 79800, 81900, 84000,
                        86400, 88800, 91200, 93600, 96000, 98400, 100800, 103200, 105600, 108000,
                        110700, 113400, 116100, 118800, 121500, 124200, 126900, 129600, 132300, 135000,
                        138000, 141000, 144000, 147000, 150000, 153000, 156000, 159000, 162000, 165000,
                        168000
                    }
                }
            },
            chaoRouletteCost = 15,
            costList = {
                new ConsumedItem(((int)ItemIDs.ItemIDBoostScore).ToString(), 6000, ((int)ItemIDs.ItemIDRing).ToString()),
                new ConsumedItem(((int)ItemIDs.ItemIDBoostTrampoline).ToString(), 1000, ((int)ItemIDs.ItemIDRing).ToString()),
                new ConsumedItem(((int)ItemIDs.ItemIDBoostSubChara).ToString(), 4000, ((int)ItemIDs.ItemIDRing).ToString()),
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
                new ConsumedItem(((int)ItemIDs.ItemIDContinue).ToString(), 5, ((int)ItemIDs.ItemIDRedRing).ToString()),
                new ConsumedItem(((int)ItemIDs.ItemIDDailyBattleReset).ToString(), 2, ((int)ItemIDs.ItemIDRedRing).ToString()),
                new ConsumedItem(((int)ItemIDs.ItemIDDailyBattleReset1).ToString(), 5, ((int)ItemIDs.ItemIDRedRing).ToString()),
                new ConsumedItem(((int)ItemIDs.ItemIDDailyBattleReset2).ToString(), 15, ((int)ItemIDs.ItemIDRedRing).ToString())
            },
            maxContinues = 2
        };
    }
}