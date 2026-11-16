namespace VidensVejen.BuildingBlocksLib.Messaging.Publisher;

/// <summary>
/// 
/// </summary>
public interface IOutboxEventPublisher
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="topic"></param>
    /// <param name="integrationEvent"></param>
    /// <returns></returns>
    Task PublishAsync<T>(string topic, T integrationEvent);
}
