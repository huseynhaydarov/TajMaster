using MediatR;

namespace TajMaster.Application.UseCases.Services.Commands.Update;

public record UpdateServiceCommand(
    Guid ServiceId,
    string Title,
    string Description,
    decimal BasePrice,
    int CraftsmanId,
    IList<Guid> Categories)
    : IRequest<bool>;