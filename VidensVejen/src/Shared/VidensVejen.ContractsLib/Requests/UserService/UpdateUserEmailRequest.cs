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
    )
{
    /// <summary>
    /// The email of the user.
    /// </summary>
    public string Email { get; init; } = Email;
}
