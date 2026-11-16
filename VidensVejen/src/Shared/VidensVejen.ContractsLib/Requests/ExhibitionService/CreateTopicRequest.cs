namespace VidensVejen.ContractsLib.Requests.ExhibitionService;

/// <summary>
/// 
/// </summary>
/// <param name="Title"></param>
/// <param name="Description"></param>
/// <param name="Body"></param>
/// <param name="CalloutLabel"></param>
/// <param name="CalloutText"></param>
/// <param name="Qoute"></param>
/// <param name="ImageKey"></param>
public record CreateTopicRequest(
    string Title,
    string Description,
    string Body,
    string CalloutLabel,
    string CalloutText,
    string Qoute,
    string ImageKey
    );
