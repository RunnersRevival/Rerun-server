using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#pragma warning disable IDE1006 // Naming Styles

namespace OutrunSharp.Models.Obj
{
    public class Incentive : Item
    {
        public Incentive(string id, int amount) : base(id, amount)
        {
            numIncentiveCont = 1;
        }
        public Incentive(string id, int amount, int incentiveCount) : base(id, amount)
        {
            numIncentiveCont = incentiveCount;
        }

        public int numIncentiveCont { get; set; }
    }
}
