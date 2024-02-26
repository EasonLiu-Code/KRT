using SimpleWebApi.Application.IAppService;
using SimpleWebApi.Domain.IRepository;

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
}