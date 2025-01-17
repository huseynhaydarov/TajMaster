using FluentValidation;
using TajMaster.Application.UseCases.CartStatuses.Command.Create;

namespace TajMaster.Application.UseCases.CartStatuses.Validators
{
    public class CreateCartStatusCommandValidator : AbstractValidator<CreateCartStatusCommand>
    {
        public CreateCartStatusCommandValidator()
        {
            RuleFor(command => command.Code)
                .NotEmpty().WithMessage("Code must be a valid slug, containing lowercase letters, digits, and hyphens.");
            
            RuleFor(command => command.Name)
                .NotEmpty().WithMessage("Name is required.");
        }
    }
}