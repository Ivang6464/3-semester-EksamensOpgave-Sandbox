using AuthService.ApplicationLib.Authentication;
using AuthService.InfrastructureLib.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace AuthService.InfrastructureLib.Extensions;

/// <summary>
/// 
/// </summary>
public static class ServiceDI
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddServiceDI(this IServiceCollection services)
    {
        services.AddScoped<IPasswordHashService, PasswordHashService>();

        return services;
    }
}
