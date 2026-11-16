using AuthService.FacadeLib.Queries.DTOs;
using AuthService.FacadeLib.Queries.Interfaces;
using AuthService.InfrastructureLib.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AuthService.InfrastructureLib.QueryHandlers;

/// <summary>
/// 
/// </summary>
/// <param name="db"></param>
public class AuthUserQueryHandlerIMPL(AuthUserDbContext db) : IAuthUsersQueries
{
    async Task<AuthUserDto?> IAuthUsersQueries.GetByIdAsync(Guid id)
    {
        return await db.AuthUsers
            .AsNoTracking()
            .Select(
            u => new AuthUserDto(
                u.Id.Value,
                u.Email.Value,
                u.Permissions.Select(p => new AccessPermissionDto(p.Id.Value, p.Name)).ToList()))
            .FirstOrDefaultAsync();
    }
}
