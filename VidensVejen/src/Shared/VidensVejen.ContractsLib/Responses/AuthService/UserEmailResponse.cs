namespace VidensVejen.ContractsLib.Responses.AuthService;

/// <summary>
/// 
/// </summary>
/// <param name="Email"></param>
/// <example>
/// {
///     "email": "SueStorm@FantasticFour.test"
/// }
/// </example>
public record UserEmailResponse(string Email)
{
    /// <summary>
    /// The email of the user.
    /// </summary>
    public string Email { get; init; } = Email;
}
