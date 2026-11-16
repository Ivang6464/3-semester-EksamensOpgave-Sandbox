namespace VidensVejen.ContractsLib.Requests.AuthService;

/// <summary>
/// 
/// </summary>
/// <param name="Permissions"></param>
/// <example>
/// {
///     "permissions": ["game.read", "game.edit"]
/// }
/// </example>
public record UpdateAuthUserPermissionsRequest(List<string> Permissions);
