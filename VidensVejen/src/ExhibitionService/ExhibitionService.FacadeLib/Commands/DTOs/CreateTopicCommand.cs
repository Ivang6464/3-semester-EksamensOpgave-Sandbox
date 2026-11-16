namespace ExhibitionService.FacadeLib.Commands.DTOs;

/// <summary>
/// 
/// </summary>
/// <param name="Title"></param>
/// <param name="Description"></param>
/// <param name="Body"></param>
/// <param name="CalloutLabel"></param>
/// <param name="CalloutText"></param>
/// <param name="Qoute"></param>
public record CreateTopicCommand(
    string Title,
    string Description,
    string Body,
    string CalloutLabel,
    string CalloutText,
    string Qoute
    );
