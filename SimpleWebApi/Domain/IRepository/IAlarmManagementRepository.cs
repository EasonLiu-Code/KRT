using SimpleWebApi.Infrastructure.CommonDto.AlarmManagement;
using SimpleWebApi.Infrastructure.Entities.AlarmManagement;

namespace SimpleWebApi.Domain.IRepository;

/// <summary>
/// I
/// </summary>
public interface IAlarmManagementRepository
{
    /// <summary>
    /// init
    /// </summary>
    /// <returns></returns>
    Task<bool> InsertInitInfoAsync();

    /// <summary>
    /// 获取报警管理信息
    /// </summary>
    /// <returns></returns>
    Task<AlarmManagement?> GetAsync();

    /// <summary>
    /// 更新报警配置
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<bool> UpdateAsync(AlarmManagementDto input);
}