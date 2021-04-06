using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#pragma warning disable IDE1006 // Naming Styles

namespace OutrunSharp.Models
{
    // Chao are the internal name of companions/buddies
    public class Chao
    {
        public Chao(string id, ChaoRarity chaoRarity)
        {
            chaoId = id;
            rarity = chaoRarity;
            hidden = 0;
            status = ChaoStatus.ChaoStatusLocked;
            level = 0;
            setStatus = ChaoDealing.ChaoDealingNone;
            acquired = 0;
        }

        public string chaoId { get; set; }
        public ChaoRarity rarity { get; set; }
        public int hidden { get; set; } // flag
        public ChaoStatus status { get; set; }
        public int level { get; set; }
        public ChaoDealing setStatus { get; set; }
        public int acquired { get; set; } // flag
    }

    public enum ChaoRarity
    {
        ChaoRarityNormal,
        ChaoRarityRare,
        ChaoRaritySuperRare,
        ChaoRarityNone
    }

    public enum ChaoStatus
    {
        ChaoStatusLocked,
        ChaoStatusUnlocked,
        ChaoStatusMaxLevel
    }

    public enum ChaoDealing
    {
        ChaoDealingNone, // not selected
        ChaoDealingLeader, // primary chao
        ChaoDealingSub // secondary chao
    }

    public enum ChaoIDs
    {
        // normal buddies
        HeroChao = 400000,
        GoldChao,
        DarkChao,

        JewelChao,
        NormalChao,
        Omochao,

        RCMonkey,
        RCSpring,
        RCElectromagnet,

        Chao0009, // NO DATA
        Chao0010, // NO DATA
        Chao0011, // NO DATA

        BabyCyanWisp,
        BabyIndigoWisp,
        BabyYellowWisp,

        Chao0015, // NO DATA
        Chao0016, // NO DATA
        Chao0017, // NO DATA

        RCPinwheel,
        RCPiggyBank,
        RCBalloon,

        EasterChao,
        Chao0022, // NO DATA
        Chao0023, // NO DATA

        PurplePapurisu,
        MagLv1,
        Chao0026, // NO DATA

        // rare buddies
        EggChao = 401000,
        PumpkinChao,
        SkullChao,

        Yacker,
        RCGoldenPiggyBank,
        WizardChao,

        Chao1006, // NO DATA
        Chao1007, // NO DATA
        Chao1008, // NO DATA

        RCTurtle,
        RCUFO,
        RCBomber,

        Chao1012, // NO DATA
        Chao1013, // NO DATA
        Chao1014, // NO DATA

        // beyond this point they dropped the trio scheme
        EasterBunny,
        MagicLamp,
        StarShapedMissile,
        Suketoudara,
        Rappy,
        BlowfishTransporter,
        Genesis,
        Cartridge,
        RCFighter,
        RCHovercraft,
        RCHelicopter,
        GreenCrystalMonsterS,
        GreenCrystalMonsterL,
        RCAirship,
        DesertChao,
        RCSatellite,
        MarineChao,
        Nightopian,
        Orca,
        SonicOmochao,
        TailsOmochao,
        KnucklesOmochao,
        Boob,
        HalloweenChao,
        HeavyBomb,
        BlockBomb,
        HunkOfMeat,
        Yeti,
        SnowChao,
        Ideya,
        ChristmasNightopian,
        Orbot,
        Cubot,

        // super-rare buddies
        LightChaos = 402000,
        HeroChaos,
        DarkChaos,
        Chip,
        Shahra,
        Caliburn,
        KingArthursGhost,
        RCTornado,
        RCBattleCruiser,
        Merlina,
        ErazorDjinn,
        RCMoonMech,
        Carbuncle,
        Quna,
        Chaos,
        DeathEgg,
        RedCrystalMonsterS,
        RedCrystalMonsterL,
        GoldenGoose,
        MotherWisp,
        RCPirateSpaceship,
        GoldenAngel,
        NiGHTS,
        Reala,
        RCTornado2,
        ChaoWalker,
        DarkQueen,
        KingBoomBoo,
        OPapa,
        OpaOpa,
        RCBlockFace,
        ChristmasYeti,
        ChristmasNiGHTS,
        DFekt, // missing assets!
        DarkChaoWalker
    }
}
