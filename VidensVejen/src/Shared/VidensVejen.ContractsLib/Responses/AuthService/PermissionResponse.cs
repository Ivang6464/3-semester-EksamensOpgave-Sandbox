namespace VidensVejen.ContractsLib.Responses.AuthService;

/// <summary>
/// 
/// </summary>
/// <param name="Id"></param>
/// <param name="Name"></param>
/// <example>
/// {
///     "id": "7693612e-45b7-430c-a182-318f1fc86442",
///     "name": "game.read"
/// }
/// </example>
public record PermissionResponse(
    Guid Id,
    string Name
    );
