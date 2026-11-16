namespace UserService.FacadeLib.Commands.DTOs;

/// <summary>
/// 
/// </summary>
/// <param name="Id"></param>
/// <param name="Email"></param>
public record UpdateUserEmailCommand(
    Guid Id,
    string Email
    );
