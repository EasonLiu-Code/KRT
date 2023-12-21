using SimpleWebApi.Infrastructure.Entities.Test;

namespace SimpleWebApi.Application.IAppService;

public interface ITestDbAppService
{
    Task<bool> TestInsertData(TestDbDto testDb);

    Task<TestDb> GetTestDbInfoById(int id);

    Task<bool> UpdateUrl(string url, int id);
}