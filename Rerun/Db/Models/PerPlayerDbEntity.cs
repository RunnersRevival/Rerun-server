using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Rerun.Db.Models
{
    public class PerPlayerDbEntity
    {
        [Column("id")]
        [Key]
        public ulong Id { get; set; }
    }
}
