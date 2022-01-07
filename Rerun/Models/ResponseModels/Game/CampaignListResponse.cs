using System.Collections.Generic;
using Rerun.Models.Obj;

// ReSharper disable InconsistentNaming
#pragma warning disable IDE1006 // Naming Styles

namespace Rerun.Models.ResponseModels.Game
{
    public class CampaignListResponse : BaseResponse
    {
        public CampaignListResponse() : base()
        {
            campaignList = new List<Campaign>();
        }
        public CampaignListResponse(string errMsg, int status) : base(errMsg, status)
        {
            campaignList = new List<Campaign>();
        }

        public List<Campaign> campaignList { get; set; }
    }
}
