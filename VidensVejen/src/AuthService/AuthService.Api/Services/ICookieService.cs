using AuthService.FacadeLib.Commands.DTOs;

namespace AuthService.Api.Services;

/// <summary>
/// 
/// </summary>
public interface ICookieService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="token"></param>
    /// <param name="context"></param>
    void SetTokenInsideCookie(TokenDto token, HttpContext context);
}
