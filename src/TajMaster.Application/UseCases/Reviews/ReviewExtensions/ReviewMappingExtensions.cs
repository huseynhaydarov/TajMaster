using TajMaster.Application.UseCases.Reviews.ReviewDtos;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.Reviews.ReviewExtensions;

public static class ReviewMappingExtensions
{
    public static ReviewDto ToReviewDto(this Review review)
    {
        return new ReviewDto(
            review.Id,
            review.OrderId,
            review.UserId,
            review.CraftsmanId,
            review.Rating,
            review.Comment,
            review.ReviewDate
        );
    }

    public static List<ReviewDto> ToReviewDtoList(this IEnumerable<Review> reviews)
    {
        return reviews.Select(review => review.ToReviewDto()).ToList();
    }
}