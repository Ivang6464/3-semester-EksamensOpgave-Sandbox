namespace VidensVejen.ContractsLib.Responses.ImageService;

/// <summary>
/// 
/// </summary>
/// <param name="Url"></param>
/// <example>
/// {
///     "url": "https://example.com/image"
/// }
/// </example>
public record ImageUrlResponse(
    string Url
    )
{
    /// <summary>
    /// The url of the image.
    /// </summary>
    public string Url { get; init; } = Url;
}
