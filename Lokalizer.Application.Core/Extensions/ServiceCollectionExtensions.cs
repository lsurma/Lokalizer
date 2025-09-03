using Lokalizer.Application.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Lokalizer.Application.Core.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddLokalizerDatabase(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<LokalizerDbContext>(options =>
            options.UseSqlite(connectionString));

        return services;
    }

    public static async Task InitializeDatabaseAsync(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<LokalizerDbContext>();

        await context.Database.MigrateAsync();
        await DatabaseSeeder.SeedAsync(context);
    }
}