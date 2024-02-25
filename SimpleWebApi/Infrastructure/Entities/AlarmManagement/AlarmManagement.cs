namespace SimpleWebApi.Infrastructure.Entities.AlarmManagement;

/// <summary>
/// 报警管理
/// </summary>
public class AlarmManagement:BaseEntity
{
    /// <summary>
    /// 整车声光
    /// </summary>
    public int VehicleSoundAndLight { get; set; }

    /// <summary>
    /// 整车线体
    /// </summary>
    public int VehicleLineBody { get; set; }

    /// <summary>
    /// 整车显示器
    /// </summary>
    public int VehicleDisplay { get; set; }

    /// <summary>
    /// Vin声光报警
    /// </summary>
    public int VinSoundAndLightAlarm { get; set; }

    /// <summary>
    /// Vin线体报警
    /// </summary>
    public int VinLineBodyAlarm { get; set; }

    /// <summary>
    /// Vin显示器报警
    /// </summary>
    /// <returns></returns>
    public int VinDisplayAlarm { get; set; }

    /// <summary>
    /// 护板声光报警
    /// </summary>
    public int GuardPanelSoundAndLightAlarm { get; set; }

    /// <summary>
    /// 护板线体报警
    /// </summary>
    public int GuardPaneLineBodyAlarm { get; set; }

    /// <summary>
    /// 护板显示器报警
    /// </summary>
    public int GuardPaneDisplayAlarm { get; set; }

    /// <summary>
    /// 铭牌声光报警
    /// </summary>
    public int NameplateSoundAndLightAlarm { get; set; }

    /// <summary>
    /// 铭牌线体报警
    /// </summary>
    public int NameplateLineBodyAlarm { get; set; }

    /// <summary>
    /// 铭牌显示器报警
    /// </summary>
    public int NameplateDisplayAlarm { get; set; }
}