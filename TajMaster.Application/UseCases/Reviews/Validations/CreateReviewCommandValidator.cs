using FluentValidation;
using TajMaster.Application.UseCases.Reviews.Commands.Create;

namespace TajMaster.Application.UseCases.Reviews.Validations;

public class CreateReviewCommandValidator : AbstractValidator<CreateReviewCommand>
{
    public CreateReviewCommandValidator()
    {
        RuleFor(x => x.OrderId)
            .GreaterThan(0).WithMessage("Order ID must be greater than 0.");

        RuleFor(x => x.UserId)
            .GreaterThan(0).WithMessage("User ID must be greater than 0.");

        RuleFor(x => x.CraftsmanId)
            .GreaterThan(0).WithMessage("Craftsman ID must be greater than 0.");

        RuleFor(x => x.Rating)
            .InclusiveBetween(1, 5).WithMessage("Rating must be between 1 and 5.");

        RuleFor(x => x.Comment)
            .NotEmpty().WithMessage("Comment cannot be empty.")
            .MaximumLength(500).WithMessage("Comment cannot exceed 500 characters.");

        RuleFor(x => x.ReviewDate)
            .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Review date cannot be in the future.");
    }
}