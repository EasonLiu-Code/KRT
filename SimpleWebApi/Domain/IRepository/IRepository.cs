namespace SimpleWebApi.Domain.IRepository;

/// <summary>
/// IRepository
/// </summary>
public interface IRepository<TEntity>
{
    /// <summary>
    /// GetAllAsync
    /// </summary>
    /// <returns></returns>
    Task<List<TEntity>> GetAllAsync();

    /// <summary>
    /// FirstOrDefaultAsync
    /// </summary>
    /// <returns></returns>
    Task<TEntity?> FirstOrDefaultAsync();
    
}