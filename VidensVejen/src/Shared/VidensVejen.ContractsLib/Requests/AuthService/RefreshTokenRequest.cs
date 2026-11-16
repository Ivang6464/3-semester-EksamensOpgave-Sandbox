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
    )
{
    /// <summary>
    /// The access token of the user
    /// </summary>
    public string AccessToken { get; init; } = AccessToken;

    /// <summary>
    /// The refresh token of the user
    /// </summary>
    public string RefreshToken { get; init; } = RefreshToken;
}
