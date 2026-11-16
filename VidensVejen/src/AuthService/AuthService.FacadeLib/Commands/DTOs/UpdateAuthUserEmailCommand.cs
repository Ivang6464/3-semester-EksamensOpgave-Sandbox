namespace AuthService.FacadeLib.Commands.DTOs;

/// <summary>
/// 
/// </summary>
/// <param name="Id"></param>
/// <param name="Email"></param>
public record UpdateAuthUserEmailCommand(Guid Id, string Email);
