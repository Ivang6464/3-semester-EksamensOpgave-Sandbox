using System.Security.Cryptography;
using AuthService.ApplicationLib.Authentication;

namespace AuthService.InfrastructureLib.Authentication;

/// <summary>
/// 
/// </summary>
public class RefreshTokenService : IRefreshTokenService
{
    string IRefreshTokenService.GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }
}
