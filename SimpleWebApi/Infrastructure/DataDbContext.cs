using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using SimpleWebApi.Infrastructure.Entities.Test;

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
    }
    

    /// <summary>
    /// 
    /// </summary>
    public DbSet<TestDb> TestDb { get; set; }
}