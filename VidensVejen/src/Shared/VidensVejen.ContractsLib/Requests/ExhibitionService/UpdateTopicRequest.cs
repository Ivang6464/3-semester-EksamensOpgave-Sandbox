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
    );
