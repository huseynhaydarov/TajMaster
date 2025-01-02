using TajMaster.Application.UseCases.DTOs;
using TajMaster.Application.UseCases.OrderItems;
using TajMaster.Application.UseCases.Orders.OrderDtos;
using TajMaster.Application.UseCases.Users.UserDtos;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.Users.UserExtensions;

public static class UserMappingExtensions
{
    public static UserDto MapToUserDto(this User user)
    {
        return new UserDto(
            user.Id,
            user.FullName,
            user.Email,
            user.Phone,
            user.Address,
            user.RegisteredDate,
            user.IsActive
        );
    }
    
    public static IEnumerable<GetUsersDto> ToUsersDtoList(this IEnumerable<User> users)
    {
        return users.Select(user => user.ToUsersDto());
    }

    public static GetUsersDto ToUsersDto(this User user)
    {
        return DtoFromUsers(user);
    }
    private static GetUsersDto DtoFromUsers(this User user)
    {
        return new GetUsersDto(
            user.Id,
            user.FullName,
            user.Email,
            user.Phone,
            user.Address,
            user.Roles.ToString() ?? "",
            user.RegisteredDate,
            user.IsActive,
            user.Orders?.Select(order => new OrderDto(
                order.Id,
                order.UserId,
                order.CraftsmanId,
                order.AppointmentDate,
                order.Address,
                order.Status.ToString(),
                order.TotalPrice,
                order.OrderItems?.Select(item => new OrderItemDto(
                    item.OrderId,
                    item.ServiceId,
                    item.Quantity,
                    item.Price
                )).ToList() ?? [] 
            )).ToList() ?? [],
            user.Reviews?.Select(review => new ReviewDto(
                review.Id,
                review.OrderId,
                review.UserId,
                review.CraftsmanId,
                review.Rating,
                review.Comment,
                review.ReviewDate
            )).ToList() ?? []
        );
    }
    
}
