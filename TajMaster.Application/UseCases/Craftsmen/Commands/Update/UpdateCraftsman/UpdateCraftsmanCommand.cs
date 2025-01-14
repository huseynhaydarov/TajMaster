using MediatR;

namespace TajMaster.Application.UseCases.Craftsmen.Commands.Update.UpdateCraftsman;

public record UpdateCraftsmanCommand(
    Guid CraftsmanId,
    Guid? UserId,
    int? Specialization,
    int? Experience,
    string? Description,
    string? ProfilePicture,
    bool? IsAvailable,
    bool? ProfileVerified) : IRequest<bool>;