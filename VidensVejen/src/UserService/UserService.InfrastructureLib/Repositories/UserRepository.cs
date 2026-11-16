using Microsoft.EntityFrameworkCore;
using UserService.ApplicationLib.Repositories;
using UserService.DomainLib.Entities;
using UserService.InfrastructureLib.Persistence;

namespace UserService.InfrastructureLib.Repositories;

/// <summary>
/// 
/// </summary>
/// <param name="db"></param>
public class UserRepository(UserDbContext db) : IUserRepository
{
    async Task IUserRepository.AddAsync(User user)
    {
        await db.Users.AddAsync(user);
    }

    async Task<bool> IUserRepository.UserExistsAsync(UserId id)
    {
        return await db.Users.AnyAsync(u => u.Id == id);
    }
}
