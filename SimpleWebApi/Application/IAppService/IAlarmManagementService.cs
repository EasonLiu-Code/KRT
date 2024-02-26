using SimpleWebApi.Infrastructure.CommonDto.AlarmManagement;
using SimpleWebApi.Infrastructure.Entities.AlarmManagement;

namespace SimpleWebApi.Application.IAppService;

/// <summary>
/// I
/// </summary>
public interface IAlarmManagementService
{
    /// <summary>
    /// init
    /// </summary>
    /// <returns></returns>
    Task<bool> InsertInitInfoAsync();

    /// <summary>
    /// 获取报警信息
    /// </summary>
    /// <returns></returns>
    Task<AlarmManagement?> GetAlarmManagementAsync();

    /// <summary>
    /// 更新报警配置
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<bool> UpdateAlarmManagementAsync(AlarmManagementDto input);

}