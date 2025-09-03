using Microsoft.EntityFrameworkCore;
using Lokalizer.Application.Contracts;

namespace Lokalizer.Application.Core.Data;

public static class DatabaseSeeder
{
    public static async Task SeedAsync(LokalizerDbContext context)
    {
        if (!await context.TestEntities.AnyAsync())
        {
            var testEntities = new[]
            {
                new TestEntity
                {
                    Name = "Sample Entity 1",
                    Description = "This is a sample test entity for demonstration purposes",
                    CreatedAt = DateTime.UtcNow.AddDays(-5),
                    IsActive = true
                },
                new TestEntity
                {
                    Name = "Sample Entity 2",
                    Description = "Another sample test entity with different data",
                    CreatedAt = DateTime.UtcNow.AddDays(-3),
                    IsActive = true
                },
                new TestEntity
                {
                    Name = "Inactive Entity",
                    Description = "This entity is marked as inactive for testing purposes",
                    CreatedAt = DateTime.UtcNow.AddDays(-1),
                    IsActive = false
                }
            };

            await context.TestEntities.AddRangeAsync(testEntities);
        }

        if (!await context.WeatherForecasts.AnyAsync())
        {
            var weatherForecasts = new[]
            {
                new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now),
                    TemperatureC = 25,
                    Summary = "Sunny"
                },
                new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
                    TemperatureC = 18,
                    Summary = "Cloudy"
                },
                new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(2)),
                    TemperatureC = 12,
                    Summary = "Rainy"
                }
            };

            await context.WeatherForecasts.AddRangeAsync(weatherForecasts);
        }

        await context.SaveChangesAsync();
    }
}