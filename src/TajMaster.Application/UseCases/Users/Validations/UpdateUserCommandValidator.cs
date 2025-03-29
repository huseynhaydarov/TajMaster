using FluentValidation;
using TajMaster.Application.UseCases.Users.Commands.Update;

namespace TajMaster.Application.UseCases.Users.Validations;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(x => x.FullName)
            .NotEmpty()
            .WithMessage("Full name is required.")
            .MaximumLength(100).WithMessage("Full name must not exceed 100 characters.");

        RuleFor(x => x.Email)
            .EmailAddress().WithMessage("Invalid email format.")
            .When(x => !string.IsNullOrEmpty(x.Email));

        RuleFor(x => x.Address)
            .MaximumLength(300).WithMessage("Address must not exceed 300 characters.")
            .When(x => !string.IsNullOrEmpty(x.Address)); 

        RuleFor(x => x.Phone)
            .NotEmpty().WithMessage("Phone number is required.")
            .Matches(@"^\+?\d{10,14}$").WithMessage("Invalid phone number format.");
    }
}