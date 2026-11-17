using Microsoft.Extensions.DependencyInjection;
using UserService.ApplicationLib.Messaging.Inbox.Strategies;
using VidensVejen.BuildingBlocksLib.Messaging.Inbox;

namespace UserService.ApplicationLib.Extensions;

/// <summary>
/// 
/// </summary>
public static class InboxStrategiesDI
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddInboxStrategiesDI(this IServiceCollection services)
    {
        services.AddScoped<IInboxMessageStrategy, CreateUserInboxStrategy>();
        services.AddScoped<IInboxMessageStrategy, DeleteUserInboxStrategy>();

        return services;
    }
}
