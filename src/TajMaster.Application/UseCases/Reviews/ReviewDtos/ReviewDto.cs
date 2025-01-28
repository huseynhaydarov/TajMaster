namespace TajMaster.Application.UseCases.Reviews.ReviewDtos;

public record ReviewDto(
    Guid ReviewId,
    Guid OrderId,
    Guid UserId,
    Guid CraftsmanId,
    int Rating,
    string? Comment,
    DateTime CreatedDate);