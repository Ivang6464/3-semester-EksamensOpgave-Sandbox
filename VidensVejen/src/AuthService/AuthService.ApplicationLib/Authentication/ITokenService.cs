using System.Security.Claims;
using AuthService.DomainLib.Entities;

namespace AuthService.ApplicationLib.Authentication;

/// <summary>
/// 
/// </summary>
public interface ITokenService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="authUser"></param>
    /// <returns></returns>
    string CreateToken(AuthUser authUser);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="expiredAccessToken"></param>
    /// <returns></returns>
    ClaimsPrincipal GetPrincipalFromExpiredToken(string expiredAccessToken);
}
