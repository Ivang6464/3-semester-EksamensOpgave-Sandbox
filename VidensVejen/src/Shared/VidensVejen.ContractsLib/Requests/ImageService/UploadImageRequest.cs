namespace VidensVejen.ContractsLib.Requests.ImageService;

/// <summary>
/// 
/// </summary>
/// <param name="FileName"></param>
/// <example>
/// {
///     "fileName": "Forebyggelse"
/// }
/// </example>
public record UploadImageRequest(
    string FileName
    )
{
    /// <summary>
    /// The filename of the image.
    /// </summary>
    public string FileName { get; init; } = FileName;
}
