using System.Text.Json;
using UserService.ApplicationLib.Repositories;
using UserService.DomainLib.Entities;
using VidensVejen.BuildingBlocksLib.Messaging.Outbox;
using VidensVejen.ContractsLib.Events;

namespace UserService.ApplicationLib.Messaging.Inbox.Strategies;

/// <summary>
/// 
/// </summary>
/// <param name="userRepo"></param>
public class CreateUserInboxStrategy(IUserRepository userRepo) : IInboxMessageStrategy
{
    string IInboxMessageStrategy.EventType => typeof(UserRegisteredIntegrationEvent).FullName!;

    async Task<OutboxMessage?> IInboxMessageStrategy.ApplyAsync(Guid eventId, string content, CancellationToken cancellationToken)
    {
        var integrationEvent = JsonSerializer.Deserialize<UserRegisteredIntegrationEvent>(content)
                 ?? throw new InvalidOperationException($"Inbox event {eventId} is missing a event");

        var userId = new UserId(integrationEvent.UserId);

        var user = User.Create(userId, integrationEvent.Firstname, integrationEvent.Surname, integrationEvent.Email);

        await userRepo.AddAsync(user);

        var userCreatedIntegrationEvent = new UserActivateIntegrationEvent(
                eventId,
                "User-Activate",
                user.Id.Value
                );

        var outboxMessage = new OutboxMessage
        {
            Id = userCreatedIntegrationEvent.EventId,
            Type = userCreatedIntegrationEvent.GetType().FullName!,
            Topic = integrationEvent.EventTopic,
            Content = JsonSerializer.Serialize(userCreatedIntegrationEvent),
            CreatedAtUtc = DateTime.UtcNow
        };

        return outboxMessage;
    }
}
