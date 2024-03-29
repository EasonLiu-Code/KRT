﻿using Microsoft.EntityFrameworkCore;
using SimpleWebApi.Domain.IRepository;
using SimpleWebApi.Infrastructure.CommonDto.TestDb;
using SimpleWebApi.Infrastructure.Entities.Test;

namespace SimpleWebApi.Infrastructure.Repositories;

/// <summary>
/// repo
/// </summary>
public class TestDbRepository:Repository<TestDb>,ITestDbRepository
{
    /// <summary>
    /// ctor
    /// </summary>
    /// <param name="dbContext"></param>
    public TestDbRepository(DataDbContext dbContext):base(dbContext)
    {
    }
    
    /// <summary>
    /// 根据条件获取
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<TestDb> FirstOrDefaultAsync(int id)
    {
        var res= await DataDbContext.TestDb.FirstOrDefaultAsync(i => i.Id.Equals(id)&&!i.IsDeleted);
        return res ?? new TestDb();
    }

    /// <summary>
    /// 根据某个条件批量获取
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    public async Task<List<TestDb>> GetListAsync(string url)
    {
       var res= await DataDbContext.TestDb.Where(u => u.Url != null 
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
        await DataDbContext.TestDb.AddAsync(testDb);
        await DataDbContext.SaveChangesAsync();
        return true;
    }
    
    /// <summary>
    /// 批量插入数据
    /// </summary>
    /// <param name="lstTestDb"></param>
    /// <returns></returns>
    public async Task<bool> InsertManyAsync(List<TestDb> lstTestDb)
    {
        await DataDbContext.TestDb.AddRangeAsync(lstTestDb);
        await DataDbContext.SaveChangesAsync();
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
        await DataDbContext.TestDb
            .Where(a=>a.Url != null && a.Url.Equals(url))
            .ExecuteUpdateAsync(a => a.SetProperty(u => u.TestDate ,data));
        return true;
    }

    /// <summary>
    /// 光标分页
    /// </summary>
    /// <returns></returns>
    public async Task<TestDbPageCursorListDto> CursorForPageAsync(TestDbCursorPageInputDto cursorPageInput,CancellationToken cancellationToken=default)
    {
        var testDbs = await DataDbContext.TestDb.Where(p => p.Id >= cursorPageInput.Cursor).Take(cursorPageInput.PageSize + 1).OrderBy(p => p.Id).ToListAsync(cancellationToken: cancellationToken);
        long cursor = testDbs[^1].Id;
        var result = new TestDbPageCursorListDto { Cursor = cursor,TestDbs = testDbs};
        return result;
    }

    /// <summary>
    /// 分页
    /// </summary>
    /// <returns></returns>
    public async Task<TestDbPageListDto> GetTestDbForPageAsync(TestDbPageInputDto input,CancellationToken cancellationToken=default)
    {
        var testDbs = await DataDbContext.TestDb.OrderBy(o => o.Id).Skip((input.Page - 1) * input.PageSize)
            .Take(input.PageSize).ToListAsync(cancellationToken);
        return new TestDbPageListDto { TestDbs = testDbs };
    }

    /// <summary>
    /// 保存跟踪结果
    /// </summary>
    public async Task SaveChange()
    {
        await DataDbContext.SaveChangesAsync();
    }
}