using FluentValidation;
using TajMaster.Application.UseCases.OrderStatuses.Commands.Create;

namespace TajMaster.Application.UseCases.OrderStatuses.OrderStatusDtos;

public class CreateOrderStatusCommandValidator : AbstractValidator<CreateOrderStatusCommand>
{
    public CreateOrderStatusCommandValidator()
    {
        RuleFor(command => command.Code)
            .NotEmpty().WithMessage("Code must be a valid slug, containing lowercase letters, digits, and hyphens.");

        RuleFor(command => command.Name)
            .NotEmpty().WithMessage("Name is required.");
    }
}