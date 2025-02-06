using FluentValidation;
using TajMaster.Application.UseCases.OrderItems;

namespace TajMaster.Application.UseCases.Orders.Validations;

public class OrderItemDtoValidator : AbstractValidator<OrderItemDto>
{
    public OrderItemDtoValidator()
    {
        RuleFor(command => command.ServiceId)
            .NotEqual(Guid.Empty)
            .WithMessage("Service ID must be a valid GUID and cannot be empty.");

        RuleFor(item => item.Quantity)
            .GreaterThan(0)
            .WithMessage("Quantity must be greater than zero.");

        RuleFor(item => item.Price)
            .GreaterThan(0)
            .WithMessage("Price must be greater than zero.");
    }
}