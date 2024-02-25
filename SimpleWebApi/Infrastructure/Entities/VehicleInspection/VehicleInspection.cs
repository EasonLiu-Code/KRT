using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SimpleWebApi.Infrastructure.Entities.VehicleInspection;

/// <summary>
/// 车辆检查
/// </summary>
[Table("VehicleInspection")]
public  class VehicleInspection:BaseEntity
{
    /// <summary>
    /// vin
    /// </summary>
    [Comment("Vin")]
    public string? Vin { get; set; }
    
    /// <summary>
    /// 检测项目
    /// </summary>
    [MaxLength(255)]
    public string? InspectionItem { get; set; }
    
    /// <summary>
    /// 检测时间
    /// </summary>
    public DateTime InspectionTime { get; set; }
    
    /// <summary>
    /// 错误原因
    /// </summary>
    public string? InspectionStatus { get; set; }

    /// <summary>
    /// 图片url
    /// </summary>
    public string? ImageUrl { get; set; }
}