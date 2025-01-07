using TajMaster.Application.UseCases.Reviews.ReviewDtos;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.Reviews.ReviewExtensions;

public static class ReviewMappingExtensions
{
    public static ReviewDto ToReviewDto(this Review review)
    {
        return new ReviewDto(
            ReviewId: review.Id,
            OrderId: review.OrderId,
            UserId: review.UserId,
            CraftsmanId: review.CraftsmanId,
            Rating: review.Rating,
            Comment: review.Comment,
            CreatedDate: review.ReviewDate
        );
    }
    
    public static List<ReviewDto> ToReviewDtoList(this IEnumerable<Review> reviews)
    {
        return reviews.Select(review => review.ToReviewDto()).ToList();
    }
}