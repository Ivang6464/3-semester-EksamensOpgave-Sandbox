using AuthService.InfrastructureLib.Messaging.Inbox;
using AuthService.InfrastructureLib.Messaging.Outbox;
using Microsoft.Extensions.DependencyInjection;

namespace AuthService.InfrastructureLib.Extensions;

/// <summary>
/// 
/// </summary>
public static class BackgroundWorkersDI
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddBackgroundWorkersDI(this IServiceCollection services)
    {
        services.AddHostedService<OutboxWorker>();
        services.AddHostedService<InboxWorker>();

        return services;
    }
}
