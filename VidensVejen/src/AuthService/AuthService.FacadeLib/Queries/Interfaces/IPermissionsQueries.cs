using AuthService.FacadeLib.Queries.DTOs;

namespace AuthService.FacadeLib.Queries.Interfaces;

/// <summary>
/// 
/// </summary>
public interface IPermissionsQueries
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<IReadOnlyList<AccessPermissionDto>> GetAllPermissionsAsync();
}
