using FluentValidation;
using TajMaster.Application.UseCases.OrderItems;

namespace TajMaster.Application.UseCases.Orders.Validations
{
    public class OrderItemDtoValidator : AbstractValidator<OrderItemDto>
    {
        public OrderItemDtoValidator()
        {
            RuleFor(item => item.ServiceId)
                .GreaterThan(0)
                .WithMessage("ServiceId must be a positive integer.");

            RuleFor(item => item.Quantity)
                .GreaterThan(0)
                .WithMessage("Quantity must be greater than zero.");

            RuleFor(item => item.Price)
                .GreaterThan(0)
                .WithMessage("Price must be greater than zero.");
        }
    }
}