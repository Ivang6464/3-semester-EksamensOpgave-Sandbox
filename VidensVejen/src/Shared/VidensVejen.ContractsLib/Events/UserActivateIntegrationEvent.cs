namespace VidensVejen.ContractsLib.Events;

/// <summary>
/// 
/// </summary>
/// <param name="EventId"></param>
/// <param name="UserId"></param>
public record UserActivateIntegrationEvent(
    Guid EventId,
    Guid UserId
    );
