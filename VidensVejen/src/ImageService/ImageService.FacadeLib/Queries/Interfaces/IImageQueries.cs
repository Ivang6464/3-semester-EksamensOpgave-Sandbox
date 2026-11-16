using ImageService.FacadeLib.Queries.DTOs;

namespace ImageService.FacadeLib.Queries.Interfaces;

/// <summary>
/// 
/// </summary>
public interface IImageQueries
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    Task<ImageUrlDto?> GetImageUrlByFileName(string fileName);
}
