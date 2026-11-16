using UserService.DomainLib.Entities;

namespace UserService.ApplicationLib.Repositories;

/// <summary>
/// 
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> UserExistsAsync(UserId id);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    Task AddAsync(User user);
}
