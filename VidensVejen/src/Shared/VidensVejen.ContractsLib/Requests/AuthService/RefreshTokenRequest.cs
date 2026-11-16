namespace VidensVejen.ContractsLib.Requests.AuthService;

/// <summary>
/// 
/// </summary>
/// <param name="AccessToken"></param>
/// <param name="RefreshToken"></param>
/// <example>
/// {
///   "accessToken": "example-access-token",
///   "refreshToken": "example-refresh-token"
/// }
/// </example>
public record RefreshTokenRequest(
    string AccessToken,
    string RefreshToken
    );
