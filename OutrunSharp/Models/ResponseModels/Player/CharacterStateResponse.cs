using OutrunSharp.Models.Obj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutrunSharp.Models.ResponseModels.Player
{
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
}
