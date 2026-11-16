using AuthService.FacadeLib.Commands.DTOs;
using AuthService.FacadeLib.Commands.Interfaces;
using AuthService.FacadeLib.Queries.DTOs;

namespace AuthService.ApplicationLib.Handlers.Users;

/// <summary>
/// 
/// </summary>
public class UpdateUserPermissionsHandler : IUpdateUserPermissionsHandler
{
    Task<AuthUserDto> IUpdateUserPermissionsHandler.HandleAsync(UpdateAuthUserPermissionsCommand command)
    {
        throw new NotImplementedException();
    }
}
