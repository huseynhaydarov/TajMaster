namespace TajMaster.Application.UseCases.DTO;

public record CraftsmanDto(
    int CraftsmanId,
    string Specialization,
    int Experience,
    int Rating,
    string? Description,
    string? ProfilePicture,
    bool Avialable,
    bool ProfileVerified,
    List<OrderDto> Orders,
    List<ServiceDto> Services,
    List<ReviewDto> ReviewsCraftsman);