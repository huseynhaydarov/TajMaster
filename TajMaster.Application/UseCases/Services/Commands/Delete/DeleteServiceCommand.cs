using MediatR;

namespace TajMaster.Application.UseCases.Services.Commands.Delete;

public record DeleteServiceCommand(int ServiceId) : IRequest<bool>;