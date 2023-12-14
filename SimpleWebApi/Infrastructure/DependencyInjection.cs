namespace SimpleWebApi.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        //services.AddScoped<ITest,Test>();
        return services;
    }
    
}