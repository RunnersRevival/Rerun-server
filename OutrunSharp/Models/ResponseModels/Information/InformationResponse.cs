using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
