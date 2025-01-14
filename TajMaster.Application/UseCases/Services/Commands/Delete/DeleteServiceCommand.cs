using MediatR;

namespace TajMaster.Application.UseCases.Services.Commands.Delete;

public record DeleteServiceCommand(Guid ServiceId) : IRequest<bool>;