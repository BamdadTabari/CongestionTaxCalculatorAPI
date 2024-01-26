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

        // Creating Model
        base.OnModelCreating(modelBuilder);
    }
}
