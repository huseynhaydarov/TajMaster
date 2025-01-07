using TajMaster.Application.UseCases.Orders.OrderDtos;
using TajMaster.Application.UseCases.Reviews.ReviewDtos;

namespace TajMaster.Application.UseCases.Users.UserDtos;

public record UserDetailDto(
    int UserId,
    string FullName,
    string? Email,
    string? PhoneNumber,
    string? Address,
    string Role,
    DateTime RegisterDate,
    bool IsActive,
    List<OrderSummaryDto>? Orders,
    List<ReviewDto>? Reviews);