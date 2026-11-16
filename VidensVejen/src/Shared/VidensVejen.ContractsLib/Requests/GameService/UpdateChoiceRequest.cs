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
    );
