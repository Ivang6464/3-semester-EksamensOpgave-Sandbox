using AuthService.FacadeLib.Commands.DTOs;
using AuthService.FacadeLib.Queries.DTOs;

namespace AuthService.FacadeLib.Commands.Interfaces;

/// <summary>
/// 
/// </summary>
public interface IUpdateUserPermissionsHandler
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    Task<AuthUserDto> HandleAsync(UpdateAuthUserPermissionsCommand command);
}
