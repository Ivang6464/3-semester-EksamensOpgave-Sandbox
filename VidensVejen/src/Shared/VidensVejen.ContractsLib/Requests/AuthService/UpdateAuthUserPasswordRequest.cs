namespace VidensVejen.ContractsLib.Requests.AuthService;


/// <summary>
/// 
/// </summary>
/// <param name="Password"></param>
/// <example>
/// {
///     "password":"MySecretPassword123"
/// }
/// </example>
public record UpdateAuthUserPasswordRequest(string Password)
{
    /// <summary>
    /// The password of the user.
    /// </summary>
    public string Password { get; init; } = Password;
};
