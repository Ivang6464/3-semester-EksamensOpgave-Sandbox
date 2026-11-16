namespace VidensVejen.ContractsLib.Requests.GameService;

/// <summary>
/// 
/// </summary>
/// <param name="Id"></param>
/// <param name="Text"></param>
/// <param name="CorrectAnswer"></param>
/// <param name="ImageKey"></param>
public record UpdateChoiceRequest(
    Guid Id,
    string Text,
    bool CorrectAnswer,
    string ImageKey
    )
{
    /// <summary>
    /// A unique identifier for the choice.
    /// </summary>
    public Guid Id { get; init; } = Id;

    /// <summary>
    /// The text you want the choice to have.
    /// </summary>
    public string Text { get; init; } = Text;

    /// <summary>
    /// Marks the choice as correct
    /// </summary>
    public bool CorrectAnswer { get; init; } = CorrectAnswer;

    /// <summary>
    /// Mathces the key of an image uploaded in the same request
    /// </summary>
    public string ImageKey { get; init; } = ImageKey;
}
