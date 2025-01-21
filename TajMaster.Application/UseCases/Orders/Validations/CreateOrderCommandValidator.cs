using FluentValidation;
using TajMaster.Application.UseCases.Orders.Create;

namespace TajMaster.Application.UseCases.Orders.Validations;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(command => command.UserId)
            .NotEqual(Guid.Empty)
            .WithMessage("User ID must be a valid GUID and cannot be empty.");

        RuleFor(command => command.AppointmentDate)
            .Must(BeInTheFuture)
            .WithMessage("AppointmentDate must be in the future.");

        RuleFor(command => command.Address)
            .NotEmpty()
            .WithMessage("Address is required.");
    }

    private bool BeInTheFuture(DateTime date)
    {
        return date > DateTime.Now;
    }
}