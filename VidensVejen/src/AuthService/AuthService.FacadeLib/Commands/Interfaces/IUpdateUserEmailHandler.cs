using AuthService.FacadeLib.Commands.DTOs;
using AuthService.FacadeLib.Queries.DTOs;

namespace AuthService.FacadeLib.Commands.Interfaces;

/// <summary>
/// 
/// </summary>
public interface IUpdateUserEmailHandler
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    Task<AuthUserEmailDto> HandleAsync(UpdateAuthUserEmailCommand command);
}
