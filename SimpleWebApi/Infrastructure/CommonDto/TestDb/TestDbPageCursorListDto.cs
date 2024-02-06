namespace SimpleWebApi.Infrastructure.CommonDto.TestDb;

/// <summary>
/// Cursor分页
/// </summary>
public class TestDbPageCursorListDto
{
    /// <summary>
    /// Cursor
    /// </summary>
    public long Cursor { get; set; }
    
    /// <summary>
    /// TestDbs
    /// </summary>
    public List<Entities.Test.TestDb>? TestDbs { get; set; }
}