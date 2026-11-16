using AuthService.FacadeLib.Commands.DTOs;
using VidensVejen.ContractsLib.Requests.AuthService;

namespace AuthService.Api.Mappers;

internal static class AuthMapper
{
    internal static LoginUserCommand AsLoginCommand(this LoginUserRequest request)
    {
        var output = new LoginUserCommand(
            request.Email,
            request.Password
            );

        return output;
    }

    internal static RefreshTokenCommand AsRefreshCommand(this RefreshTokenRequest request)
    {
        var output = new RefreshTokenCommand(
            request.AccessToken,
            request.RefreshToken);

        return output;
    }
}
