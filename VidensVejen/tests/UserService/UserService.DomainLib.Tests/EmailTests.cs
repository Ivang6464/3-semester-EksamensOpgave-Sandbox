using UserService.DomainLib.ValueObjects;
using VidensVejen.SharedKernelLib.Exceptions;

namespace UserService.DomainLib.Tests;

public class EmailTests
{
    [Fact]
    public void Constructor_GivenUppercaseAddress_StoresLowercaseAddress()
    {
        // Arrange
        const string Address = "SUE@EXAMPLE.COM";

        // Act
        var email = new Email(Address);

        // Assert
        Assert.Equal("sue@example.com", email.Value);
    }

    [Theory]
    [InlineData("sue.example.com")]
    [InlineData("")]
    [InlineData("   ")]
    public void Constructor_GivenAddressWithoutAtSign_ThrowsDomainException(string address)
    {
        // Act & Assert
        Assert.Throws<DomainException>(() => new Email(address));
    }
}
