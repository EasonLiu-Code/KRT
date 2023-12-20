using SimpleWebApi.Infrastructure.Entities.Test;

namespace SimpleWebApi.Domain.IRepository;

public interface ITestDbRepository
{
    Task<bool> InsertAsync(TestDb testDb);
    Task SaveChange();
}