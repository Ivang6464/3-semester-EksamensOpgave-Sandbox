using VidensVejen.BuildingBlocksLib.Messaging.Outbox;

namespace VidensVejen.BuildingBlocksLib.Messaging.Inbox;

/// <summary>
/// 
/// </summary>
public interface IInboxMessageStrategy
{
    /// <summary>
    /// 
    /// </summary>
    string EventType { get; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="eventId"></param>
    /// <param name="content"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<OutboxMessage?> ApplyAsync(Guid eventId, string content, CancellationToken cancellationToken);
}
