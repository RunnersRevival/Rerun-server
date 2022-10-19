#nullable disable
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;
using Rerun.Db.Models;
using Rerun.Models.DbModels;

// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Rerun.Db;

public class RerunDbContext : DbContext
{
    public DbSet<PlayerInfo> player_info { get; set; }
    public DbSet<PlayerState> player_states { get; set; }
    public DbSet<PlayerMileage> player_mileage { get; set; }
    
    public DbSet<SessionIds> session_ids { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
    }
}