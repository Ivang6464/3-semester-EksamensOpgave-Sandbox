using GameService.FacadeLib.Commands.DTOs;
using GameService.FacadeLib.Queries.DTOs;

namespace GameService.FacadeLib.Commands.Interfaces;

/// <summary>
/// 
/// </summary>
public interface IUpdateQuizHandler
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    Task<QuizDto> HandleAsync(UpdateQuizCommand command);
}
