namespace VidensVejen.BuildingBlocksLib.Messaging.Outbox;

/// <summary>
/// 
/// </summary>
public interface IOutboxRepository
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="outboxMessage"></param>
    /// <returns></returns>
    Task AddAsync(OutboxMessage outboxMessage);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="eventId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<OutboxMessage?> FindAsync(Guid eventId, CancellationToken cancellationToken);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="limit"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IReadOnlyList<Guid>> GetPendingIdsAsync(int limit, CancellationToken cancellationToken);
}
