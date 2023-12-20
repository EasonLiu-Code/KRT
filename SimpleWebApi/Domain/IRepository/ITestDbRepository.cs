using SimpleWebApi.Infrastructure.Entities.Test;

namespace SimpleWebApi.Domain.IRepository;

public interface ITestDbRepository
{
    Task<bool> UpdateAsync(TestDb testDb);
    Task<bool> InsertAsync(TestDb testDb);
    Task SaveChange();
}