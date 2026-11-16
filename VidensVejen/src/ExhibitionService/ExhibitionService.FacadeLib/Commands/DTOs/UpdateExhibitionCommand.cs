namespace ExhibitionService.FacadeLib.Commands.DTOs;

/// <summary>
/// 
/// </summary>
/// <param name="Id"></param>
/// <param name="ExhibtionName"></param>
/// <param name="Subjects"></param>
public record UpdateExhibitionCommand(
    Guid Id,
    string ExhibtionName,
    List<UpdateSubjectCommand> Subjects
    );
