using AuthService.FacadeLib.Queries.DTOs;
using VidensVejen.ContractsLib.Responses.AuthService;

namespace AuthService.Api.Mappers;

/// <summary>
/// 
/// </summary>
public static class PermissionMapper
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public static PermissionResponse AsResponse(this AccessPermissionDto dto)
    {
        var output = new PermissionResponse(
            dto.Id,
            dto.Name
            );

        return output;
    }
}
