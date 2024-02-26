using Microsoft.AspNetCore.Mvc;
using SimpleWebApi.Domain.IRepository;
using SimpleWebApi.Infrastructure.CommonDto.AlarmManagement;
using SimpleWebApi.Infrastructure.Entities.AlarmManagement;

namespace SimpleWebApi.Controllers;

/// <summary>
/// 报警管理
/// </summary>
[ApiController]
[Route("api/[controller]/[action]")]
public class AlarmManagementController:ControllerBase
{
    private readonly IAlarmManagementRepository _alarmManagementRepository;

    /// <summary>
    /// ctor
    /// </summary>
    /// <param name="alarmManagementRepository"></param>
    public AlarmManagementController(IAlarmManagementRepository alarmManagementRepository)
    {
        _alarmManagementRepository = alarmManagementRepository;
    }

    /// <summary>
    /// 初始化报警信息
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public async Task<bool> InsertInitInfoAsync()
    {
        return await _alarmManagementRepository.InsertInitInfoAsync();
    }

    /// <summary>
    /// 获取报警信息
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<AlarmManagement?> GetAsync()
    {
        return await _alarmManagementRepository.GetAsync();
    }

    /// <summary>
    /// 更新报警配置
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<bool> UpdateAlarmManagementAsync(AlarmManagementDto input)
    {
        return await _alarmManagementRepository.UpdateAsync(input);
    }
}