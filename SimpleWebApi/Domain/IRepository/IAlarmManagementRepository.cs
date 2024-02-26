namespace SimpleWebApi.Domain.IRepository;

/// <summary>
/// I
/// </summary>
public interface IAlarmManagementRepository
{
    /// <summary>
    /// init
    /// </summary>
    /// <returns></returns>
    Task<bool> InsertInitInfoAsync();
}