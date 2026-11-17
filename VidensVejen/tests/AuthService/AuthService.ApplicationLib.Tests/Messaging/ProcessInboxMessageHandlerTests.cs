//using System.Data;
//using System.Text.Json;
//using AuthService.ApplicationLib.Messaging.Inbox.Handlers;
//using AuthService.ApplicationLib.Repositories;
//using AuthService.DomainLib.Entities;
//using AuthService.DomainLib.Enums;
//using Moq;
//using VidensVejen.BuildingBlocksLib.Messaging.Inbox;
//using VidensVejen.BuildingBlocksLib.UnitOfWork;
//using VidensVejen.ContractsLib.Events;
//using VidensVejen.SharedKernelLib.Exceptions;

//namespace AuthService.ApplicationLib.Tests.Messaging;

//public class ProcessInboxMessageHandlerTests
//{
//    private static InboxMessage CreateMessage(Guid userId)
//    {
//        var integrationEvent = new UserActivateIntegrationEvent(Guid.NewGuid(), "user-activate", userId);
//        return new InboxMessage
//        {
//            Id = integrationEvent.EventId,
//            Type = typeof(UserActivateIntegrationEvent).FullName!,
//            Topic = "user-activate",
//            Content = JsonSerializer.Serialize(integrationEvent),
//            RecievedOnUtc = DateTime.UtcNow
//        };
//    }

//    [Fact]
//    public async Task Handle_GivenPendingActivation_ActivatesUserAndCommits()
//    {
//        // Arrange
//        var token = TestContext.Current.CancellationToken;
//        var user = AuthUser.Create("sue@example.com", "password-hash", []);
//        var userId = user.Id;
//        var message = CreateMessage(userId.Value);
//        var inbox = new Mock<IInboxRepository>();
//        var userRepo = new Mock<IAuthUserRepository>();
//        var unitOfWork = new Mock<IUnitOfWork>();
//        inbox.Setup(repository => repository.FindAsync(message.Id, token)).ReturnsAsync(message);
//        userRepo.Setup(repository => repository.GetAuthUserByIdAsync(userId))
//            .ReturnsAsync(user);
//        var handler = new ProcessInboxMessageHandler(inbox.Object, userRepo.Object, unitOfWork.Object);

//        // Act
//        await handler.HandleAsync(message.Id, token);

//        // Assert
//        Assert.Equal(AuthUserStatus.Active, user.Status);
//        Assert.NotNull(message.ProccessedOnUtc);
//        userRepo.Verify(repository => repository.GetAuthUserByIdAsync(userId), Times.Once);
//        unitOfWork.Verify(work => work.BeginTransaction(IsolationLevel.Serializable), Times.Once);
//        unitOfWork.Verify(work => work.SaveChangesAsync(), Times.Once);
//        unitOfWork.Verify(work => work.Commit(), Times.Once);
//        unitOfWork.Verify(work => work.Rollback(), Times.Never);
//    }

//    [Fact]
//    public async Task Handle_GivenUnknownUser_RollsBackAndThrows()
//    {
//        // Arrange
//        var token = TestContext.Current.CancellationToken;
//        var userId = new AuthUserId(Guid.NewGuid());
//        var message = CreateMessage(userId.Value);
//        var inbox = new Mock<IInboxRepository>();
//        var userRepo = new Mock<IAuthUserRepository>();
//        var unitOfWork = new Mock<IUnitOfWork>();
//        inbox.Setup(repository => repository.FindAsync(message.Id, token)).ReturnsAsync(message);
//        userRepo.Setup(repository => repository.GetAuthUserByIdAsync(userId))
//            .ReturnsAsync((AuthUser?)null);
//        var handler = new ProcessInboxMessageHandler(inbox.Object, userRepo.Object, unitOfWork.Object);

//        // Act & Assert
//        await Assert.ThrowsAsync<NotFoundException>(() => handler.HandleAsync(message.Id, token));

//        Assert.Null(message.ProccessedOnUtc);
//        userRepo.Verify(repository => repository.GetAuthUserByIdAsync(userId), Times.Once);
//        unitOfWork.Verify(work => work.BeginTransaction(IsolationLevel.Serializable), Times.Once);
//        unitOfWork.Verify(work => work.SaveChangesAsync(), Times.Never);
//        unitOfWork.Verify(work => work.Commit(), Times.Never);
//        unitOfWork.Verify(work => work.Rollback(), Times.Once);
//    }
//}
