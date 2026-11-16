using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
    [EndpointSummary("Create a user")]
    [EndpointDescription("Creates a new instance of a user")]
    [ProducesResponseType(StatusCodes.Status200OK, Description = "User created successfully")]
    public async Task<ActionResult> CreateUserAsync(
        [Required][Description("Object used to create a user")] UserRegisteredIntegrationEvent integrationEvent,
        CancellationToken cancellationToken
        )
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
