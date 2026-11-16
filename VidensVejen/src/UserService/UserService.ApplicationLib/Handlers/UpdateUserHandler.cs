using UserService.FacadeLib.Commands.DTOs;
using UserService.FacadeLib.Commands.Interfaces;
using UserService.FacadeLib.Queries.DTOs;

namespace UserService.ApplicationLib.Handlers;

/// <summary>
/// 
/// </summary>
public class UpdateUserHandler : IUpdateUserHandler
{
    Task<UserDto> IUpdateUserHandler.HandleAsync(UpdateUserCommand command)
    {
        throw new NotImplementedException();
    }
}
