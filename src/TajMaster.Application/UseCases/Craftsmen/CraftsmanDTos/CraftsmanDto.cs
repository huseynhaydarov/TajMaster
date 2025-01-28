namespace TajMaster.Application.UseCases.Craftsmen.CraftsmanDTos;

public record CraftsmanDto(
    Guid CraftsmanId,
    string Specialization,
    int Experience,
    int Rating,
    string? Description,
    string? ProfilePicture,
    bool Avialable,
    bool ProfileVerified
);