using Microsoft.EntityFrameworkCore;
using SimpleWebApi.Infrastructure.Entities.Test;

namespace SimpleWebApi.Infrastructure;

public class DataDbContext:DbContext
{
    public DataDbContext(DbContextOptions<DataDbContext>option):base(option)
    {
        
    }

    public DbSet<TestDb> TestDb { get; set; }
}