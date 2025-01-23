using MediatR;

namespace TajMaster.Application.UseCases.Craftsmen.Commands.Update.UpdateCraftsman;

public record UpdateCraftsmanCommand(
    Guid CraftsmanId,
    string? Specialization,
    int? Experience,
    string? Description,
    string? ProfilePicture,
    bool? ProfileVerified) : IRequest<bool>;