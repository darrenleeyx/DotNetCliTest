using System.Reflection;
using CliTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CliTest.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public DbSet<Weather> Weathers { get; set; } = null!;

    public ApplicationDbContext(DbContextOptions options)
        : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        base.OnModelCreating(modelBuilder);
    }
}