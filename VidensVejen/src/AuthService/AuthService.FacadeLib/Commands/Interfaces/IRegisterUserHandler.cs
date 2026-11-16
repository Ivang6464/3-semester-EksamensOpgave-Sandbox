using AuthService.FacadeLib.Commands.DTOs;

namespace AuthService.FacadeLib.Commands.Interfaces;

/// <summary>
/// 
/// </summary>
public interface IRegisterUserHandler
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    Task HandleAsync(RegisterUserCommand command);

}
