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
    );
