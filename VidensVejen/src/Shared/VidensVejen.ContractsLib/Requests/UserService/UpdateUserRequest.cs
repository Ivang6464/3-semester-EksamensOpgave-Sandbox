namespace VidensVejen.ContractsLib.Requests.UserService;

/// <summary>
/// 
/// </summary>
/// <param name="Firstname"></param>
/// <param name="Surname"></param>
/// <example>
/// {
///     "firstname": "Sue",
///     "surname": "Storm",
/// }
/// </example>
public record UpdateUserRequest(
    string Firstname,
    string Surname
    );
