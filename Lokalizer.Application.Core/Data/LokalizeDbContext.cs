using Microsoft.EntityFrameworkCore;
using Lokalizer.Application.Contracts;

namespace Lokalizer.Application.Core.Data;

public class LokalizerDbContext : DbContext
{
    public LokalizerDbContext(DbContextOptions<LokalizerDbContext> options) : base(options)
    {
    }

    public DbSet<WeatherForecast> WeatherForecasts { get; set; }
    public DbSet<TestEntity> TestEntities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<WeatherForecast>(entity =>
        {
            entity.HasKey(e => e.Date);
            entity.Property(e => e.Summary)
                .HasMaxLength(200);
        });

        modelBuilder.Entity<TestEntity>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsRequired();
            entity.Property(e => e.Description)
                .HasMaxLength(500);
            entity.Property(e => e.CreatedAt)
                .IsRequired();
        });
    }
}