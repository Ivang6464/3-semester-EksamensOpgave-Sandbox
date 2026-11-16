namespace VidensVejen.ContractsLib.Requests.AuthService;

/// <summary>
/// 
/// </summary>
/// <param name="Firstname"></param>
/// <param name="Surname"></param>
/// <param name="Email"></param>
/// <param name="Password"></param>
/// <param name="PermissionsIds"></param>
/// <example>
/// {
///     "firstname": "Sue",
///     "surname": "Storm",
///     "email": "SueStorm@FantasticFour.test",
///     "password": "MySecretPassword123",
///     "permissionsIds": ["68A14B26-15D6-4831-A876-221B01260C6B", "A5D70BF0-67D1-4A14-BF0B-2857D3307E11"]
/// }
/// </example>
public record RegisterUserRequest(
    string Firstname,
    string Surname,
    string Email,
    string Password,
    List<Guid> PermissionsIds
    )
{
    /// <summary>
    /// The firstname of the user.
    /// </summary>
    public string Firstname { get; init; } = Firstname;

    /// <summary>
    /// The surname of the user.
    /// </summary>
    public string Surname { get; init; } = Surname;

    /// <summary>
    /// The email of the user.
    /// </summary>
    public string Email { get; init; } = Email;

    /// <summary>
    /// The password of the user.
    /// </summary>
    public string Password { get; init; } = Password;

    /// <summary>
    /// List of guids required to find correct permission.
    /// </summary>
    public List<Guid> PermissionIds { get; init; } = PermissionsIds;
}
