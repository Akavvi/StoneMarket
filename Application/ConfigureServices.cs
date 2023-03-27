using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ConfigureApplicationServices
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<Mapping>();
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });
    }
}