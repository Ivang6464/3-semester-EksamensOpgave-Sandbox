using ImageService.FacadeLib.Commands.DTOs;
using ImageService.FacadeLib.Queries.DTOs;
using VidensVejen.ContractsLib.Requests.ImageService;
using VidensVejen.ContractsLib.Responses.ImageService;

namespace ImageService.Api.Mappers;

internal static class ImageMapper
{
    internal static ImageUrlResponse AsResponse(this ImageUrlDto dto)
    {
        var output = new ImageUrlResponse(
            dto.FileName
            );

        return output;
    }

    internal static UploadImageCommand AsUploadCommand(this UploadImageRequest request)
    {
        var output = new UploadImageCommand(
            request.FileName
            );

        return output;
    }
}
