namespace TajMaster.Application.UseCases.Craftsmen.CraftsmanDTos;

public record CraftsmanDto(
    int CraftsmanId,
    string Specialization,
    int Experience,
    int Rating,
    string? Description,
    string? ProfilePicture,
    bool Avialable,
    bool ProfileVerified
    );