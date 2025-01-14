using FluentValidation;
using TajMaster.Application.UseCases.Reviews.Commands.Update;

namespace TajMaster.Application.UseCases.Reviews.Validations;

public class UpdateReviewCommandValidator : AbstractValidator<UpdateReviewCommand>
{
    public UpdateReviewCommandValidator()
    {
        RuleFor(x => x.ReviewId)
            .NotEqual(Guid.Empty).WithMessage("Review ID cannot be empty");

        RuleFor(x => x.Rating)
            .InclusiveBetween(1, 5).WithMessage("Rating must be between 1 and 5.");

        RuleFor(x => x.Comment)
            .NotEmpty().WithMessage("Comment cannot be empty.")
            .MaximumLength(500).WithMessage("Comment cannot exceed 500 characters.");
    }
}