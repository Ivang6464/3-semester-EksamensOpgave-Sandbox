using Microsoft.AspNetCore.OpenApi;

namespace VidensVejen.BuildingBlocksLib.DependencyInjection;

/// <summary>
/// 
/// </summary>
public static class OpenApiDI
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="options"></param>
    /// <param name="serviceName"></param>
    public static void WithCustomApiInfo(this OpenApiOptions options, string serviceName)
    {
        options.AddDocumentTransformer((document, context, cancellationToken) =>
        {
            document.Info.Title = $"{serviceName} Api | v1";
            document.Info.Description = $"{serviceName} Api for Videns Vejen";

            return Task.CompletedTask;
        });
    }
}
