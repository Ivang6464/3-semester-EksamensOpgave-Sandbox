namespace VidensVejen.ContractsLib.Events;

/// <summary>
/// 
/// </summary>
/// <param name="EventId"></param>
/// <param name="UserId"></param>
/// <example>
/// {
///     "eventId": "5724e1de-00ce-4b6a-9d99-e820fbd5cc9d",
///     "userId": "5724e1de-00ce-4b6a-9d99-e820fbd5cc9d",
/// }
/// </example>
public record UserActivateIntegrationEvent(
    Guid EventId,
    Guid UserId
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
}
