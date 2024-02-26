using SimpleWebApi.Application.AppService;
using SimpleWebApi.Application.IAppService;

namespace SimpleWebApi.Application;

/// <summary>
/// DI
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    ///  add Di extension methods
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddAppServiceApplication(this IServiceCollection services)
    {
        services.AddScoped<IAlarmManagementService, AlarmManagementService>();
        return services;
    }
}