using Microsoft.Extensions.Caching.Memory;
using SimpleWebApi.Application.IAppService;
using SimpleWebApi.Domain.IRepository;
using SimpleWebApi.Infrastructure.CommonDto.TestDb;
using SimpleWebApi.Infrastructure.Entities.Test;

namespace SimpleWebApi.Application.AppService;

/// <summary>
/// demo样例
/// </summary>
public class TestDbAppService:ITestDbAppService
{
    private readonly ITestDbRepository _testDbRepository;
    private readonly IMemoryCache _cache;
    private readonly IRepository<TestDb> _repository;

    /// <summary>
    /// ctor
    /// </summary>
    /// <param name="testDbRepository"></param>
    /// <param name="cache"></param>
    /// <param name="repository"></param>
    public TestDbAppService(ITestDbRepository testDbRepository, IMemoryCache cache, 
        IRepository<TestDb> repository)
    {
        _testDbRepository = testDbRepository;
        _cache = cache;
        _repository = repository;
    }

    /// <summary>
    /// 增
    /// </summary>
    /// <param name="testDb"></param>
    /// <returns></returns>
    public async Task<bool> TestInsertData(TestDbDto testDb)
    {
        await _testDbRepository.InsertAsync(new TestDb
        {
            Url = testDb.Url,
            TestDate = testDb.Data,
        });

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
    /// 批量插入Demo
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<bool> InsertManyAsync(TestDbDto dto)
    {
        var lstTestDb = new List<TestDb>();
        for (var i = 0; i < 10000; i++)
        {
            lstTestDb.Add(new TestDb
            {
                Url = dto.Url,
                TestDate = dto.Data
            });
        }
        await _testDbRepository.InsertManyAsync(lstTestDb);
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
        await _testDbRepository.UpdateManyAsync(url,data);
        return true;
    }

    /// <summary>
    /// 旧方法批量更新
    /// </summary>
    /// <param name="url"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    public async Task<bool> TestOldUpdateManyAsync(string url, string data)
    {
        var infos = await _testDbRepository.GetListAsync(url);
        infos.ForEach(a=>a.TestDate=data);
        await _testDbRepository.SaveChange();
        return true;
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

    /// <summary>
    /// Cursor分页
    /// </summary>
    /// <param name="cursorPageInputDto"></param>
    /// <returns></returns>
    public async Task<TestDbPageCursorListDto> TestDbCursorPageAsync(TestDbCursorPageInputDto cursorPageInputDto)
    {
        return await _testDbRepository.CursorForPageAsync(cursorPageInputDto);
    }

    /// <summary>
    /// 分页
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<TestDbPageListDto> GetTestDbForPageAsync(TestDbPageInputDto input)
    {
        return await _testDbRepository.GetTestDbForPageAsync(input);
    }
}