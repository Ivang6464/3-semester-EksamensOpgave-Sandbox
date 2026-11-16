namespace VidensVejen.ContractsLib.Events;

/// <summary>
/// 
/// </summary>
/// <param name="EventId"></param>
/// <param name="UserId"></param>
/// <param name="Firstname"></param>
/// <param name="Surname"></param>
/// <param name="Email"></param>
public record UserRegisteredIntegrationEvent(
    Guid EventId,
    Guid UserId,
    string Firstname,
    string Surname,
    string Email
    );
