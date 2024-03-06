using Microsoft.EntityFrameworkCore;
using SimpleWebApi.Infrastructure;

namespace SimpleWebApi.Migrations;

/// <summary>
/// MigrationExtensions
/// </summary>
public static class MigrationExtensions
{
    /// <summary>
    /// ApplyMigrations
    /// </summary>
    /// <param name="app"></param>
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();
        using DataDbContext dbContext = scope.ServiceProvider.GetRequiredService<DataDbContext>();
        dbContext.Database.Migrate();
    }
}