using System.Text.Json;
using AuthService.ApplicationLib.Repositories;
using AuthService.DomainLib.Entities;
using VidensVejen.BuildingBlocksLib.Messaging.Inbox;
using VidensVejen.BuildingBlocksLib.Messaging.Outbox;
using VidensVejen.ContractsLib.Events;
using VidensVejen.SharedKernelLib.Exceptions;

namespace AuthService.ApplicationLib.Messaging.Inbox.Strategies;

/// <summary>
/// 
/// </summary>
/// <param name="authUserRepo"></param>
public class ActivateUserInboxStrategy(IAuthUserRepository authUserRepo) : IInboxMessageStrategy
{
    string IInboxMessageStrategy.EventType => typeof(UserActivateIntegrationEvent).FullName!;

    async Task<OutboxMessage?> IInboxMessageStrategy.ApplyAsync(Guid eventId, string content, CancellationToken cancellationToken)
    {
        var integrationEvent = JsonSerializer.Deserialize<UserActivateIntegrationEvent>(content)
                ?? throw new InvalidOperationException($"Inbox event {eventId} is missing a event");

        var authUserId = new AuthUserId(integrationEvent.UserId);

        var user = await authUserRepo.GetAuthUserByIdAsync(authUserId)
            ?? throw new NotFoundException("Could not process, User was not found");

        user.SetStatusActive();

        return null;
    }
}
