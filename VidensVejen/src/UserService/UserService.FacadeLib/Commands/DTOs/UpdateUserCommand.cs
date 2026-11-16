namespace UserService.FacadeLib.Commands.DTOs;

/// <summary>
/// 
/// </summary>
/// <param name="Id"></param>
/// <param name="Firstname"></param>
/// <param name="Surname"></param>
public record UpdateUserCommand(
    Guid Id,
    string Firstname,
    string Surname
    );
