namespace TajMaster.Application.UseCases.Users.UserDtos;

public record UserDto(
    int UserId,
    string FullName,
    string? Email,
    string? PhoneNumber,
    string? Address,
    DateTime RegisterDate,
    bool IsActive);