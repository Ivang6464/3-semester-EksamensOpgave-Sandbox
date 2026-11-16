using AuthService.ApplicationLib.Repositories;
using AuthService.DomainLib.Entities;
using AuthService.InfrastructureLib.Persistence;

namespace AuthService.InfrastructureLib.Repositories;


/// <summary>
/// 
/// </summary>
/// <param name="db"></param>
public class PermissionRepository(AuthUserDbContext db) : IPermissionRepository
{
    async Task<AccessPermission?> IPermissionRepository.GetPermissionByIdAsync(AccessPermissionId id)
    {
        return await db.Permissions.FindAsync(id);
    }
}
