namespace VidensVejen.ContractsLib.Requests.GameService;

/// <summary>
/// 
/// </summary>
/// <param name="Id"></param>
/// <param name="Text"></param>
/// <param name="ImageKey"></param>
/// <param name="Choices"></param>
public record UpdateQuestionRequest(
    Guid Id,
    string Text,
    string ImageKey,
    List<UpdateChoiceRequest> Choices
    )
{
    /// <summary>
    /// A unique identifier for the question.
    /// </summary>
    public Guid Id { get; init; } = Id;

    /// <summary>
    /// The text you want the question to have.
    /// </summary>
    public string Text { get; init; } = Text;

    /// <summary>
    /// Mathces the key of an image uploaded in the same request
    /// </summary>
    public string ImageKey { get; init; } = ImageKey;

    /// <summary>
    /// A list of the choices you want to update.
    /// </summary>
    public List<UpdateChoiceRequest> Choices { get; init; } = Choices;
}
