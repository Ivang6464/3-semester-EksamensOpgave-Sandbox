using AuthService.FacadeLib.Commands.Interfaces;

namespace AuthService.ApplicationLib.Handlers.Users;

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
