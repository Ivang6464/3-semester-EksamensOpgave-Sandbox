using ImageService.FacadeLib.Commands.DTOs;
using ImageService.FacadeLib.Queries.DTOs;

namespace ImageService.FacadeLib.Commands.Interfaces;

/// <summary>
/// 
/// </summary>
public interface IUploadImageHandler
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    Task<ImageFileNameDto> HandleAsync(UploadImageCommand command);
}
