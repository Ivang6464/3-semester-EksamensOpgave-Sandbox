using AuthService.FacadeLib.Commands.DTOs;
using AuthService.FacadeLib.Commands.Interfaces;

namespace AuthService.ApplicationLib.Handlers.Users;

/// <summary>
/// 
/// </summary>
public class UpdateUserPasswordHandler : IUpdateUserPasswordHandler
{
    Task IUpdateUserPasswordHandler.HandleAsync(UpdateAuthUserPasswordCommand command)
    {
        throw new NotImplementedException();
    }
}
