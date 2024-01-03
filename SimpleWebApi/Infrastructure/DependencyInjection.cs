﻿
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
        return services;
    }
    
}