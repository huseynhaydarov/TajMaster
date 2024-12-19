using FluentValidation;
using TajMaster.Application.UseCases.Users.Commands.Create;

namespace TajMaster.Application.UseCases.Users.Validations;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage("Full name is required.")
            .MaximumLength(100).WithMessage("Full name must not exceed 100 characters.");

        RuleFor(x => x.Email)
            .EmailAddress().WithMessage("Invalid email format.")
            .When(x => !string.IsNullOrEmpty(x.Email)); // Email is optional but must be valid if provided.

        RuleFor(x => x.HashedPassword)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");

        RuleFor(x => x.Phone)
            .NotEmpty().WithMessage("Phone number is required.")
            .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Invalid phone number format.");

        RuleFor(x => x.Roles)
            .IsInEnum().WithMessage("Invalid role specified.");

        RuleFor(x => x.RegisterDate)
            .NotEmpty().WithMessage("Register date is required.")
            .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Register date cannot be in the future.");

        RuleFor(x => x.ProfilePicture)
            .Must(BeAValidUrl).WithMessage("Invalid URL format for profile picture.")
            .When(x => !string.IsNullOrEmpty(x.ProfilePicture)); // Optional, but must be valid if provided.

        RuleFor(x => x.IsVerified)
            .NotNull().WithMessage("Verification status must be specified.");

        RuleFor(x => x.IsActive)
            .NotNull().WithMessage("Active status must be specified.");
    }

    // Custom URL validation
    private bool BeAValidUrl(string? url)
    {
        return Uri.TryCreate(url, UriKind.Absolute, out var uriResult) &&
               (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
    }
}