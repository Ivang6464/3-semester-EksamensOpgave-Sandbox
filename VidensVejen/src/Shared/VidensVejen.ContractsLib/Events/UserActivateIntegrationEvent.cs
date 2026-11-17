namespace VidensVejen.ContractsLib.Events;

/// <summary>
/// 
/// </summary>
/// <param name="EventId"></param>
/// <param name="EventTopic"></param>
/// <param name="UserId"></param>
/// <example>
/// {
///     "eventId": "5724e1de-00ce-4b6a-9d99-e820fbd5cc9d",
///     "eventTopic": "User-Activate",
///     "userId": "5724e1de-00ce-4b6a-9d99-e820fbd5cc9d"
/// }
/// </example>
public record UserActivateIntegrationEvent(
    Guid EventId,
    string EventTopic,
    Guid UserId
    )
{
    /// <summary>
    /// A unique identifier for the event.
    /// </summary>
    public Guid EventId { get; init; } = EventId;

    /// <summary>
    /// The topic of the event
    /// </summary>
    public string EventTopic { get; init; } = EventTopic;

    /// <summary>
    /// A unique identifier for the user.
    /// </summary>
    public Guid UserId { get; init; } = UserId;
}
