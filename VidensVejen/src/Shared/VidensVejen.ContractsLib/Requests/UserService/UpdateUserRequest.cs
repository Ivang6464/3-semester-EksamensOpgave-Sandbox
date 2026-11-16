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
}
