using MediatR;

namespace TajMaster.Application.UseCases.Craftsmen.Commands.Update.UpdateCraftsman;

public record UpdateCraftsmanCommand(
    int CraftsmanId,
    int? UserId,
    int? Specialization,
    int? Experience,
    string? Description,
    string? ProfilePicture,
    bool? IsAvailable,
    bool? ProfileVerified) : IRequest<bool>;
