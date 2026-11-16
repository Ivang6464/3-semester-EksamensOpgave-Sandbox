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
    );

