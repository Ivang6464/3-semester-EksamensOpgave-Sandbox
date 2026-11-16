using AuthService.FacadeLib.Commands.DTOs;

namespace AuthService.FacadeLib.Commands.Interfaces;

/// <summary>
/// 
/// </summary>
public interface ILoginUserHandler
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    Task<TokenDto?> HandleAsync(LoginUserCommand command);
}
