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
}