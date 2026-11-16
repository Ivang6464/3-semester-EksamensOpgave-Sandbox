namespace ExhibitionService.FacadeLib.Queries.DTOs;

/// <summary>
/// 
/// </summary>
/// <param name="Id"></param>
/// <param name="Slug"></param>
/// <param name="Title"></param>
/// <param name="Description"></param>
/// <param name="Topics"></param>
public record SubjectDto(
    Guid Id,
    string Slug,
    string Title,
    string Description,
    IReadOnlyList<TopicDto> Topics
    );
