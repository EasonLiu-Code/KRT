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


    /// <summary>
    /// 根据条件获取
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<TestDb> FirstOrDefaultAsync(int id)
    {
        var res= await _dbContext.TestDb.FirstOrDefaultAsync(i => i.Id.Equals(id)&&!i.IsDeleted);
        if (res is null)
        {
            return new TestDb();
        }
        return res;
    }

    /// <summary>
    /// 根据某个条件批量获取
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    public async Task<List<TestDb>> GetListAsync(string url)
    {
       var res= await _dbContext.TestDb.Where(u => u.Url != null 
                                                   && u.Url.Equals(url) 
                                                   && !u.IsDeleted).ToListAsync();
       if (res is not {Count:>0} )
       {
           return new List<TestDb>();
       }

       return res;
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