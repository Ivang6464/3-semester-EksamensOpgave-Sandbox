namespace VidensVejen.ContractsLib.Events;

/// <summary>
/// 
/// </summary>
/// <param name="EventId"></param>
/// <param name="EventTopic"></param>
/// <param name="UserId"></param>
/// <param name="Firstname"></param>
/// <param name="Surname"></param>
/// <param name="Email"></param>
/// <example>
/// {
///     "eventId": "5724e1de-00ce-4b6a-9d99-e820fbd5cc9d",
///     "eventTopic": "User-Registered",
///     "userId": "5724e1de-00ce-4b6a-9d99-e820fbd5cc9d",
///     "firstname": "Sue",
///     "surname": "Storm",
///     "email": "SueStorm@FantasticFour.test"
/// }
/// </example>
public record UserRegisteredIntegrationEvent(
    Guid EventId,
    string EventTopic,
    Guid UserId,
    string Firstname,
    string Surname,
    string Email
    )
{
    /// <summary>
    /// A unique identifier for the event.
    /// </summary>
    public Guid EventId { get; init; } = EventId;

    /// <summary>
    /// A unique identifier for the user.
    /// </summary>
    public Guid UserId { get; init; } = UserId;

    /// <summary>
    /// The topic of the event
    /// </summary>
    public string EventTopic { get; init; } = EventTopic;

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
}
