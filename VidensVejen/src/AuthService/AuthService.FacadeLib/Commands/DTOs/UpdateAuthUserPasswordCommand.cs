namespace AuthService.FacadeLib.Commands.DTOs;

/// <summary>
/// 
/// </summary>
/// <param name="Id"></param>
/// <param name="Password"></param>
public record UpdateAuthUserPasswordCommand(Guid Id, string Password);
