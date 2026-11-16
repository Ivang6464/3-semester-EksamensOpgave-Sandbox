namespace AuthService.FacadeLib.Commands.DTOs;

/// <summary>
/// 
/// </summary>
/// <param name="Id"></param>
/// <param name="PermissionsIds"></param>
public record UpdateAuthUserPermissionsCommand(Guid Id, List<Guid> PermissionsIds);
