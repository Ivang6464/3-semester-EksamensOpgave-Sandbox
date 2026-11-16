using AuthService.InfrastructureLib.Messaging.Publishers;
using Microsoft.Extensions.DependencyInjection;
using VidensVejen.BuildingBlocksLib.Messaging.Publisher;

namespace AuthService.InfrastructureLib.Extensions;

/// <summary>
/// 
/// </summary>
public static class EventPublisherDI
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddEventPublisherDI(this IServiceCollection services)
    {
        services.AddScoped<IOutboxEventPublisher, DaprOutboxEventPublisher>();

        return services;
    }
}
