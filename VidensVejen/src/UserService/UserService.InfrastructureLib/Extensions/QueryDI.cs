using Microsoft.Extensions.DependencyInjection;
using UserService.FacadeLib.Queries.Interfaces;
using UserService.InfrastructureLib.QueryHandlers;

namespace UserService.InfrastructureLib.Extensions;

/// <summary>
/// 
/// </summary>
public static class QueryDI
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddQueryDI(this IServiceCollection services)
    {
        services.AddScoped<IUserQueries, UserQueryHandlerIMPL>();

        return services;
    }
}
