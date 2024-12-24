using FluentValidation;
using TajMaster.Application.UseCases.Craftsmen.Commands.Create;

namespace TajMaster.Application.UseCases.Craftsmen.Validations;

public class CreateCraftsmanCommandValidator : AbstractValidator<CreateCraftsmanCommand>
{
    public CreateCraftsmanCommandValidator()
    {
        RuleFor(x => x.UserId)
            .GreaterThan(0)
            .WithMessage("User ID must be a positive number.");

        RuleFor(x => x.Specialization)
            .IsInEnum()
            .WithMessage("Specialization must be a valid value.");

        RuleFor(x => x.Experience)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Experience cannot be negative.");

        RuleFor(x => x.Description)
            .MaximumLength(500)
            .WithMessage("Description cannot exceed 500 characters.");

        RuleFor(x => x.ProfilePicture)
            .MaximumLength(255)
            .When(x => !string.IsNullOrEmpty(x.ProfilePicture))
            .WithMessage("Profile picture URL cannot exceed 255 characters.");

        RuleFor(x => x.IsAvailable)
            .NotNull()
            .WithMessage("IsAvailable flag must be specified.");

        RuleFor(x => x.ProfileVerified)
            .NotNull()
            .WithMessage("ProfileVerified flag must be specified.");
    }
}