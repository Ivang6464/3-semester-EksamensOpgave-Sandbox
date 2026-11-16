using AuthService.ApplicationLib.Authentication;
using Microsoft.AspNetCore.Identity;

namespace AuthService.InfrastructureLib.Authentication;

/// <summary>
/// 
/// </summary>
public class PasswordHashService : IPasswordHashService
{
    private readonly PasswordHasher<object> _passwordHasher = new();
    private readonly object _passwordHasherUser = new();

    string IPasswordHashService.Hash(string password)
    {
        var hashedPassword = _passwordHasher.HashPassword(_passwordHasherUser, password);

        return hashedPassword;
    }

    bool IPasswordHashService.Verify(string password, string passwordHash)
    {
        var result = _passwordHasher.VerifyHashedPassword(_passwordHasherUser, passwordHash, password);

        if (result == PasswordVerificationResult.Failed)
            return false;

        return true;
    }
}
