namespace AuthService.FacadeLib.Commands.DTOs;

/// <summary>
/// 
/// </summary>
/// <param name="Id"></param>
/// <param name="Permissions"></param>
public record UpdateAuthUserPermissionsCommand(Guid Id, List<string> Permissions);
