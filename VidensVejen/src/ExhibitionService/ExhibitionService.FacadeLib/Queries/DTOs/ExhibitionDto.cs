namespace ExhibitionService.FacadeLib.Queries.DTOs;

/// <summary>
/// 
/// </summary>
/// <param name="Id"></param>
/// <param name="Title"></param>
/// <param name="Subjects"></param>
/// <param name="ThemeFileName"></param>
public record ExhibitionDto(
    Guid Id,
    string Title,
    IReadOnlyList<SubjectDto> Subjects,
    string ThemeFileName
    );
