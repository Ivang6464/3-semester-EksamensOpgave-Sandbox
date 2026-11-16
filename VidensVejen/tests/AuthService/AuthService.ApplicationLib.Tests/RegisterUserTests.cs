using System.Data;
using System.Reflection;
using System.Text.Json;
using AuthService.ApplicationLib.Authentication;
using AuthService.ApplicationLib.Handlers.Users;
using AuthService.ApplicationLib.Repositories;
using AuthService.DomainLib.Entities;
using AuthService.DomainLib.ValueObjects;
using AuthService.FacadeLib.Commands.DTOs;
using AuthService.FacadeLib.Commands.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;
using VidensVejen.BuildingBlocksLib.Messaging.Outbox;
using VidensVejen.BuildingBlocksLib.UnitOfWork;
using VidensVejen.ContractsLib.Events;
using VidensVejen.SharedKernelLib.Exceptions;

namespace AuthService.ApplicationLib.Tests;

public class RegisterUserTests
{
    private const string Firstname = "Henrik";
    private const string Surname = "Test";
    private const string EmailAddress = "Test@Example.com";
    private const string Password = "test-password";
    private const string PasswordHash = "test-password-hash";

    private static RegisterUserCommand CreateCommand(params Guid[] permissionIds)
    {
        return new RegisterUserCommand(
            Firstname: Firstname,
            Surname: Surname,
            Email: EmailAddress,
            Password: Password,
            PermissionsIds: [.. permissionIds]);
    }

    [Fact]
    public async Task Handle_GivenValidData_RegistersUserAndCommitsOutboxMessage()
    {
        // Arrange
        var mockAuthUserRepo = new Mock<IAuthUserRepository>();
        var mockPermissionRepo = new Mock<IPermissionRepository>();
        var mockOutbox = new Mock<IOutboxRepository>();
        var mockPasswordHashService = new Mock<IPasswordHashService>();
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var mockLogger = new Mock<ILogger<RegisterUserHandler>>();
        var permission = (AccessPermission)Activator.CreateInstance(
            typeof(AccessPermission),
            BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic,
            binder: null,
            args: ["User.Create"],
            culture: null)!;
        var command = CreateCommand(permission.Id.Value);

        mockPermissionRepo
            .Setup(r => r.GetPermissionByIdAsync(permission.Id))
            .ReturnsAsync(permission);
        AuthUser? registeredUser = null;
        OutboxMessage? outboxMessage = null;

        mockAuthUserRepo
            .Setup(r => r.EmailExistAsync(new Email(EmailAddress)))
            .ReturnsAsync(false);

        mockPasswordHashService
            .Setup(s => s.Hash(Password))
            .Returns(PasswordHash);

        mockAuthUserRepo
            .Setup(r => r.RegisterAsync(It.IsAny<AuthUser>()))
            .Callback<AuthUser>(user => registeredUser = user);

        mockOutbox
            .Setup(r => r.AddAsync(It.IsAny<OutboxMessage>()))
            .Callback<OutboxMessage>(message => outboxMessage = message);

        IRegisterUserHandler handler = new RegisterUserHandler(
            mockAuthUserRepo.Object,
            mockPermissionRepo.Object,
            mockOutbox.Object,
            mockPasswordHashService.Object,
            mockUnitOfWork.Object,
            mockLogger.Object);

        // Act
        await handler.HandleAsync(command);

        // Assert
        mockUnitOfWork.Verify(u => u.BeginTransaction(IsolationLevel.Serializable), Times.Once);
        mockAuthUserRepo.Verify(r => r.EmailExistAsync(new Email(EmailAddress)), Times.Once);
        mockPasswordHashService.Verify(s => s.Hash(Password), Times.Once);
        mockAuthUserRepo.Verify(r => r.RegisterAsync(It.IsAny<AuthUser>()), Times.Once);
        mockOutbox.Verify(r => r.AddAsync(It.IsAny<OutboxMessage>()), Times.Once);
        mockUnitOfWork.Verify(u => u.SaveChangesAsync(), Times.Once);
        mockUnitOfWork.Verify(u => u.Commit(), Times.Once);
        mockUnitOfWork.Verify(u => u.Rollback(), Times.Never);

        Assert.NotNull(registeredUser);
        Assert.Equal(new Email(command.Email), registeredUser.Email);
        Assert.Equal(PasswordHash, registeredUser.PasswordHash);
        Assert.Same(permission, Assert.Single(registeredUser.Permissions));
        mockPermissionRepo.Verify(r => r.GetPermissionByIdAsync(permission.Id), Times.Once);

        Assert.NotNull(outboxMessage);
        Assert.NotEqual(Guid.Empty, outboxMessage.Id);
        Assert.Equal(typeof(UserRegisteredIntegrationEvent).FullName, outboxMessage.Type);

        var expectedEvent = new UserRegisteredIntegrationEvent(
            outboxMessage.Id,
            registeredUser.Id.Value,
            command.Firstname,
            command.Surname,
            command.Email);

        Assert.Equal("user-registered", outboxMessage.Topic);
        var actualEvent = JsonSerializer.Deserialize<UserRegisteredIntegrationEvent>(outboxMessage.Content);
        Assert.Equivalent(expectedEvent, actualEvent);
    }

    [Fact]
    public async Task Handle_GivenExistingEmail_ThrowsExceptionAndRollsBack()
    {
        // Arrange
        var mockAuthUserRepo = new Mock<IAuthUserRepository>();
        var mockPermissionRepo = new Mock<IPermissionRepository>();
        var mockOutbox = new Mock<IOutboxRepository>();
        var mockPasswordHashService = new Mock<IPasswordHashService>();
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var mockLogger = new Mock<ILogger<RegisterUserHandler>>();
        var command = CreateCommand();

        mockAuthUserRepo
            .Setup(r => r.EmailExistAsync(new Email(EmailAddress)))
            .ReturnsAsync(true);

        IRegisterUserHandler handler = new RegisterUserHandler(
            mockAuthUserRepo.Object,
            mockPermissionRepo.Object,
            mockOutbox.Object,
            mockPasswordHashService.Object,
            mockUnitOfWork.Object,
            mockLogger.Object);

        // Act & Assert
        await Assert.ThrowsAsync<InvalidOperationException>(() => handler.HandleAsync(command));

        mockUnitOfWork.Verify(u => u.BeginTransaction(IsolationLevel.Serializable), Times.Once);
        mockUnitOfWork.Verify(u => u.Rollback(), Times.Once);
        mockUnitOfWork.Verify(u => u.Commit(), Times.Never);
        mockPasswordHashService.Verify(s => s.Hash(It.IsAny<string>()), Times.Never);
        mockAuthUserRepo.Verify(r => r.RegisterAsync(It.IsAny<AuthUser>()), Times.Never);
        mockOutbox.Verify(r => r.AddAsync(It.IsAny<OutboxMessage>()), Times.Never);
        mockUnitOfWork.Verify(u => u.SaveChangesAsync(), Times.Never);
    }

    [Fact]
    public async Task Handle_GivenUnknownPermissionId_ThrowsNotFoundExceptionAndRollsBack()
    {
        // Arrange
        var mockAuthUserRepo = new Mock<IAuthUserRepository>();
        var mockPermissionRepo = new Mock<IPermissionRepository>();
        var mockOutbox = new Mock<IOutboxRepository>();
        var mockPasswordHashService = new Mock<IPasswordHashService>();
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var mockLogger = new Mock<ILogger<RegisterUserHandler>>();
        var permissionId = new AccessPermissionId(Guid.NewGuid());
        var command = CreateCommand(permissionId.Value);

        mockPermissionRepo
            .Setup(r => r.GetPermissionByIdAsync(permissionId))
            .ReturnsAsync((AccessPermission?)null);

        mockAuthUserRepo
            .Setup(r => r.EmailExistAsync(new Email(EmailAddress)))
            .ReturnsAsync(false);

        IRegisterUserHandler handler = new RegisterUserHandler(
            mockAuthUserRepo.Object,
            mockPermissionRepo.Object,
            mockOutbox.Object,
            mockPasswordHashService.Object,
            mockUnitOfWork.Object,
            mockLogger.Object);

        // Act & Assert
        await Assert.ThrowsAsync<NotFoundException>(() => handler.HandleAsync(command));

        mockPermissionRepo.Verify(r => r.GetPermissionByIdAsync(permissionId), Times.Once);

        mockUnitOfWork.Verify(u => u.BeginTransaction(IsolationLevel.Serializable), Times.Once);
        mockUnitOfWork.Verify(u => u.Rollback(), Times.Once);
        mockUnitOfWork.Verify(u => u.Commit(), Times.Never);
        mockPasswordHashService.Verify(s => s.Hash(It.IsAny<string>()), Times.Never);
        mockAuthUserRepo.Verify(r => r.RegisterAsync(It.IsAny<AuthUser>()), Times.Never);
        mockOutbox.Verify(r => r.AddAsync(It.IsAny<OutboxMessage>()), Times.Never);
        mockUnitOfWork.Verify(u => u.SaveChangesAsync(), Times.Never);
    }

    [Fact]
    public async Task Handle_GivenOutboxFailure_RethrowsExceptionAndRollsBack()
    {
        // Arrange
        var mockAuthUserRepo = new Mock<IAuthUserRepository>();
        var mockPermissionRepo = new Mock<IPermissionRepository>();
        var mockOutbox = new Mock<IOutboxRepository>();
        var mockPasswordHashService = new Mock<IPasswordHashService>();
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var mockLogger = new Mock<ILogger<RegisterUserHandler>>();
        var command = CreateCommand();
        var expected = new InvalidOperationException("Outbox write failed");

        mockAuthUserRepo
            .Setup(r => r.EmailExistAsync(new Email(EmailAddress)))
            .ReturnsAsync(false);

        mockPasswordHashService
            .Setup(service => service.Hash(Password))
            .Returns(PasswordHash);

        mockOutbox
            .Setup(repository => repository.AddAsync(It.IsAny<OutboxMessage>()))
            .ThrowsAsync(expected);

        IRegisterUserHandler handler = new RegisterUserHandler(
            mockAuthUserRepo.Object,
            mockPermissionRepo.Object,
            mockOutbox.Object,
            mockPasswordHashService.Object,
            mockUnitOfWork.Object,
            mockLogger.Object);

        // Act & Assert
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => handler.HandleAsync(command));
        Assert.Same(expected, exception);

        mockUnitOfWork.Verify(u => u.BeginTransaction(IsolationLevel.Serializable), Times.Once);
        mockUnitOfWork.Verify(u => u.Rollback(), Times.Once);
        mockUnitOfWork.Verify(u => u.Commit(), Times.Never);
        mockPasswordHashService.Verify(s => s.Hash(It.IsAny<string>()), Times.Once);
        mockAuthUserRepo.Verify(r => r.RegisterAsync(It.IsAny<AuthUser>()), Times.Once);
        mockOutbox.Verify(r => r.AddAsync(It.IsAny<OutboxMessage>()), Times.Once);
        mockUnitOfWork.Verify(u => u.SaveChangesAsync(), Times.Never);
    }

    [Fact]
    public async Task Handle_GivenSaveFailure_RethrowsExceptionAndRollsBack()
    {
        // Arrange
        var mockAuthUserRepo = new Mock<IAuthUserRepository>();
        var mockPermissionRepo = new Mock<IPermissionRepository>();
        var mockOutbox = new Mock<IOutboxRepository>();
        var mockPasswordHashService = new Mock<IPasswordHashService>();
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var mockLogger = new Mock<ILogger<RegisterUserHandler>>();
        var command = CreateCommand();
        var expected = new InvalidOperationException("Save failed");

        mockAuthUserRepo
            .Setup(r => r.EmailExistAsync(new Email(EmailAddress)))
            .ReturnsAsync(false);

        mockPasswordHashService
            .Setup(s => s.Hash(Password))
            .Returns(PasswordHash);

        mockUnitOfWork
            .Setup(u => u.SaveChangesAsync())
            .ThrowsAsync(expected);

        IRegisterUserHandler handler = new RegisterUserHandler(
            mockAuthUserRepo.Object,
            mockPermissionRepo.Object,
            mockOutbox.Object,
            mockPasswordHashService.Object,
            mockUnitOfWork.Object,
            mockLogger.Object);

        // Act & Assert
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => handler.HandleAsync(command));
        Assert.Same(expected, exception);

        mockAuthUserRepo.Verify(r => r.RegisterAsync(It.IsAny<AuthUser>()), Times.Once);
        mockOutbox.Verify(r => r.AddAsync(It.IsAny<OutboxMessage>()), Times.Once);
        mockUnitOfWork.Verify(u => u.SaveChangesAsync(), Times.Once);
        mockUnitOfWork.Verify(u => u.BeginTransaction(IsolationLevel.Serializable), Times.Once);
        mockUnitOfWork.Verify(u => u.Rollback(), Times.Once);
        mockUnitOfWork.Verify(u => u.Commit(), Times.Never);
    }
}
