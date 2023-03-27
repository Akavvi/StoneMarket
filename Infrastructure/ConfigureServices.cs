using Infrastructure.Context;
using Infrastructure.Database.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class ConfigureInfrastructureServices
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHostedService<MigrateService>();

        var hostname = configuration["DB_HOST"];
        var user = configuration["DB_USER"];
        var password = configuration["DB_PASSWORD"];
        var database = configuration["DB_NAME"];
        var port = configuration["DB_PORT"];

        services
            .AddDbContext<DatabaseContext>(
                options =>
                    options
                        .UseNpgsql(
                            $"Host={hostname};Port={port};Database={database};Username={user};Password={password}")
                        .UseSnakeCaseNamingConvention()
            );
    }
}