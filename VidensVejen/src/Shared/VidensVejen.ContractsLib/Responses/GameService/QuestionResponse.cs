namespace VidensVejen.ContractsLib.Responses.GameService;

/// <summary>
/// 
/// </summary>
/// <param name="Id"></param>
/// <param name="Text"></param>
/// <param name="Choices"></param>
public record QuestionResponse(
    Guid Id,
    string Text,
    List<ChoiceResponse> Choices
    )
{
    /// <summary>
    /// A unique identifier for the question.
    /// </summary>
    public Guid Id { get; init; } = Id;

    /// <summary>
    /// The text you want the choice to have.
    /// </summary>
    public string Text { get; init; } = Text;

    /// <summary>
    /// A list of the choices associated to the question.
    /// </summary>
    public List<ChoiceResponse> Choices { get; init; } = Choices;
}
