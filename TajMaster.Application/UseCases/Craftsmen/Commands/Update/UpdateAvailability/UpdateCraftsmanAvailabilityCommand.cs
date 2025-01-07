using MediatR;
using TajMaster.Application.Common.Interfaces.CQRS;

namespace TajMaster.Application.UseCases.Craftsmen.Commands.Update.UpdateAvailability;

public record UpdateCraftsmanAvailabilityCommand(int CraftsmanId, bool IsAvailable) : ICommand<Unit>, IRequest<bool>;