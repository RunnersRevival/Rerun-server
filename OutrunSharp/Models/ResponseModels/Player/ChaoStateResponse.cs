using OutrunSharp.Models.Obj;
using System;
using System.Collections.Generic;
// ReSharper disable InconsistentNaming

#pragma warning disable IDE1006 // Naming Styles

namespace OutrunSharp.Models.ResponseModels.Player
{
    public class ChaoStateResponse : BaseResponse
    {
        public ChaoStateResponse() : base()
        {
            chaoState = new List<Chao>();
            foreach (var chaoId in _defaultChaoIDs)
            {
                var rarity = (ChaoRarity)Convert.ToInt32(chaoId[2]);
                chaoState.Add(new Chao(chaoId, rarity));
            }
        }
        public ChaoStateResponse(string errMsg, int status) : base(errMsg, status)
        {
            chaoState = new List<Chao>();
            foreach (var chaoId in _defaultChaoIDs)
            {
                var rarity = (ChaoRarity)Convert.ToInt32(chaoId[2]);
                chaoState.Add(new Chao(chaoId, rarity));
            }
        }

        private readonly string[] _defaultChaoIDs = { "400000", "400001", "400002", "400003", "400004", "400005", "400006", "400007", "400008", "400009", "400010", "400011", "400012", "400013", "400014", "400015", "400016", "400017", "400018", "400019", "400020", "400021", "400022", "400023", "400024", "400025", "401000", "401001", "401002", "401003", "401004", "401005", "401006", "401007", "401008", "401009", "401010", "401011", "401012", "401013", "401014", "401015", "401016", "401017", "401018", "401019", "401020", "401021", "401022", "401023", "401024", "401025", "401026", "401027", "401028", "401029", "401030", "401031", "401032", "401033", "401034", "401035", "401036", "401037", "401038", "401039", "401040", "401041", "401042", "401043", "401044", "401045", "401046", "401047", "402000", "402001", "402002", "402003", "402004", "402005", "402006", "402007", "402008", "402009", "402010", "402011", "402012", "402013", "402014", "402015", "402016", "402017", "402018", "402019", "402020", "402021", "402022", "402023", "402024", "402025", "402026", "402027", "402028", "402029", "402030", "402031", "402032", "402033", "402034" };

        public List<Chao> chaoState { get; set; }
    }
}
