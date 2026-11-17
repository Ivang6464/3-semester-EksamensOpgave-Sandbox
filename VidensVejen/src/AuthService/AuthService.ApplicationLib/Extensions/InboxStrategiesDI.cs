using AuthService.ApplicationLib.Messaging.Inbox.Strategies;
using Microsoft.Extensions.DependencyInjection;

namespace AuthService.ApplicationLib.Extensions;

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
        services.AddScoped<IInboxMessageStrategy, ActivateUserInboxStrategy>();

        return services;
    }
}
