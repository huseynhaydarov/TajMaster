using FluentValidation;
using TajMaster.Application.UseCases.Craftsmen.Commands.Update.UpdateCraftsman;

namespace TajMaster.Application.UseCases.Craftsmen.Validations;

public class UpdateCraftsmanProfileCommandValidator : AbstractValidator<UpdateCraftsmanCommand>
{
    public UpdateCraftsmanProfileCommandValidator()
    {
        RuleFor(x => x.CraftsmanId)
            .NotEqual(Guid.Empty).WithMessage("Craftsman ID cannot be an empty GUID.");

        RuleFor(x => x.Specialization)
            .NotEmpty().WithMessage("Specialization cannot be an empty string.");

        RuleFor(x => x.Experience)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Experience cannot be a negative value.");

        RuleFor(x => x.Description)
            .MaximumLength(500)
            .When(x => !string.IsNullOrEmpty(x.Description))
            .WithMessage("Description cannot exceed 500 characters.");

        RuleFor(x => x.ProfilePicture)
            .MaximumLength(255)
            .When(x => !string.IsNullOrEmpty(x.ProfilePicture))
            .WithMessage("Profile picture URL cannot exceed 255 characters.");

        RuleFor(x => x.ProfileVerified)
            .NotNull()
            .WithMessage("ProfileVerified must be specified.");
    }
}