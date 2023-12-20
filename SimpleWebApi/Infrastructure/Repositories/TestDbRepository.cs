using Microsoft.EntityFrameworkCore;
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

    public async Task<bool> UpdateAsync(TestDb testDb)
    {
         _dbContext.TestDb.Update(testDb);
         return true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="testDb"></param>
    /// <returns></returns>
    public async Task<bool> InsertAsync(TestDb testDb)
    {
        await _dbContext.TestDb.AddAsync(testDb);
        
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