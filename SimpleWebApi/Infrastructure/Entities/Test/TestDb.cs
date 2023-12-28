using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleWebApi.Infrastructure.Entities.Test;

/// <summary>
/// 
/// </summary>
[Table("TestDb")]
public partial class TestDb:BaseEntity
{
    /// <summary>
    /// 
    /// </summary>
    [MaxLength(255)]
    public string? Url { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [MaxLength(255)]
    public string? TestDate { get; set; }
}