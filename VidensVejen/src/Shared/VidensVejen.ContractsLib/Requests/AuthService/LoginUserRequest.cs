namespace VidensVejen.ContractsLib.Requests.AuthService;

/// <summary>
/// 
/// </summary>
/// <param name="Email"></param>
/// <param name="Password"></param>
/// <example>
/// {
///     "email":"SueStorm@FantasticFour.test",
///     "password":"MySecretPassword123"
/// }
/// </example>
public record LoginUserRequest(
    string Email,
    string Password
    )
{
    /// <summary>
    /// The email of the user.
    /// </summary>
    public string Email { get; init; } = Email;

    /// <summary>
    /// The password of the user.
    /// </summary>
    public string Password { get; init; } = Password;
}
