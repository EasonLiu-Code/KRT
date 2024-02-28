using SimpleWebApi.Domain.IRepository;

namespace SimpleWebApi.Infrastructure.Repositories;

/// <summary>
/// BaseRepository
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public class Repository<TEntity>:IRepository<TEntity> where TEntity:class
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
    
}