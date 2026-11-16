namespace VidensVejen.ContractsLib.Responses.UserService;

/// <summary>
/// 
/// </summary>
/// <param name="Id"></param>
/// <param name="FirstName"></param>
/// <param name="Surname"></param>
/// <param name="Email"></param>
/// <example>
/// {
///     "id": "123e4567-e89b-12d3-a456-426614174000",
///     "firstname": "Sue",
///     "surname": "Storm",
///     "email": "SueStorm@FantasticFour.test"
/// }
/// </example>
public record UserResponse(
    Guid Id,
    string FirstName,
    string Surname,
    string Email
    );
