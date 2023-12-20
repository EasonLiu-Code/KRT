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
}