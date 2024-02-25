namespace SimpleWebApi.Infrastructure.CommonDto.VehicleInspection;

/// <summary>
/// 车辆检查Dto
/// </summary>
public class VehicleInspectionDto
{
    /// <summary>
    /// vin
    /// </summary>
    public string? Vin { get; set; }
    
    /// <summary>
    /// 检测项目
    /// </summary>
    public string? InspectionItem { get; set; }
    
    /// <summary>
    /// 错误原因
    /// </summary>
    public string? InspectionStatus { get; set; }

    /// <summary>
    /// 图片url
    /// </summary>
    public string? ImageUrl { get; set; }
}