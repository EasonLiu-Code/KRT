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
    
    //----------example-----------
    // public Task<TEntity> GetByIdAsync(string TEntityid)
    // {
    //     return _context.TEntity
    //         .SingleOrDefaultAsync(c => c.Id == id);
    // }
    
}