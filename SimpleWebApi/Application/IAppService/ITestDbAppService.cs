using SimpleWebApi.Infrastructure.Entities.Test;

namespace SimpleWebApi.Application.IAppService;

public interface ITestDbAppService
{
    Task<bool> TestInsertData(TestDbDto testDb);
}