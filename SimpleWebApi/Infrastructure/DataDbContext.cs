using Microsoft.EntityFrameworkCore;

namespace SimpleWebApi.Infrastructure;

public class DataDbContext:DbContext
{
    public DataDbContext(DbContextOptions<DataDbContext>option):base(option)
    {
        
    }

    //public DbSet<T> T { get; set; }
}