namespace TajMaster.Application.UseCases.Users.UserDtos;

public record UserSummaryDto(
    Guid UserId,
    string FullName,
    string? Email,
    string? PhoneNumber,
    string? Address,
    DateTime RegisterDate,
    bool IsActive);