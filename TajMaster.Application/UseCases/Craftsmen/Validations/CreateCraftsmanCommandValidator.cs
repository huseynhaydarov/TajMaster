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

        RuleFor(x => x.About)
            .MaximumLength(500)
            .WithMessage("Description cannot exceed 500 characters.");

        RuleFor(x => x.ProfilePicture)
            .Must(file => file == null || file.Length <= 5 * 1024 * 1024)  // File size validation only if file exists
            .WithMessage("Profile picture size must not exceed 5 MB.")
            .Must(file => file == null || new[] { ".jpg", ".jpeg", ".png" }.Contains(Path.GetExtension(file?.FileName)?.ToLower()))
            .WithMessage("Only .jpg, .jpeg, or .png files are allowed.");
    }
}