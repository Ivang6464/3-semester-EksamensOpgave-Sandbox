namespace VidensVejen.BuildingBlocksLib.Messaging.Inbox;

/// <summary>
/// 
/// </summary>
public interface IInboxRepository
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="message"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task StoreIfMissingAsync(InboxMessage message, CancellationToken cancellationToken);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="limit"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IReadOnlyList<Guid>> GetPendingIdsAsync(int limit, CancellationToken cancellationToken);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="eventId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<InboxMessage?> FindAsync(Guid eventId, CancellationToken cancellationToken);
}
