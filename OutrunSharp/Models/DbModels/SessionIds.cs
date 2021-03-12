using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutrunSharp.Models.DbModels
{
    public class SessionIds
    {
        public string SID { get; set; }
        public ulong UID { get; set; }
        public long AssignedAtTime { get; set; }
    }
}
