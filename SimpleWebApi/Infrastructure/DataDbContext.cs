using Microsoft.EntityFrameworkCore;
using SimpleWebApi.Infrastructure.Entities.AlarmManagement;
using SimpleWebApi.Infrastructure.Entities.Test;
using SimpleWebApi.Infrastructure.Entities.VehicleInspection;

namespace SimpleWebApi.Infrastructure;
/// <summary>
/// context
/// </summary>
public class DataDbContext:DbContext
{
    /// <summary>
    /// ctor
    /// </summary>
    /// <param name="option"></param>
    public DataDbContext(DbContextOptions<DataDbContext>option):base(option)
    {
        
    }
    
    /// <summary>
    /// 添加表的属性等
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TestDb>()
            .Property(e => e.IsDeleted)
            .HasDefaultValue(false);
        
        modelBuilder.Entity<VehicleInspection>()
            .Property(e => e.IsDeleted)
            .HasDefaultValue(false);
        
        modelBuilder.Entity<VehicleInspection>()
            .Property(e => e.InspectionTime)
            .HasDefaultValue(DateTime.Now);
    }
    
    /// <summary></summary>
    public DbSet<TestDb> TestDb { get; set; }

    /// <summary></summary>
    public DbSet<VehicleInspection> VehicleInspection { get; set; }

    /// <summary></summary>
    public DbSet<AlarmManagement?> AlarmManagement { get; set; }
}