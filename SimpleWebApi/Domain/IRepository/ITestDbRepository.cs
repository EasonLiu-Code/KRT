using SimpleWebApi.Infrastructure.Entities.Test;

namespace SimpleWebApi.Domain.IRepository;

public interface ITestDbRepository
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
   Task<TestDb>  FirstOrDefaultAsync (int id);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
   Task<List<TestDb>> GetListAsync(string url);
   /// <summary>
   /// 
   /// </summary>
   /// <param name="testDb"></param>
   /// <returns></returns>
    Task<bool> InsertAsync(TestDb testDb);
   /// <summary>
   /// 
   /// </summary>
   /// <param name="lstTestDb"></param>
   /// <returns></returns>
    Task<bool> InsertManyAsync(List<TestDb> lstTestDb);
   /// <summary>
   /// 
   /// </summary>
   /// <returns></returns>
    Task SaveChange();
}