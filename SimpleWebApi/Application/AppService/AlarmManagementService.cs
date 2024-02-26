using SimpleWebApi.Application.IAppService;
using SimpleWebApi.Domain.IRepository;
using SimpleWebApi.Infrastructure.CommonDto.AlarmManagement;
using SimpleWebApi.Infrastructure.Entities.AlarmManagement;

namespace SimpleWebApi.Application.AppService;

/// <summary>
/// application
/// </summary>
public class AlarmManagementService : IAlarmManagementService
{
    private readonly IAlarmManagementRepository _alarmManagementRepository;

    /// <summary>
    /// ctor
    /// </summary>
    /// <param name="alarmManagementRepository"></param>
    public AlarmManagementService(IAlarmManagementRepository alarmManagementRepository)
    {
        _alarmManagementRepository = alarmManagementRepository;
    }

    /// <summary>
    /// init
    /// </summary>
    /// <returns></returns>
    public async Task<bool> InsertInitInfoAsync()
    {
        return await _alarmManagementRepository.InsertInitInfoAsync();
    }

    /// <summary>
    /// 获取报警信息
    /// </summary>
    /// <returns></returns>
    public async Task<AlarmManagement?> GetAlarmManagementAsync()
    {
        return await _alarmManagementRepository.GetAsync();
    }

    /// <summary>
    /// 更新报警配置
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> UpdateAlarmManagementAsync(AlarmManagementDto input)
    {
        return await _alarmManagementRepository.UpdateAsync(input);
    }
}