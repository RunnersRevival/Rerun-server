using OutrunSharp.Models.DbModels;
using System;
using System.Collections.Generic;

#pragma warning disable IDE1006 // Naming Styles

namespace OutrunSharp.Models.ResponseModels
{
    public class PlayerStateResponse : BaseResponse
    {
        public PlayerStateResponse() : base()
        {
            playerState = new();
        }
        public PlayerStateResponse(string errMsg, int status) : base(errMsg, status)
        {
            playerState = new();
        }

        public PlayerStateModel playerState { get; set; }
    }

    public class CharacterStateResponse : BaseResponse
    {
        public CharacterStateResponse() : base()
        {
            characterState = new();
            foreach (string charaId in DefaultCharaIDs)
            {
                characterState.Add(new Character(charaId));
            }
        }
        public CharacterStateResponse(string errMsg, int status) : base(errMsg, status)
        {
            characterState = new();
            foreach (string charaId in DefaultCharaIDs)
            {
                characterState.Add(new Character(charaId));
            }
        }

        private readonly string[] DefaultCharaIDs = new string[] { "300000", "300001", "300002", "300003" };

        public List<Character> characterState { get; set; }
    }

    public class ChaoStateResponse : BaseResponse
    {
        public ChaoStateResponse() : base()
        {
            chaoState = new();
            foreach (string chaoId in DefaultChaoIDs)
            {
                ChaoRarity rarity = (ChaoRarity)Convert.ToInt32(chaoId[2]);
                chaoState.Add(new Chao(chaoId, rarity));
            }
        }
        public ChaoStateResponse(string errMsg, int status) : base(errMsg, status)
        {
            chaoState = new();
            foreach (string chaoId in DefaultChaoIDs)
            {
                ChaoRarity rarity = (ChaoRarity)Convert.ToInt32(chaoId[2]);
                chaoState.Add(new Chao(chaoId, rarity));
            }
        }

        private readonly string[] DefaultChaoIDs = new string[] { "400000", "400001", "400002", "400003", "400004", "400005", "400006", "400007", "400008", "400009", "400010", "400011", "400012", "400013", "400014", "400015", "400016", "400017", "400018", "400019", "400020", "400021", "400022", "400023", "400024", "400025", "401000", "401001", "401002", "401003", "401004", "401005", "401006", "401007", "401008", "401009", "401010", "401011", "401012", "401013", "401014", "401015", "401016", "401017", "401018", "401019", "401020", "401021", "401022", "401023", "401024", "401025", "401026", "401027", "401028", "401029", "401030", "401031", "401032", "401033", "401034", "401035", "401036", "401037", "401038", "401039", "401040", "401041", "401042", "401043", "401044", "401045", "401046", "401047", "402000", "402001", "402002", "402003", "402004", "402005", "402006", "402007", "402008", "402009", "402010", "402011", "402012", "402013", "402014", "402015", "402016", "402017", "402018", "402019", "402020", "402021", "402022", "402023", "402024", "402025", "402026", "402027", "402028", "402029", "402030", "402031", "402032", "402033", "402034" };

        public List<Chao> chaoState { get; set; }
    }

    public class PlayerStateModel
    {
        public PlayerStateModel()
        {
            DateTimeOffset endOfDay = new DateTime(
                DateTime.Now.Year,
                DateTime.Now.Month,
                DateTime.Now.Day,
                23, 59, 59, 999);
            long endOfDayUnix = endOfDay.ToUnixTimeSeconds();
            Random random = new();
            items = new List<Item>()
            {
                new Item(((int)ItemIDs.ItemIDInvincible).ToString(), 0),
                new Item(((int)ItemIDs.ItemIDBarrier).ToString(), 0),
                new Item(((int)ItemIDs.ItemIDMagnet).ToString(), 0),
                new Item(((int)ItemIDs.ItemIDTrampoline).ToString(), 0),
                new Item(((int)ItemIDs.ItemIDCombo).ToString(), 0),
                new Item(((int)ItemIDs.ItemIDLaser).ToString(), 0),
                new Item(((int)ItemIDs.ItemIDDrill).ToString(), 0),
                new Item(((int)ItemIDs.ItemIDAsteroid).ToString(), 0),
                new Item(((int)ItemIDs.ItemIDRingBonus).ToString(), 0),
                new Item(((int)ItemIDs.ItemIDDistanceBonus).ToString(), 0),
                new Item(((int)ItemIDs.ItemIDAnimalBonus).ToString(), 0)
            };
            equipItemList = new string[] { "-1", "-1", "-1" };
            mainCharaID = ((int)CharaIDs.Sonic).ToString();
            subCharaID = "-1";
            mainChaoID = "-1";
            subChaoID = "-1";
            numRings = "50000";
            numBuyRings = "0";
            numRedRings = "50";
            numBuyRedRings = "0";
            energy = "10";
            energyBuy = "0";
            energyRenewsAt = DateTimeOffset.Now.AddMinutes(10).ToUnixTimeSeconds();
            mumMessages = 0;
            rankingLeague = ((int)RankingLeague.RankingLeagueF_M).ToString();
            quickRankingLeague = ((int)RankingLeague.RankingLeagueF_M).ToString();
            numRouletteTicket = "0";
            chaoEggs = 0;
            totalHighScore = "0";
            quickTotalHighScore = "0";
            totalDistance = "0";
            maximumDistance = "0";
            dailyMissionId = random.Next(1, 198).ToString();
            dailyMissionEndTime = endOfDayUnix;
            dailyChallengeValue = 0;
            dailyChallengeComplete = 0;
            numDailyChalCont = 0;
            numPlaying = "0";
            animals = "0";
            rank = "0";
        }

        public void GetDataFromDatabase(PlayerState playerState)
        {
            items = playerState.Items;
            equipItemList = playerState.EquippedItems.ToArray();
            mainCharaID = playerState.MainCharaID;
            subCharaID = playerState.SubCharaID;
            mainChaoID = playerState.MainChaoID;
            subChaoID = playerState.SubChaoID;
            numRings = playerState.NumRings.ToString();
            numBuyRings = playerState.NumBuyRings.ToString();
            numRedRings = playerState.NumRedRings.ToString();
            numBuyRedRings = playerState.NumBuyRedRings.ToString();
            energy = playerState.Energy.ToString();
            energyBuy = playerState.EnergyBuy.ToString();
            energyRenewsAt = playerState.EnergyRenewsAt;
            mumMessages = playerState.NumMessages;
            rankingLeague = playerState.RankingLeague.ToString();
            quickRankingLeague = playerState.QuickRankingLeague.ToString();
            numRouletteTicket = playerState.NumRouletteTicket.ToString();
            chaoEggs = playerState.ChaoEggs;
            totalHighScore = playerState.HighScore.ToString();
            quickTotalHighScore = playerState.TimedHighScore.ToString();
            totalDistance = playerState.TotalDistance.ToString();
            maximumDistance = playerState.HighDistance.ToString();
            dailyMissionId = playerState.DailyMissionID.ToString();
            dailyMissionEndTime = playerState.DailyMissionEndTime;
            dailyChallengeValue = playerState.DailyChallengeValue;
            dailyChallengeComplete = playerState.DailyChallengeComplete;
            numDailyChalCont = playerState.NumDailyChallenge;
            numPlaying = playerState.NumPlaying.ToString();
            animals = playerState.Animals.ToString();
            rank = playerState.Rank.ToString();
        }

        public List<Item> items { get; set; }
        public string[] equipItemList { get; set; }

        public string mainCharaID { get; set; }
        public string subCharaID { get; set; }

        public string mainChaoID { get; set; }
        public string subChaoID { get; set; }

        public string numRings { get; set; }
        public string numBuyRings { get; set; }

        public string numRedRings { get; set; }
        public string numBuyRedRings { get; set; }

        public string energy { get; set; }
        public string energyBuy { get; set; }
        public long energyRenewsAt { get; set; }

        public int mumMessages { get; set; }

        public string rankingLeague { get; set; }
        public string quickRankingLeague { get; set; }

        public string numRouletteTicket { get; set; }
        public int chaoEggs { get; set; }

        public string totalHighScore { get; set; }
        public string quickTotalHighScore { get; set; }

        public string totalDistance { get; set; }
        public string maximumDistance { get; set; }

        public string dailyMissionId { get; set; }
        public long dailyMissionEndTime { get; set; }
        public int dailyChallengeValue { get; set; }
        public int dailyChallengeComplete { get; set; }
        public int numDailyChalCont { get; set; }

        public string numPlaying { get; set; } // number of games played
        public string animals { get; set; } // total animals acquired
        public string rank { get; set; } // from 0 to 998
    }
}
