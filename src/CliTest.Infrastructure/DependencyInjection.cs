using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CliTest.Infrastructure.Persistence;

namespace CliTest.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        return services
            .AddPersistence(connectionString);
    }

    public static IServiceCollection AddPersistence(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ApplicationDbContext>(options => {
            options.UseSqlServer(connectionString);
        });

        return services;
    }
}