namespace VidensVejen.ContractsLib.Requests.GameService;

/// <summary>
/// 
/// </summary>
/// <param name="Text"></param>
/// <param name="CorrectAnswer"></param>
/// <param name="ImageKey"></param>
public record CreateChoiceRequest(
    string Text,
    bool CorrectAnswer,
    string ImageKey
    );
