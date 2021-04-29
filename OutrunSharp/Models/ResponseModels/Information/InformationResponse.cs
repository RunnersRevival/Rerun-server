using System.Collections.Generic;

// ReSharper disable InconsistentNaming
#pragma warning disable IDE1006 // Naming Styles

namespace OutrunSharp.Models.ResponseModels.Information
{
    public class InformationResponse : BaseResponse
    {
        public InformationResponse() : base()
        {
            informations = new List<Obj.Information>();
            operatorEachInfos = new List<Obj.OperatorInformation>();
            numOperatorInfos = 0;
        }
        public InformationResponse(string errMsg, int status) : base(errMsg, status)
        {
            informations = new List<Obj.Information>();
            operatorEachInfos = new List<Obj.OperatorInformation>();
            numOperatorInfos = 0;
        }

        public List<Obj.Information> informations { get; set; }
        public List<Obj.OperatorInformation> operatorEachInfos { get; set; }
        public int numOperatorInfos { get; set; }
    }
}
