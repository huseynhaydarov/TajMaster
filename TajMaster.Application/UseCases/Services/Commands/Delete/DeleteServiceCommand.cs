using MediatR;
using TajMaster.Application.Common.Interfaces.CQRS;

namespace TajMaster.Application.UseCases.Services.Commands.Delete;

public record DeleteServiceCommand(Guid ServiceId) : ICommand<Unit>;