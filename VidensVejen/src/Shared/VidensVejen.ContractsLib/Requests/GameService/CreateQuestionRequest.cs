namespace VidensVejen.ContractsLib.Requests.GameService;

/// <summary>
/// 
/// </summary>
/// <param name="Text"></param>
/// <param name="ImageKey"></param>
/// <param name="Choices"></param>
public record CreateQuestionRequest(
    string Text,
    string ImageKey,
    List<CreateChoiceRequest> Choices
    )
{
    /// <summary>
    /// The text you want the choice to have.
    /// </summary>
    public string Text { get; init; } = Text;

    /// <summary>
    /// Mathces the key of an image uploaded in the same request
    /// </summary>
    public string ImageKey { get; init; } = ImageKey;

    /// <summary>
    /// A list of the choices you want the question to have.
    /// </summary>
    public List<CreateChoiceRequest> Choices { get; init; } = Choices;
}
