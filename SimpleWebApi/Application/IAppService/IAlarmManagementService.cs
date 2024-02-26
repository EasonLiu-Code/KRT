namespace SimpleWebApi.Application.IAppService;

/// <summary>
/// I
/// </summary>
public interface IAlarmManagementService
{
    /// <summary>
    /// init
    /// </summary>
    /// <returns></returns>
    Task<bool> InsertInitInfoAsync();
}