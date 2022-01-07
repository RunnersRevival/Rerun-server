using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rerun.Models.Obj;

// ReSharper disable InconsistentNaming
#pragma warning disable IDE1006 // Naming Styles

namespace Rerun.Models.ResponseModels.Game
{
    public class MileageDataResponse: BaseResponse
    {
        public MileageDataResponse() : base()
        {
            mileageMapState = new MapState();
            mileageFriendList = new List<MileageFriend>();
        }
        public MileageDataResponse(string errMsg, int status) : base(errMsg, status)
        {
            mileageMapState = new MapState();
            mileageFriendList = new List<MileageFriend>();
        }

        public MapState mileageMapState { get; set; }
        public List<MileageFriend> mileageFriendList { get; set; }
    }
}
