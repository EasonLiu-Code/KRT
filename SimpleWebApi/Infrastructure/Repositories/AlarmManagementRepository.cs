using Microsoft.EntityFrameworkCore;
using SimpleWebApi.Domain.IRepository;
using SimpleWebApi.Infrastructure.CommonDto.AlarmManagement;
using SimpleWebApi.Infrastructure.Entities.AlarmManagement;

namespace SimpleWebApi.Infrastructure.Repositories;

/// <summary>
/// repo
/// </summary>
public class AlarmManagementRepository:IAlarmManagementRepository
{
    private readonly DataDbContext _dbContext;

    /// <summary>
    /// ctor
    /// </summary>
    /// <param name="dbContext"></param>
    public AlarmManagementRepository(DataDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// 初始化报警管理
    /// </summary>
    /// <returns></returns>
    public async Task<bool> InsertInitInfoAsync()
    {
        var alarmManagementCount = _dbContext.AlarmManagement.Count();
        if (alarmManagementCount >=1) return true;
        await _dbContext.AlarmManagement.AddAsync(new AlarmManagement
        {
            VehicleSoundAndLight=1,
            VehicleLineBody=1,
            VehicleDisplay=1,
            VinSoundAndLightAlarm=1,
            VinLineBodyAlarm=1,
            VinDisplayAlarm=1,
            GuardPanelSoundAndLightAlarm=1,
            GuardPaneLineBodyAlarm=1,
            GuardPaneDisplayAlarm=1,
            NameplateSoundAndLightAlarm=1,
            NameplateLineBodyAlarm=1,
            NameplateDisplayAlarm=1,
        });
        await _dbContext.SaveChangesAsync();
        return true;
    }

    /// <summary>
    /// 获取报警信息
    /// </summary>
    /// <returns></returns>
    public async Task<AlarmManagement?> GetAsync()
    {
        return await _dbContext.AlarmManagement.FirstOrDefaultAsync();
    }

    /// <summary>
    /// 更新报警信息配置
    /// </summary>
    /// <returns></returns>
    public async Task<bool> UpdateAsync(AlarmManagementDto input)
    {
        var alarmManagement = await _dbContext.AlarmManagement.FirstOrDefaultAsync();
        if (alarmManagement != null)
        {
            alarmManagement.VinDisplayAlarm = input.VinDisplayAlarm;
            alarmManagement.VinLineBodyAlarm = input.VinLineBodyAlarm;
            alarmManagement.VinSoundAndLightAlarm = input.VinSoundAndLightAlarm;
            alarmManagement.NameplateDisplayAlarm = input.NameplateDisplayAlarm;
            alarmManagement.NameplateLineBodyAlarm = input.NameplateLineBodyAlarm;
            alarmManagement.NameplateSoundAndLightAlarm = input.NameplateSoundAndLightAlarm;
            alarmManagement.VehicleDisplay = input.VehicleDisplay;
            alarmManagement.VehicleLineBody = input.VehicleLineBody;
            alarmManagement.VehicleSoundAndLight = input.VehicleSoundAndLight;
            alarmManagement.GuardPaneDisplayAlarm = input.GuardPaneDisplayAlarm;
            alarmManagement.GuardPaneLineBodyAlarm = input.GuardPaneLineBodyAlarm;
            alarmManagement.GuardPanelSoundAndLightAlarm = input.GuardPanelSoundAndLightAlarm;
        }

        await _dbContext.SaveChangesAsync();
        return true;
    }
    
}