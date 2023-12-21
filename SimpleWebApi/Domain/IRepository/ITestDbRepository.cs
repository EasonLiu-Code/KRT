using SimpleWebApi.Infrastructure.Entities.Test;

namespace SimpleWebApi.Domain.IRepository;

public interface ITestDbRepository
{
   Task<TestDb>  FirstOrDefaultAsync (int id);

   Task<List<TestDb>> GetListAsync(string url);
   
    Task<bool> InsertAsync(TestDb testDb);
    Task SaveChange();
}