using FluentValidation;
using TajMaster.Application.UseCases.Services.Commands.Create;

namespace TajMaster.Application.UseCases.Services.Validations;

public class CreateServiceCommandValidator : AbstractValidator<CreateServiceCommand>
{
    public CreateServiceCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(150).WithMessage("Title cannot exceed 150 characters.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");

        RuleFor(x => x.BasePrice)
            .GreaterThan(0).WithMessage("Base price must be greater than 0.");

        RuleFor(x => x.CraftsmanId)
            .NotEqual(Guid.Empty).WithMessage("CraftsmanId is required.");

        RuleFor(x => x.Categories)
            .NotEmpty().WithMessage("At least one category is required.");
    }
}