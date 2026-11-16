using AuthService.DomainLib.Entities;

namespace AuthService.ApplicationLib.Repositories;

/// <summary>
/// 
/// </summary>
public interface IPermissionRepository
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<AccessPermission?> GetPermissionByIdAsync(AccessPermissionId id);
}
