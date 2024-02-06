using SimpleWebApi.Infrastructure.CommonDto.TestDb;
using SimpleWebApi.Infrastructure.Entities.Test;

namespace SimpleWebApi.Application.IAppService;

/// <summary>
/// interface
/// </summary>
public interface ITestDbAppService
{
    /// <summary>
    /// 插入单挑数据
    /// </summary>
    /// <param name="testDb"></param>
    /// <returns></returns>
    Task<bool> TestInsertData(TestDbDto testDb);

    /// <summary>
    /// 根据条件获取
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<TestDb> GetTestDbInfoById(int id);

    /// <summary>
    /// 批量插入
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<bool> InsertManyAsync(TestDbDto dto);

    /// <summary>
    /// 批量更新
    /// </summary>
    /// <param name="url"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    Task<bool> UpdateManyAsync(string url, string data);

    /// <summary>
    /// EF7.0之前的更新
    /// </summary>
    /// <param name="url"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    Task<bool> TestOldUpdateManyAsync(string url, string data);
    
    /// <summary>
    /// 更新单条数据
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

    /// <summary>
    /// Cursor分页
    /// </summary>
    /// <param name="inputDto"></param>
    /// <returns></returns>
    Task<TestDbPageCursorListDto> TestDbCursorPageAsync(TestDbInputDto inputDto);
}