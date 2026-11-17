using System.Text.Json;
using UserService.ApplicationLib.Repositories;
using UserService.DomainLib.Entities;
using VidensVejen.BuildingBlocksLib.Messaging.Outbox;
using VidensVejen.ContractsLib.Events;
using VidensVejen.SharedKernelLib.Exceptions;

namespace UserService.ApplicationLib.Messaging.Inbox.Strategies;

/// <summary>
/// 
/// </summary>
/// <param name="userRepo"></param>
public class DeleteUserInboxStrategy(IUserRepository userRepo) : IInboxMessageStrategy
{
    string IInboxMessageStrategy.EventType => typeof(UserDeletionIntegrationEvent).FullName!;

    async Task<OutboxMessage?> IInboxMessageStrategy.ApplyAsync(Guid eventId, string content, CancellationToken cancellationToken)
    {
        var integrationEvent = JsonSerializer.Deserialize<UserDeletionIntegrationEvent>(content)
                ?? throw new InvalidOperationException($"Inbox event {eventId} is missing a event");

        var userId = new UserId(integrationEvent.UserId);

        var user = await userRepo.GetUserByIdAsync(userId)
            ?? throw new NotFoundException("User was not found");

        userRepo.Delete(user);

        return null;
    }
}
