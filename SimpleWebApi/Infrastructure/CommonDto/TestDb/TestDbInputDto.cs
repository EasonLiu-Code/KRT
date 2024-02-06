namespace SimpleWebApi.Infrastructure.CommonDto.TestDb;

/// <summary>
/// 入参Dto
/// </summary>
public class TestDbInputDto
{
    /// <summary>
    /// Cursor
    /// </summary>
    public long Cursor { get; set; }

    /// <summary>
    /// PageSize
    /// </summary>
    public int PageSize { get; set; }
}