using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using UserService.Api.Mappers;
using UserService.FacadeLib.Commands.Interfaces;
using UserService.FacadeLib.Queries.Interfaces;
using VidensVejen.ContractsLib.Requests.UserService;
using VidensVejen.ContractsLib.Responses.UserService;
using VidensVejen.SharedKernelLib.Exceptions;

namespace UserService.Api.Controllers;

[Route("/v1/users")]
[ApiController]
public class UsersController(
    IUpdateUserHandler updateUser,
    IUpdateEmailHandler updateEmail,
    IDeleteUserHandler delete,
    IUserQueries queries

    ) : ControllerBase
{
    [HttpGet]
    [EndpointSummary("Get all users")]
    [EndpointDescription("Gets the details of all instances of user")]
    [ProducesResponseType<IReadOnlyList<UserResponse>>(StatusCodes.Status200OK, "Application/json", Description = "Returns a list of all users")]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Description = "Error while trying to get all users")]
    public async Task<ActionResult<UserResponse>> GetAllUser()
    {
        try
        {
            var list = await queries.GetAllUsersAsync();

            var response = new List<UserResponse>();

            foreach (var item in list)
            {
                response.Add(item.AsResponse());
            }

            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


    [HttpGet("{id:guid}")]
    [EndpointSummary("Get a user")]
    [EndpointDescription("Gets the details of a single instance of a user")]
    [ProducesResponseType<UserResponse>(StatusCodes.Status200OK, "Application/json", Description = "Returns a single user")]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Description = "Error while trying to get the requested user")]
    [ProducesResponseType(StatusCodes.Status404NotFound, Description = "User was not found")]
    public async Task<ActionResult<UserResponse>> GetUser(
        [Required][Description("A unique identifier for a user")] Guid id)
    {
        try
        {
            var dto = await queries.GetUserByIdAsync(id);

            if (dto == null)
                return NotFound("User not found");

            return Ok(dto.AsResponse());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id:guid}")]
    [EndpointSummary("Update a user")]
    [EndpointDescription("Updates the details of a single instance of a user")]
    [ProducesResponseType<UserResponse>(StatusCodes.Status200OK, "Application/json", Description = "Returns the updated user")]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Description = "Error while trying to update the requested user")]
    [ProducesResponseType(StatusCodes.Status404NotFound, Description = "User was not found")]
    public async Task<ActionResult<UserResponse>> UpdateUser(
        [Required][Description("A unique identifier for a user")] Guid id,
        [Required][Description("Object used to update a user")] UpdateUserRequest request)
    {
        try
        {
            var dto = await updateUser.HandleAsync(request.AsUpdateCommand(id));

            return Ok(dto.AsResponse());
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id:guid}/email")]
    [EndpointSummary("Update a user email")]
    [EndpointDescription("Updates the email of a single instance of a user")]
    [ProducesResponseType(StatusCodes.Status200OK, Description = "Email was updated successfully")]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Description = "Error while trying to update email for the requested user")]
    [ProducesResponseType(StatusCodes.Status404NotFound, Description = "User was not found")]
    public async Task<ActionResult<UserResponse>> UpdateUserEmail(
        [Required][Description("A unique identifier for a user")] Guid id,
        [Required][Description("Object used to update a user email")] UpdateUserEmailRequest request)
    {
        try
        {
            await updateEmail.HandleAsync(request.AsUpdateEmailCommand(id));

            return Ok();
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


    [HttpDelete("{id:guid}")]
    [EndpointSummary("Deletes a user")]
    [EndpointDescription("Deletes a single instance of a user")]
    [ProducesResponseType(StatusCodes.Status204NoContent, Description = "User was deleted successfully")]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Description = "Error while trying to update the requested user")]
    [ProducesResponseType(StatusCodes.Status404NotFound, Description = "User was not found")]
    public async Task<ActionResult> DeleteUser(
        [Required][Description("A unique identifier for a user")] Guid id)
    {
        try
        {
            await delete.HandleAsync(id);

            return NoContent();
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
