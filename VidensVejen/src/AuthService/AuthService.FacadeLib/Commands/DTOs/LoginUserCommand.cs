namespace AuthService.FacadeLib.Commands.DTOs;

/// <summary>
/// 
/// </summary>
/// <param name="Email"></param>
/// <param name="Password"></param>
public record LoginUserCommand(
    string Email,
    string Password
    );
