using TajMaster.Application.UseCases.DTOs;
using TajMaster.Application.UseCases.OrderItems;
using TajMaster.Application.UseCases.Orders.OrderDtos;
using TajMaster.Application.UseCases.Reviews.ReviewDtos;
using TajMaster.Application.UseCases.Users.UserDtos;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.Users.UserExtensions;

public static class UserMappingExtensions
{
    public static UserSummaryDto ToUsersListDto(this User user)
    {
        return new UserSummaryDto(
            user.Id,
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
            user.Roles.ToString() ?? "",
            user.RegisteredDate,
            user.IsActive,
            user.Orders?.Select(order => new OrderSummaryDto(
                order.Id,
                order.UserId,
                order.CraftsmanId,
                order.AppointmentDate,
                order.Address,
                order.Status.ToString(),
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
