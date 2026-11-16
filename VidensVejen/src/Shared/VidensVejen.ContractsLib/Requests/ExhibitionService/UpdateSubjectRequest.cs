namespace VidensVejen.ContractsLib.Requests.ExhibitionService;

/// <summary>
/// 
/// </summary>
/// <param name="Id"></param>
/// <param name="Title"></param>
/// <param name="Description"></param>
/// <param name="Topics"></param>
public record UpdateSubjectRequest(
    Guid Id,
    string Title,
    string Description,
    List<UpdateTopicRequest> Topics
    );
