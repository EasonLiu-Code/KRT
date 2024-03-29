using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SimpleWebApi.Infrastructure.Entities;

/// <summary>
/// entity基层
/// </summary>
public class BaseEntity
{
    /// <summary> 主键 </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public virtual int Id { get; set; }
    
    /// <summary>是否删除</summary>
    [Description("是否删除")]
    [Comment("是否删除")]
    public virtual bool IsDeleted { get; set; }
    /// <summary></summary>
    public virtual void Delete()
    {
        IsDeleted = true;
    }

    /// <summary></summary>
    public virtual void UnDelete()
    {
        IsDeleted = false;
    }
    
}