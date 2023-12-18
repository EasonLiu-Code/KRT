using SimpleWebApi.Domain;

namespace SimpleWebApi.Infrastructure.Repositories;
/// <summary>
/// Repository example
/// </summary>
internal sealed class BaseRepository:IBaseRepository
{
    private readonly DataDbContext _context;

    public BaseRepository(DataDbContext context)
    {
        _context = context;
    }
    /// <summary>
    /// 唯一性验证
    /// </summary>
    /// <param name="mustUnique"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<bool> IsUniqueAsync(string mustUnique, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(true);
    }
}