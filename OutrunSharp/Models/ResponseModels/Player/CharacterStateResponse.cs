using OutrunSharp.Models.Obj;
using System.Collections.Generic;

// ReSharper disable InconsistentNaming
#pragma warning disable IDE1006 // Naming Styles

namespace OutrunSharp.Models.ResponseModels.Player
{
    public class CharacterStateResponse : BaseResponse
    {
        public CharacterStateResponse() : base()
        {
            characterState = new List<Character>();
            foreach (var charaId in DefaultCharaIDs)
            {
                characterState.Add(new Character(charaId));
            }
        }
        public CharacterStateResponse(string errMsg, int status) : base(errMsg, status)
        {
            characterState = new List<Character>();
            foreach (var charaId in DefaultCharaIDs)
            {
                characterState.Add(new Character(charaId));
            }
        }

        private readonly string[] DefaultCharaIDs = { "300000", "300001", "300002", "300003" };

        public List<Character> characterState { get; set; }
    }
}
