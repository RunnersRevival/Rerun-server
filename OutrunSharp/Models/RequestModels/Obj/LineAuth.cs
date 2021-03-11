using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutrunSharp.Models.RequestModels.Obj
{
    public class LineAuth
    {
        public string userId { get; set; }
        public string password { get; set; }
        public string migrationPassword { get; set; }
    }
}
