using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.Auths.AuthDTOs;

public record AuthResponse(
    bool Success,
    string Token,
    string RefreshToken,
    string? FullName = null,
    string? Email = null,
    UserRole? Roles = null,
    IEnumerable<string>? Errors = null);