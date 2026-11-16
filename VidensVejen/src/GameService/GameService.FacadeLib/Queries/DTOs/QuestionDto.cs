namespace GameService.FacadeLib.Queries.DTOs;

/// <summary>
/// 
/// </summary>
/// <param name="Id"></param>
/// <param name="Text"></param>
/// <param name="ExhibitionId"></param>
/// <param name="QuizLayout"></param>
/// <param name="Choices"></param>
public record QuestionDto(
    Guid Id,
    string Text,
    Guid ExhibitionId,
    string QuizLayout,
    List<ChoiceDto> Choices
    );
