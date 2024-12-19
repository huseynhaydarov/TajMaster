namespace TajMaster.Application.UseCases.DTO;

public record CartDto(
    int CartId,
    int UserId,
    string CartStatus,
    decimal SubTotal,
    List<CartItemDto> CartItems);