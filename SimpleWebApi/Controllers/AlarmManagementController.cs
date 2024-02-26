using Microsoft.AspNetCore.Mvc;
using SimpleWebApi.Domain.IRepository;

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
    /// Init
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public async Task<bool> InsertInitInfoAsync()
    {
        return await _alarmManagementRepository.InsertInitInfoAsync();
    }
}