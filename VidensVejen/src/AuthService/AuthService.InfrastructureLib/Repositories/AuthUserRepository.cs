using AuthService.ApplicationLib.Repositories;
using AuthService.DomainLib.Entities;
using AuthService.DomainLib.ValueObjects;
using AuthService.InfrastructureLib.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AuthService.InfrastructureLib.Repositories;

/// <summary>
/// 
/// </summary>
/// <param name="db"></param>
public class AuthUserRepository(AuthUserDbContext db) : IAuthUserRepository
{
    async Task<bool> IAuthUserRepository.EmailExistAsync(Email email)
    {
        return await db.AuthUsers.AnyAsync(e => e.Email == email);
    }

    async Task<AuthUser?> IAuthUserRepository.GetAuthUserByEmailAsync(Email email)
    {
        return await db.AuthUsers.FirstOrDefaultAsync(e => e.Email == email);
    }

    async Task<AuthUser?> IAuthUserRepository.GetAuthUserByIdAsync(AuthUserId id)
    {
        return await db.AuthUsers.FirstOrDefaultAsync(u => u.Id == id);
    }

    async Task IAuthUserRepository.RegisterAsync(AuthUser authUser)
    {
        await db.AuthUsers.AddAsync(authUser);
    }

    Task IAuthUserRepository.SaveAsync()
    {
        throw new NotImplementedException();
    }
}
