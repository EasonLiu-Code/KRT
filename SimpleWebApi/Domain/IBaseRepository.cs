namespace SimpleWebApi.Domain;

public interface IBaseRepository
{
    Task<bool> IsUniqueAsync(string mustUnique, CancellationToken cancellationToken = default);
}