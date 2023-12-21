using SimpleWebApi.Application.IAppService;
using SimpleWebApi.Domain.IRepository;
using SimpleWebApi.Infrastructure.Entities.Test;

namespace SimpleWebApi.Application.AppService;

public class TestDbAppService:ITestDbAppService
{
    private readonly ITestDbRepository _testDbRepository;

    public TestDbAppService(ITestDbRepository testDbRepository)
    {
        _testDbRepository = testDbRepository;
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
        await _testDbRepository.SaveChange();
        return true;
    }

    /// <summary>
    /// 查询
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<TestDb> GetTestDbInfoById(int id)
    {
        return await _testDbRepository.FirstOrDefaultAsync(id);
    }

    public async Task<bool> UpdateUrl(string url, int id)
    {
        var info = await _testDbRepository.FirstOrDefaultAsync(id);
        info.Url = url;
        await _testDbRepository.SaveChange();
        return true;
    }
}