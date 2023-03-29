using System.Reflection;
using Application.Behaviors;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ConfigureApplicationServices
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services
            .AddScoped<Mapping>()
            .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>))
            .AddMediatR(config =>
                {
                    config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                });
    }
}