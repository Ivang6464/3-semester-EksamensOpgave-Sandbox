using AuthService.DomainLib.Entities;
using VidensVejen.SharedKernelLib.Exceptions;

namespace AuthService.DomainLib.Tests;

public class AccessPermissionTests
{
    [Fact]
    public void Create_GivenValidPermissionName_SetsNameAndGeneratesId()
    {
        // Arrange
        const string PermissionName = "User.Create";

        // Act
        var permission = new AccessPermission(PermissionName);

        // Assert
        Assert.Equal(PermissionName, permission.Name);
        Assert.NotNull(permission.Id);
        Assert.NotEqual(Guid.Empty, permission.Id.Value);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Create_GivenBlankPermissionName_ThrowsDomainException(string? permissionName)
    {
        // Arrange
        const string ExpectedMessage = "Permission name could not be set, no value";

        // Act & Assert
        var exception = Assert.Throws<DomainException>(
            () => new AccessPermission(permissionName!));

        Assert.Equal(ExpectedMessage, exception.Message);
    }
}
