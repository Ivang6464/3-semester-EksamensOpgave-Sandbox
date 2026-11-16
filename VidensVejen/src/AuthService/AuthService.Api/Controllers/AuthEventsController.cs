using System.Text.Json;
using Dapr;
using Microsoft.AspNetCore.Mvc;
using VidensVejen.BuildingBlocksLib.Messaging.Inbox;
using VidensVejen.ContractsLib.Events;

namespace AuthService.Api.Controllers;


[ApiController]
public class AuthEventsController(
    IInboxRepository inbox
    ) : ControllerBase
{
    [Topic("pubsub", "user-activate")]
    [HttpPost("events/user-activate")]
    public async Task<ActionResult> RecieveAsync(UserActivateIntegrationEvent integrationEvent, CancellationToken cancellationToken)
    {

        var message = new InboxMessage
        {
            Id = integrationEvent.EventId,
            Type = integrationEvent.GetType().FullName!,
            Topic = "user-activate",
            Content = JsonSerializer.Serialize(integrationEvent),
            RecievedOnUtc = DateTime.UtcNow
        };

        await inbox.StoreIfMissingAsync(message, cancellationToken);

        return Ok();
    }
}
