using MediatR;

namespace TajMaster.Application.UseCases.Services.Commands.Update;

public record UpdateServiceCommand(
    int ServiceId,
    string Title,
    string Description,
    decimal BasePrice,
    int CraftsmanId,
    IList<int> Categories)
    : IRequest<bool>;