using UserService.FacadeLib.Commands.DTOs;
using UserService.FacadeLib.Queries.DTOs;

namespace UserService.FacadeLib.Commands.Interfaces;

/// <summary>
/// 
/// </summary>
public interface IUpdateUserHandler
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    Task<UserDto> HandleAsync(UpdateUserCommand command);
}
