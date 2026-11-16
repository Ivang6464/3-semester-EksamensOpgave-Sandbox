using UserService.DomainLib.Entities;
using UserService.DomainLib.ValueObjects;
using VidensVejen.SharedKernelLib.Exceptions;

namespace UserService.DomainLib.Tests;

public class UserTests
{
    private const string Firstname = "Sue";
    private const string Surname = "Storm";
    private const string EmailAddress = "sue@example.com";

    [Fact]
    public void Create_GivenValidInput_InitializesUser()
    {
        // Arrange
        var id = new UserId(Guid.NewGuid());
        var expectedEmail = new Email(EmailAddress);

        // Act
        var user = User.Create(id, Firstname, Surname, EmailAddress);

        // Assert
        Assert.Equal(id.Value, user.Id.Value);
        Assert.Equal(Firstname, user.Firstname);
        Assert.Equal(Surname, user.Surname);
        Assert.Equal(expectedEmail, user.EmailAddress);
    }

    [Fact]
    public void Create_GivenNullId_ThrowsDomainException()
    {
        // Arrange
        UserId? id = null;

        // Act & Assert
        Assert.Throws<DomainException>(() => User.Create(id!, Firstname, Surname, EmailAddress));
    }

    [Fact]
    public void Create_GivenEmptyId_ThrowsDomainException()
    {
        // Arrange
        var id = new UserId(Guid.Empty);

        // Act & Assert
        Assert.Throws<DomainException>(() => User.Create(id, Firstname, Surname, EmailAddress));
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Create_GivenBlankFirstname_ThrowsDomainException(string? invalidValue)
    {
        // Arrange
        var id = new UserId(Guid.NewGuid());

        // Act & Assert
        Assert.Throws<DomainException>(() => User.Create(id, invalidValue!, Surname, EmailAddress));
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Create_GivenBlankSurname_ThrowsDomainException(string? invalidValue)
    {
        // Arrange
        var id = new UserId(Guid.NewGuid());

        // Act & Assert
        Assert.Throws<DomainException>(() => User.Create(id, Firstname, invalidValue!, EmailAddress));
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Create_GivenBlankEmail_ThrowsDomainException(string? invalidValue)
    {
        // Arrange
        var id = new UserId(Guid.NewGuid());

        // Act & Assert
        Assert.Throws<DomainException>(() => User.Create(id, Firstname, Surname, invalidValue!));
    }
}
