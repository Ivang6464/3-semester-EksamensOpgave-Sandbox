using Microsoft.Extensions.DependencyInjection;
using UserService.ApplicationLib.Repositories;
using UserService.InfrastructureLib.Repositories;
using VidensVejen.BuildingBlocksLib.Messaging.Inbox;
using VidensVejen.BuildingBlocksLib.Messaging.Outbox;

namespace UserService.InfrastructureLib.Extensions;

/// <summary>
/// 
/// </summary>
public static class RepositoryDI
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddRepositoryDI(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IOutboxRepository, OutboxRepository>();
        services.AddScoped<IInboxRepository, InboxRepository>();

        return services;
    }
}
