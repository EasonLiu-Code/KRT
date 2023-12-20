using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using SimpleWebApi.Infrastructure.Entities.Test;

namespace SimpleWebApi.Infrastructure;

public class DataDbContext:DbContext
{
    public DataDbContext(DbContextOptions<DataDbContext>option):base(option)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TestDb>()
            .Property(e => e.IsDeleted)
            .HasDefaultValue(false);

    }
    

    public DbSet<TestDb> TestDb { get; set; }
}