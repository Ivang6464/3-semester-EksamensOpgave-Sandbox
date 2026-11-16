using Microsoft.AspNetCore.Builder;
using Scalar.AspNetCore;

namespace VidensVejen.BuildingBlocksLib.DependencyInjection;

/// <summary>
/// 
/// </summary>
public static class ScalarDI
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="app"></param>
    /// <param name="serviceName"></param>
    /// <returns></returns>
    public static WebApplication AddCustomScalar(this WebApplication app, string serviceName)
    {
        app.MapScalarApiReference(options =>
        {
            options.Title = $"{serviceName} Api";
            ;
            options.HiddenClients = true;
            options.DocumentDownloadType = DocumentDownloadType.None;
        });

        return app;
    }
}
