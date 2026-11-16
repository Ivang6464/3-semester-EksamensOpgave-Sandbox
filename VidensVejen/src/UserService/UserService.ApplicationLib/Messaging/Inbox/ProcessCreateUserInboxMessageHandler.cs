using System.Data;
using System.Text.Json;
using UserService.ApplicationLib.Repositories;
using UserService.DomainLib.Entities;
using VidensVejen.BuildingBlocksLib.Messaging.Inbox;
using VidensVejen.BuildingBlocksLib.Messaging.Outbox;
using VidensVejen.BuildingBlocksLib.UnitOfWork;
using VidensVejen.ContractsLib.Events;

namespace UserService.ApplicationLib.Messaging.Inbox;

/// <summary>
/// 
/// </summary>
/// <param name="inbox"></param>
/// <param name="userRepo"></param>
/// <param name="outbox"></param>
/// <param name="unitOfWork"></param>
public class ProcessCreateUserInboxMessageHandler(
    IInboxRepository inbox,
    IUserRepository userRepo,
    IOutboxRepository outbox,
    IUnitOfWork unitOfWork
    )
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="eventId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public async Task HandleAsync(
        Guid eventId,
        CancellationToken cancellationToken
        )
    {
        unitOfWork.BeginTransaction(IsolationLevel.Serializable);

        try
        {
            var message = await inbox.FindAsync(eventId, cancellationToken);

            if (message == null || message.ProccessedOnUtc.HasValue)
            {
                unitOfWork.Commit();
                return;
            }

            var integrationEvent = JsonSerializer.Deserialize<UserRegisteredIntegrationEvent>(message.Content)
                ?? throw new InvalidOperationException($"Inbox event {eventId} is missing a event");

            var userId = new UserId(integrationEvent.UserId);

            var user = User.Create(userId, integrationEvent.Firstname, integrationEvent.Surname, integrationEvent.Email);

            await userRepo.AddAsync(user);

            message.SetProccesedAtUtc();

            var userCreatedIntegrationEvent = new UserActivateIntegrationEvent(
                message.Id,
                user.Id.Value
                );

            var outboxMessage = new OutboxMessage
            {
                Id = userCreatedIntegrationEvent.EventId,
                Type = userCreatedIntegrationEvent.GetType().FullName!,
                Topic = "user-activate",
                Content = JsonSerializer.Serialize(userCreatedIntegrationEvent),
                CreatedAtUtc = DateTime.UtcNow
            };

            await outbox.AddAsync(outboxMessage);

            await unitOfWork.SaveChangesAsync();
            unitOfWork.Commit();

        }
        catch (Exception)
        {
            unitOfWork.Rollback();
            throw;
        }
    }
}
