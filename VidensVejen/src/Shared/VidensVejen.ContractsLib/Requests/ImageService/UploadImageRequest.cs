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
    );
