namespace VidensVejen.ContractsLib.Requests.ExhibitionService;

/// <summary>
/// 
/// </summary>
/// <param name="Id"></param>
/// <param name="Title"></param>
/// <param name="Description"></param>
/// <param name="Body"></param>
/// <param name="CalloutLabel"></param>
/// <param name="CalloutText"></param>
/// <param name="Qoute"></param>
/// <param name="ImageKey"></param>
public record UpdateTopicRequest(
    Guid Id,
    string Title,
    string Description,
    string Body,
    string CalloutLabel,
    string CalloutText,
    string Qoute,
    string ImageKey
    )
{
    /// <summary>
    /// A unique identifier for a topic.
    /// </summary>
    public Guid Id { get; init; } = Id;

    /// <summary>
    /// The title of the topic.
    /// </summary>
    public string Title { get; init; } = Title;

    /// <summary>
    /// The description of the topic.
    /// </summary>
    public string Description { get; init; } = Description;

    /// <summary>
    /// The text body of the topic.
    /// </summary>
    public string Body { get; init; } = Body;

    /// <summary>
    /// The first text in the highlighted box.
    /// </summary>
    public string CalloutLabel { get; init; } = CalloutLabel;

    /// <summary>
    /// The text in the highlighted box.
    /// </summary>
    public string CalloutText { get; init; } = CalloutText;

    /// <summary>
    /// The qoute of the mascot
    /// </summary>
    public string Qoute { get; init; } = Qoute;

    /// <summary>
    /// Mathces the key of an image uploaded in the same request
    /// </summary>
    public string ImageKey { get; init; } = ImageKey;
}
