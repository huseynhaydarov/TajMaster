using TajMaster.Application.UseCases.DTOs;
using TajMaster.Application.UseCases.Orders.OrderDtos;
using TajMaster.Domain.Enums;

namespace TajMaster.Application.UseCases.Users.UserDtos;

public record GetUsersDto(
    int UserId,
    string FullName,
    string? Email,
    string? PhoneNumber,
    string? Address,
    string Role,
    DateTime RegisterDate,
    bool IsActive,
    List<OrderDto>? Orders,
    List<ReviewDto>? Reviews);