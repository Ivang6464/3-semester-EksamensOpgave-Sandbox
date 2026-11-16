namespace VidensVejen.ContractsLib.Requests.AuthService;

/// <summary>
/// 
/// </summary>
/// <param name="PermissionsIds"></param>
/// <example>
/// {
///     "permissionsIds": [
///                         "68A14B26-15D6-4831-A876-221B01260C6B",
///                         "A5D70BF0-67D1-4A14-BF0B-2857D3307E11"
///                     ]
/// }
/// </example>
public record UpdateAuthUserPermissionsRequest(List<Guid> PermissionsIds)
{
    /// <summary>
    /// List of guids required to find correct permission.
    /// </summary>
    public List<Guid> PermissionIds { get; init; } = PermissionsIds;
}
