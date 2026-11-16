namespace VidensVejen.ContractsLib.Responses.ImageService;

/// <summary>
/// 
/// </summary>
/// <param name="FileName"></param>
/// <example>
/// {
///     "fileName": "Forebyggelse.123e4567-e89b-12d3-a456-426614174000.png"
/// }
/// </example>
public record ImageFileNameResponse(
    string FileName
    )
{
    /// <summary>
    /// The filename of the image.
    /// </summary>
    public string FileName { get; init; } = FileName;
}
