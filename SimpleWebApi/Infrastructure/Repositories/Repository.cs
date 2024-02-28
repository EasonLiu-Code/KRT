using Microsoft.EntityFrameworkCore;
using SimpleWebApi.Domain.IRepository;

namespace SimpleWebApi.Infrastructure.Repositories;

/// <summary>
/// BaseRepository
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public class Repository<TEntity>:IRepository<TEntity> where TEntity:class
{
    /// <summary></summary>
    private readonly DataDbContext _dataDbContext;

    /// <summary>
    /// ctor
    /// </summary>
    /// <param name="dataDbContext"></param>
    protected Repository(DataDbContext dataDbContext)
    {
        _dataDbContext = dataDbContext;
    }

    /// <summary>
    /// GetAllAsync
    /// </summary>
    /// <returns></returns>
    public async Task<List<TEntity>> GetAllAsync()
    {
        return  await _dataDbContext.Set<TEntity>().ToListAsync();
    }

    /// <summary>
    /// FirstOrDefaultAsync
    /// </summary>
    /// <returns></returns>
    public async Task<TEntity?> FirstOrDefaultAsync()
    {
        return await _dataDbContext.Set<TEntity>().FirstOrDefaultAsync();

    }
}