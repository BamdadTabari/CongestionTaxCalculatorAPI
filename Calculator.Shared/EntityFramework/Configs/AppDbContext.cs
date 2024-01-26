using Calculator.Shared.EntityFramework.Entities.TaxEntities;
using Calculator.Shared.EntityFramework.Seeding;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Calculator.Shared.EntityFramework.Configs;
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Apply Configurations
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        modelBuilder.Entity<TaxRule>().HasData(TaxRuleSeed.All);
        // Creating Model
        base.OnModelCreating(modelBuilder);
    }
}
