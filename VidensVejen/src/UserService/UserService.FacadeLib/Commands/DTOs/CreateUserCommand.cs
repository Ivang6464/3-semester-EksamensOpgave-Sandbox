namespace UserService.FacadeLib.Commands.DTOs;

/// <summary>
/// 
/// </summary>
/// <param name="Id"></param>
/// <param name="Firstname"></param>
/// <param name="Surname"></param>
/// <param name="Email"></param>
public record CreateUserCommand(
    Guid Id,
    string Firstname,
    string Surname,
    string Email
    );
