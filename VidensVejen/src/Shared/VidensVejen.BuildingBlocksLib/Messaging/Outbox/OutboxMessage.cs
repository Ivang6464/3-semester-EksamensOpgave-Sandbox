namespace VidensVejen.BuildingBlocksLib.Messaging.Outbox;

/// <summary>
/// 
/// </summary>
public class OutboxMessage
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
    public DateTime CreatedAtUtc { get; init; }

    /// <summary>
    /// 
    /// </summary>
    public DateTime? PublishedAtUtc { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public void SetPublishAtUtc()
    {
        PublishedAtUtc = DateTime.UtcNow;
    }
}
