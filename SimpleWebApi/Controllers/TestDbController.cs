using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using SimpleWebApi.Application.IAppService;
using SimpleWebApi.Infrastructure.Entities.Test;

namespace SimpleWebApi.Controllers;

/// <summary>
/// 数据测试
/// </summary>
[ApiController]
[Route("api/[controller]/[action]")]
public class TestDbController:ControllerBase
{
    private readonly ITestDbAppService _testDbAppService;

    /// <summary>
    /// ctor
    /// </summary>
    /// <param name="testDbAppService"></param>
    public TestDbController(ITestDbAppService testDbAppService)
    {
        _testDbAppService = testDbAppService;
    }

    /// <summary>
    /// 插入数据Demo
    /// </summary>
    /// <param name="testDb"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<bool> InsertData(TestDbDto testDb)
    {
        return await _testDbAppService.TestInsertData(testDb);
    }

    /// <summary>
    /// 获取数据Demo
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<TestDb> GetTestDbById(int id)
    {
        return await _testDbAppService.GetTestDbInfoById(id);
    }

    /// <summary>
    /// 更新数据Demo
    /// </summary>
    /// <param name="url"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<bool> UpdateUrlAsync(string url, int id)
    {
        return await _testDbAppService.UpdateUrl(url, id);
    }

    /// <summary>
    /// 条件查询Demo，返回多条
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<List<TestDb>> GetListInfoAsync(string url)
    {
        return await _testDbAppService.GetListInfoAsync(url);
    }

    /// <summary>
    /// 批量插入
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<bool> InsertManyAsync(TestDbDto dto)
    {
        return await _testDbAppService.InsertManyAsync(dto);
    }

    /// <summary>
    /// 批量更新
    /// </summary>
    /// <param name="url"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<bool> UpdateManyAsync(string url, string data)
    {
        return await _testDbAppService.UpdateManyAsync(url, data);
    }
}