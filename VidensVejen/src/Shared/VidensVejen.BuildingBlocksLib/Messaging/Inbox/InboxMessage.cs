namespace VidensVejen.BuildingBlocksLib.Messaging.Inbox;

/// <summary>
/// 
/// </summary>
public class InboxMessage
{
    /// <summary>
    /// 
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// 
    /// </summary>
    public required string Type { get; init; }

    /// <summary>
    /// 
    /// </summary>
    public required string Topic { get; init; }

    /// <summary>
    /// 
    /// </summary>
    public required string Content { get; init; }

    /// <summary>
    /// 
    /// </summary>
    public DateTime RecievedOnUtc { get; init; }

    /// <summary>
    /// 
    /// </summary>
    public DateTime? ProccessedOnUtc { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public void SetProccesedAtUtc()
    {
        ProccessedOnUtc = DateTime.UtcNow;
    }
}
