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
       return res is not {Count:>0} ? new List<TestDb>() : res;
    }

    /// <summary>
    /// 插入单条数据
    /// </summary>
    /// <param name="testDb"></param>
    /// <returns></returns>
    public async Task<bool> InsertAsync(TestDb testDb)
    {
        await _dbContext.TestDb.AddAsync(testDb);
        await _dbContext.SaveChangesAsync();
        return true;
    }
    
    /// <summary>
    /// 批量插入数据
    /// </summary>
    /// <param name="lstTestDb"></param>
    /// <returns></returns>
    public async Task<bool> InsertManyAsync(List<TestDb> lstTestDb)
    {
        await _dbContext.TestDb.AddRangeAsync(lstTestDb);
        await SaveChange();
        return true;
    }

    /// <summary>
    /// 批量更新
    /// </summary>
    /// <param name="url"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    public async Task<bool> UpdateManyAsync(string url,string data)
    {
        await _dbContext.TestDb
            .Where(a=>a.Url != null && a.Url.Equals(url))
            .ExecuteUpdateAsync(a => a.SetProperty(u => u.TestDate ,data));
        return true;
    }


    /// <summary>
    /// 保存跟踪结果
    /// </summary>
    public async Task SaveChange()
    {
        await _dbContext.SaveChangesAsync();
    }
}