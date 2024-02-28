namespace SimpleWebApi.Infrastructure.CommonDto.VehicleInspection;

/// <summary>
/// VehicleInspectionLocationDto
/// </summary>
public class VehicleInspectionLocationDto
{
    /// <summary>
    /// 检测位置
    /// </summary>
    public string? InspectionLocation { get; set; }

    /// <summary>
    /// 错误原因
    /// </summary>
    public string? InspectionStatus { get; set; }

    /// <summary>
    /// 图片url
    /// </summary>
    public string? ImageUrl { get; set; }
}