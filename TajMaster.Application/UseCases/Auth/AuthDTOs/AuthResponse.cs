using TajMaster.Domain.Enumerations;

namespace TajMaster.Application.UseCases.Auth.AuthDTOs;

public record AuthResponse(
    bool Success,
    string Token,
    string RefreshToken,
    string? FullName = null,
    string? Email = null,
    Role? Roles = null,
    IEnumerable<string>? Errors = null);