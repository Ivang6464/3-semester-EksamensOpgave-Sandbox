using System.Data;
using System.Text.Json;
using AuthService.ApplicationLib.Repositories;
using AuthService.DomainLib.Entities;
using VidensVejen.BuildingBlocksLib.Messaging.Inbox;
using VidensVejen.BuildingBlocksLib.UnitOfWork;
using VidensVejen.ContractsLib.Events;
using VidensVejen.SharedKernelLib.Exceptions;

namespace AuthService.ApplicationLib.Messaging.Inbox;

/// <summary>
/// 
/// </summary>
/// <param name="inbox"></param>
/// <param name="authUserRepo"></param>
/// <param name="unitOfWork"></param>
public class ProcessInboxMessageHandler(
    IInboxRepository inbox,
    IAuthUserRepository authUserRepo,
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
    /// <exception cref="NotFoundException"></exception>
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

            var integrationEvent = JsonSerializer.Deserialize<UserActivateIntegrationEvent>(message.Content)
                ?? throw new InvalidOperationException($"Inbox event {eventId} is missing a event");

            var authUserId = new AuthUserId(integrationEvent.UserId);

            var user = await authUserRepo.GetAuthUserByIdAsync(authUserId)
                ?? throw new NotFoundException("Could not process, User was not found");

            user.SetStatusActive();

            message.SetProccesedAtUtc();

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
