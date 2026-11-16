namespace VidensVejen.ContractsLib.Responses.ExhibitionService;

/// <summary>
/// 
/// </summary>
/// <param name="Id"></param>
/// <param name="Slug"></param>
/// <param name="Title"></param>
/// <param name="Description"></param>
/// <param name="Topics"></param>
public record SubjectResponse(
    Guid Id,
    string Slug,
    string Title,
    string Description,
    IReadOnlyList<TopicResponse> Topics
    );
