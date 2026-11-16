namespace VidensVejen.ContractsLib.Responses.GameService;

/// <summary>
/// 
/// </summary>
/// <param name="Id"></param>
/// <param name="Text"></param>
/// <param name="CorrectAnswer"></param>
/// <param name="ImageUrl"></param>
public record ChoiceResponse(
    Guid Id,
    string Text,
    bool CorrectAnswer,
    string ImageUrl
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
    /// The url of the image assoicated to the choice
    /// </summary>
    public string ImageUrl { get; init; } = ImageUrl;
}
