namespace GameService.FacadeLib.Queries.DTOs;

/// <summary>
/// 
/// </summary>
/// <param name="Id"></param>
/// <param name="Text"></param>
/// <param name="CorrectAnswer"></param>
/// <param name="ImageFileName"></param>
public record ChoiceDto(
    Guid Id,
    string Text,
    bool CorrectAnswer,
    string ImageFileName
    );
