using UserService.FacadeLib.Commands.Interfaces;

namespace UserService.ApplicationLib.Handlers;

/// <summary>
/// 
/// </summary>
public class DeleteUserHandler : IDeleteUserHandler
{
    Task IDeleteUserHandler.HandleAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}
