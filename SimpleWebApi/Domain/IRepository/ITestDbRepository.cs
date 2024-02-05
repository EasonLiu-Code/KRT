using SimpleWebApi.Infrastructure.Entities.Test;

namespace SimpleWebApi.Domain.IRepository;

/// <summary>
/// 
/// </summary>
public interface ITestDbRepository
{
    /// <summary>
    /// 单体查询
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
   Task<TestDb>  FirstOrDefaultAsync (int id);
    /// <summary>
    /// 获取符合条件的List
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
   Task<List<TestDb>> GetListAsync(string url);
   /// <summary>
   /// 单个插入
   /// </summary>
   /// <param name="testDb"></param>
   /// <returns></returns>
    Task<bool> InsertAsync(TestDb testDb);
   /// <summary>
   /// 批量插入
   /// </summary>
   /// <param name="lstTestDb"></param>
   /// <returns></returns>
    Task<bool> InsertManyAsync(List<TestDb> lstTestDb);

    /// <summary>
    /// 批量更新
    /// </summary>
    /// <param name="url"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    Task<bool> UpdateManyAsync(string url,string data);
    
   /// <summary>
   /// 
   /// </summary>
   /// <returns></returns>
    Task SaveChange();
}