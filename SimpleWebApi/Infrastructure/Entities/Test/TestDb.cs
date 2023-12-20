using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleWebApi.Infrastructure.Entities.Test;

[Table("TestDb")]
public partial class TestDb:BaseEntity
{
    [MaxLength(255)]
    public string? Url { get; set; }

    [MaxLength(255)]
    public string? TestDate { get; set; }
}