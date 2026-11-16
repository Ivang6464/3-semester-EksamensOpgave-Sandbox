namespace GameService.FacadeLib.Commands.DTOs;

/// <summary>
/// 
/// </summary>
/// <param name="Text"></param>
/// <param name="ImageKey"></param>
/// <param name="Choices"></param>
public record CreateQuestionCommand(
    string Text,
    string ImageKey,
    List<CreateChoiceCommand> Choices
    );
