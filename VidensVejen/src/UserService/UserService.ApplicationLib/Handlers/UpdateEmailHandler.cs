using UserService.FacadeLib.Commands.DTOs;
using UserService.FacadeLib.Commands.Interfaces;

namespace UserService.ApplicationLib.Handlers;

/// <summary>
/// 
/// </summary>
public class UpdateEmailHandler : IUpdateEmailHandler
{
    Task IUpdateEmailHandler.HandleAsync(UpdateUserEmailCommand command)
    {
        throw new NotImplementedException();
    }
}
