using AuthService.FacadeLib.Commands.DTOs;
using AuthService.FacadeLib.Commands.Interfaces;
using AuthService.FacadeLib.Queries.DTOs;

namespace AuthService.ApplicationLib.Handlers.Users;

/// <summary>
/// 
/// </summary>
public class UpdateUserEmailHandler : IUpdateUserEmailHandler
{
    Task<AuthUserEmailDto> IUpdateUserEmailHandler.HandleAsync(UpdateAuthUserEmailCommand command)
    {
        throw new NotImplementedException();
    }
}
