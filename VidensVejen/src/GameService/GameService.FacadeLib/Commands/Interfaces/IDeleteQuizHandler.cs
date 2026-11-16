namespace GameService.FacadeLib.Commands.Interfaces;

/// <summary>
/// 
/// </summary>
public interface IDeleteQuizHandler
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task HandleAsync(Guid id);
}
