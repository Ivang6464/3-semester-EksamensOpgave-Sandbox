using System.Text.Json;
using Dapr;
using Microsoft.AspNetCore.Mvc;
using VidensVejen.BuildingBlocksLib.Messaging.Inbox;
using VidensVejen.ContractsLib.Events;

namespace UserService.Api.Controllers;


[ApiController]
public class UserEventsController(
    IInboxRepository inbox
    ) : ControllerBase
{
    [Topic("pubsub", "user-registered")]
    [HttpPost("events/user-registered")]
    public async Task<ActionResult> RecieveAsync(UserRegisteredIntegrationEvent integrationEvent, CancellationToken cancellationToken)
    {

        var message = new InboxMessage
        {
            Id = integrationEvent.EventId,
            Type = integrationEvent.GetType().FullName!,
            Topic = "user-registered",
            Content = JsonSerializer.Serialize(integrationEvent),
            RecievedOnUtc = DateTime.UtcNow
        };

        await inbox.StoreIfMissingAsync(message, cancellationToken);

        return Ok();
    }
}
