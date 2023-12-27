using SimpleWebApi.Infrastructure.Entities.Test;

namespace SimpleWebApi.Application.IAppService;

public interface ITestDbAppService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="testDb"></param>
    /// <returns></returns>
    Task<bool> TestInsertData(TestDbDto testDb);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<TestDb> GetTestDbInfoById(int id);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="url"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> UpdateUrl(string url, int id);

    /// <summary>
    /// 条件查询Demo 返回多条
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    Task<List<TestDb>> GetListInfoAsync(string url);
}