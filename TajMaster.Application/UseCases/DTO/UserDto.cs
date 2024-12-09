using TajMaster.Domain.Enums;

namespace TajMaster.Application.UseCases.DTO;

public record UserDto(
    int UserId,
    string FullName,
    string? Email,
    string? PhoneNumber,
    string? Address,
    Role Role,
    DateTime RegisterDate,
    bool IsActive);