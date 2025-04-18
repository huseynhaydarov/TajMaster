using TajMaster.Application.UseCases.Orders.OrderDtos;
using TajMaster.Application.UseCases.Reviews.ReviewDtos;
using TajMaster.Application.UseCases.Users.UserDtos;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.Users.UserExtensions;

public static class UserMappingExtensions
{
    public static IEnumerable<UserSummaryDto> ToUserDtoList(this IEnumerable<User> users)
    {
        return users.Select(order => order.ToUserSummaryDto());
    }

    private static UserSummaryDto ToUserSummaryDto(this User user)
    {
        return new UserSummaryDto(
            user.FullName,
            user.Email,
            user.Phone,
            user.Address,
            user.RegisteredDate,
            user.IsActive
        );
    }

    public static UserDetailDto MapToUser(this User user)
    {
        return DtoFromUsers(user);
    }

    private static UserDetailDto DtoFromUsers(this User user)
    {
        return new UserDetailDto(
            user.Id,
            user.FullName,
            user.Email,
            user.Phone,
            user.Address,
            user.UserRole.Name,
            user.RegisteredDate,
            user.IsActive,
            user.Orders?.Select(order => new OrderSummaryDto(
                order.Id,
                order.UserId,
                order.CraftsmanId,
                order.AppointmentDate,
                order.Address,
                order.OrderStatus.Name,
                order.TotalPrice
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