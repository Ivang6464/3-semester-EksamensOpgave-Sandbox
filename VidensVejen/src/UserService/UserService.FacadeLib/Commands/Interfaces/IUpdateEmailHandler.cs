using UserService.FacadeLib.Commands.DTOs;

namespace UserService.FacadeLib.Commands.Interfaces;

/// <summary>
/// 
/// </summary>
public interface IUpdateEmailHandler
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    Task HandleAsync(UpdateUserEmailCommand command);
}
