using MediatR;

namespace TajMaster.Application.UseCases.Craftsmen.Commands.Update.UpdateAvailability;

public record UpdateCraftsmanAvailabilityCommand(Guid CraftsmanId, bool IsAvailable) : IRequest<bool>;