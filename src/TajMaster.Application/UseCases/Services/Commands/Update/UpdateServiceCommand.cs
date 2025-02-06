using MediatR;
using TajMaster.Application.Common.Interfaces.CQRS;

namespace TajMaster.Application.UseCases.Services.Commands.Update;

public record UpdateServiceCommand(
    Guid ServiceId,
    string? Title,
    string? Description,
    decimal? BasePrice,
    int? CraftsmanId,
    IList<Guid>? Categories)
    : ICommand<Unit>;