﻿using Microsoft.Extensions.Caching.Memory;
using SimpleWebApi.Application.IAppService;
using SimpleWebApi.Domain.IRepository;
using SimpleWebApi.Infrastructure.Entities.Test;

namespace SimpleWebApi.Application.AppService;

public class TestDbAppService:ITestDbAppService
{
    private readonly ITestDbRepository _testDbRepository;
    private readonly IMemoryCache _cache;

    /// <summary>
    /// ctor
    /// </summary>
    /// <param name="testDbRepository"></param>
    /// <param name="cache"></param>
    public TestDbAppService(ITestDbRepository testDbRepository, IMemoryCache cache)
    {
        _testDbRepository = testDbRepository;
        _cache = cache;
    }

    /// <summary>
    /// 增
    /// </summary>
    /// <param name="testDb"></param>
    /// <returns></returns>
    public async Task<bool> TestInsertData(TestDbDto testDb)
    {
        for (int i = 0; i < 100; i++)
        {
            await _testDbRepository.InsertAsync(new TestDb
            {
                Url = testDb.Url,
                TestDate = testDb.Data,
            });
        }
        return true;
    }

    /// <summary>
    /// 条件查询Demo 返回单条数据
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<TestDb> GetTestDbInfoById(int id)
    {
        return await _testDbRepository.FirstOrDefaultAsync(id);
    }

    /// <summary>
    /// 条件查询Demo 返回多条(内存缓存)
    /// </summary>
    /// <returns></returns>
    public async Task<List<TestDb>> GetListInfoAsync(string url)
    {
        var cacheValue = await _cache.GetOrCreateAsync(
            nameof(GetListInfoAsync) + $"{url}",
            async cacheEntry =>
            {
                cacheEntry.SetOptions(new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1)
                });
               return await _testDbRepository.GetListAsync(url);
            });
        return cacheValue ?? new List<TestDb>();
    }

    /// <summary>
    /// 更新数据 使用先删后更策略
    /// </summary>
    /// <param name="url"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<bool> UpdateUrl(string url, int id)
    {
        var info = await _testDbRepository.FirstOrDefaultAsync(id);
        _cache.Remove(nameof(GetListInfoAsync) + $"{info.Url}");
        info.Url = url;
        await _testDbRepository.SaveChange();
        return true;
    }
}