namespace VidensVejen.ContractsLib.Requests.UserService;

/// <summary>
/// 
/// </summary>
/// <param name="Email"></param>
/// <example>
/// {
///     "email": "SueStorm@FantasticFour.test"
/// }
/// </example>
public record UpdateUserEmailRequest(
    string Email
    );
