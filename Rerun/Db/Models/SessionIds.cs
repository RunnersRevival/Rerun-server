namespace Rerun.Db.Models
{
    public class SessionIds
    {
        public string SID { get; set; }
        public ulong UID { get; set; }
        public long AssignedAtTime { get; set; }
        public int CurrentSeqNum { get; set; } // for sanity checking
    }
}
