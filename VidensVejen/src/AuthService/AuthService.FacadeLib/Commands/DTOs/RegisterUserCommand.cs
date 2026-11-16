namespace AuthService.FacadeLib.Commands.DTOs;

/// <summary>
/// 
/// </summary>
/// <param name="Firstname"></param>
/// <param name="Surname"></param>
/// <param name="Email"></param>
/// <param name="Password"></param>
/// <param name="PermissionsIds"></param>
public record RegisterUserCommand(
    string Firstname,
    string Surname,
    string Email,
    string Password,
    List<Guid> PermissionsIds
    );
