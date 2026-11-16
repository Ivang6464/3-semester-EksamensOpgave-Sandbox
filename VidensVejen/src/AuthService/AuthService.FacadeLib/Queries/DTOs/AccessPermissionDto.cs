namespace AuthService.FacadeLib.Queries.DTOs;

/// <summary>
/// 
/// </summary>
/// <param name="Id"></param>
/// <param name="Name"></param>
public record AccessPermissionDto(
    Guid Id,
    string Name
    );
