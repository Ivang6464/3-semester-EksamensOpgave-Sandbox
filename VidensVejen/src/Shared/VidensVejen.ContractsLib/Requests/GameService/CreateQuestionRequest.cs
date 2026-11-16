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
    );
