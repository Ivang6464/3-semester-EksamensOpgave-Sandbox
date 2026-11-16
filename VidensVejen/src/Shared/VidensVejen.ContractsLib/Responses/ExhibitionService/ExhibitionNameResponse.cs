namespace VidensVejen.ContractsLib.Responses.ExhibitionService;

/// <summary>
/// 
/// </summary>
/// <param name="Name"></param>
/// <example>
/// {
///     "name": "Vand og hav"
/// }
/// </example>
public record ExhibitionNameResponse(string Name)
{
    /// <summary>
    /// The name of the exhibition.
    /// </summary>
    public string Name { get; init; } = Name;
}
