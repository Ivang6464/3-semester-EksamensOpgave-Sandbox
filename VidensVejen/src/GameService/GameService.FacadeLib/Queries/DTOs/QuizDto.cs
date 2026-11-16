namespace GameService.FacadeLib.Queries.DTOs;

/// <summary>
/// 
/// </summary>
/// <param name="Id"></param>
/// <param name="Title"></param>
/// <param name="ExhibitionId"></param>
/// <param name="QuizLayout"></param>
/// <param name="ImageFileName"></param>
/// <param name="Questions"></param>
public record QuizDto(
    Guid Id,
    string Title,
    Guid ExhibitionId,
    string QuizLayout,
    string ImageFileName,
    List<QuestionDto> Questions
    );
