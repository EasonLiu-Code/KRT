using SimpleWebApi.Domain.IRepository;
using SimpleWebApi.Infrastructure.Entities.Test;

namespace SimpleWebApi.Infrastructure.Repositories;

public class TestDbRepository:ITestDbRepository
{
    private readonly DataDbContext _dbContext;

    public TestDbRepository(DataDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="testDb"></param>
    /// <returns></returns>
    public async Task<bool> InsertAsync(TestDb testDb)
    {
        await _dbContext.AddAsync(testDb);
        
        return true;
    }

    /// <summary>
    /// 
    /// </summary>
    public async Task SaveChange()
    {
        await _dbContext.SaveChangesAsync();
    }
}