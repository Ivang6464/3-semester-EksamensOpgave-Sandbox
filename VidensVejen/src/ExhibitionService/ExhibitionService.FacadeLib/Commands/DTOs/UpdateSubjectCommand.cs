namespace ExhibitionService.FacadeLib.Commands.DTOs;

/// <summary>
/// 
/// </summary>
/// <param name="Id"></param>
/// <param name="Title"></param>
/// <param name="Description"></param>
/// <param name="Topics"></param>
public record UpdateSubjectCommand(
    Guid Id,
    string Title,
    string Description,
    List<UpdateTopicCommand> Topics
    );
