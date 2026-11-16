using Microsoft.Extensions.DependencyInjection;
using UserService.InfrastructureLib.UnitOfWorks;
using VidensVejen.BuildingBlocksLib.UnitOfWork;

namespace UserService.InfrastructureLib.Extensions;

/// <summary>
/// 
/// </summary>
public static class UnitOfWorkDI
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddUnitOfWorkDI(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, EFUnitOfWork>();

        return services;
    }
}
