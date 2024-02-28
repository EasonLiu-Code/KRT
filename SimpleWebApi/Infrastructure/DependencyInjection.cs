
using SimpleWebApi.Domain.IRepository;
using SimpleWebApi.Infrastructure.Repositories;

namespace SimpleWebApi.Infrastructure;

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
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IVehicleInspectionRepository, VehicleInspectionRepository>();
        services.AddScoped<IAlarmManagementRepository, AlarmManagementRepository>();
        services.AddScoped(typeof(IRepository<>),typeof(IRepository<>));
        return services;
    }
    
}