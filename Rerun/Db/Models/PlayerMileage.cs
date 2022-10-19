using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rerun.Db.Models;

public class PlayerMileage
{
    [Column("id")]
    [Key]
    public ulong Id { get; set; }
    
    [Column("map_distance")]
    public int MapDistance { get; set; }
    
    [Column("num_boss_attack")]
    public int NumBossAttack { get; set; }
    
    [Column("stage_distance")]
    public int StageDistance { get; set; }
    
    [Column("stage_max_score")]
    public long StageMaxScore { get; set; }
    
    [Column("episode")]
    public int Episode { get; set; }
    
    [Column("chapter")]
    public int Chapter { get; set; }
    
    [Column("point")]
    public int Point { get; set; }
    
    [Column("stage_total_score")]
    public long StageTotalScore { get; set; }
    
    [Column("chapter_start_time")]
    public long ChapterStartTime { get; set; }
}