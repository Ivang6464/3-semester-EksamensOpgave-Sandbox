namespace VidensVejen.ContractsLib.Requests.ExhibitionService;

/// <summary>
/// 
/// </summary>
/// <param name="Title"></param>
/// <param name="Description"></param>
/// <param name="Topics"></param>
public record CreateSubjectRequest(
    string Title,
    string Description,
    List<CreateTopicRequest> Topics
    );
