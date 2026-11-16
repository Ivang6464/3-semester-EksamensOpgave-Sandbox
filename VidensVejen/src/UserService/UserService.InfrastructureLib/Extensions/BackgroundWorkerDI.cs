using Microsoft.Extensions.DependencyInjection;
using UserService.InfrastructureLib.Messaging.Inbox;
using UserService.InfrastructureLib.Messaging.Outbox;

namespace UserService.InfrastructureLib.Extensions;

/// <summary>
/// 
/// </summary>
public static class BackgroundWorkerDI
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddBackgroundWorkerDI(this IServiceCollection services)
    {
        services.AddHostedService<InboxWorker>();
        services.AddHostedService<OutboxWorker>();

        return services;
    }
}
