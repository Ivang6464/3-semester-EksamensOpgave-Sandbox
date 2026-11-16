using VidensVejen.SharedKernelLib.Exceptions;

namespace AuthService.DomainLib.Entities;

/// <summary>
/// 
/// </summary>
public class AccessPermission
{
    /// <summary>
    /// 
    /// </summary>
    public AccessPermissionId Id { get; init; } = null!;

    /// <summary>
    /// 
    /// </summary>
    public string Name { get; init; } = string.Empty;

    internal AccessPermission(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("Permission name could not be set, no value");

        Id = new AccessPermissionId(Guid.NewGuid());
        Name = name;
    }

    private AccessPermission() { }
}
