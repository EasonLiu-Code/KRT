using Microsoft.EntityFrameworkCore;
using SimpleWebApi.Domain.IRepository;
using SimpleWebApi.Infrastructure.Entities;

namespace SimpleWebApi.Infrastructure.Repositories;

/// <summary>
/// BaseRepository
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public class Repository<TEntity>:IRepository<TEntity> where TEntity:BaseEntity
{
    /// <summary></summary>
    protected readonly DataDbContext DataDbContext;

    /// <summary>
    /// ctor
    /// </summary>
    /// <param name="dataDbContext"></param>
    protected Repository(DataDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    /// <summary>
    /// GetAllAsync
    /// </summary>
    /// <returns></returns>
    public async Task<List<TEntity>> GetAllAsync()
    {
        return  await DataDbContext.Set<TEntity>().ToListAsync();
    }

    /// <summary>
    /// FirstOrDefaultAsync
    /// </summary>
    /// <returns></returns>
    public async Task<TEntity?> FirstOrDefaultAsync()
    {
        return await DataDbContext.Set<TEntity>().FirstOrDefaultAsync();

    }

    /// <summary>
    /// FirstOrDefaultAsNoTrackAsync
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<TEntity?> FirstOrDefaultAsNoTrackAsync()
    {
        return await DataDbContext.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync();
    }
}