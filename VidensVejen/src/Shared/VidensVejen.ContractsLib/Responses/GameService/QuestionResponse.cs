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
    );
