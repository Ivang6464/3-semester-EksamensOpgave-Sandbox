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
    );
