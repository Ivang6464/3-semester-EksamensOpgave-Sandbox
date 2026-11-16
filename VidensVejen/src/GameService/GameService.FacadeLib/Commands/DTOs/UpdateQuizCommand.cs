namespace GameService.FacadeLib.Commands.DTOs;

/// <summary>
/// 
/// </summary>
/// <param name="Id"></param>
/// <param name="Title"></param>
/// <param name="ExhibitionId"></param>
/// <param name="QuizLayout"></param>
/// <param name="Questions"></param>
public record UpdateQuizCommand(
    Guid Id,
    string Title,
    Guid ExhibitionId,
    string QuizLayout,
    List<UpdateQuestionCommand> Questions
    );
