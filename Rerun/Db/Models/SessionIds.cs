using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rerun.Db.Models
{
    public class SessionIds
    {
        [Column("sid")]
        [MaxLength(48)]
        public string SID { get; set; }
        [Column("uid")]
        public ulong UID { get; set; }
        [Column("assigned_at_time")]
        public long AssignedAtTime { get; set; }
        [Column("current_seq")]
        public int CurrentSeqNum { get; set; } // for sanity checking
    }
}
