using AuthService.FacadeLib.Queries.DTOs;
using AuthService.FacadeLib.Queries.Interfaces;
using AuthService.InfrastructureLib.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AuthService.InfrastructureLib.QueryHandlers;

/// <summary>
/// 
/// </summary>
/// <param name="db"></param>
public class PermissionQueryHandlerIMPL(AuthUserDbContext db) : IPermissionsQueries
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    async Task<IReadOnlyList<AccessPermissionDto>> IPermissionsQueries.GetAllPermissionsAsync()
    {
        return await db.Permissions
            .AsNoTracking()
            .Select(a =>
            new AccessPermissionDto(
                a.Id.Value,
                a.Name))
            .ToListAsync();
    }
}
