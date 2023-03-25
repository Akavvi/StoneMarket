using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Infrastructure.Database.Services;

public class MigrateService : IHostedService
{
    private readonly IServiceScopeFactory _factory;

    public MigrateService(IServiceScopeFactory factory) => _factory = factory;

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var scope = _factory.CreateScope();
        var ctx = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
        await ctx.Database.MigrateAsync(cancellationToken);
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}