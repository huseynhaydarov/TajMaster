using TajMaster.Application.UseCases.Craftsmen.CraftsmanDTos;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.Craftsmen.CraftsmenExtension;

public static class CraftsmenMappingExtensions
{
    public static CraftsmanDto MapToCraftsmanDto(this Craftsman craftsman)
    {
        return new CraftsmanDto(
            craftsman.Id,
            craftsman.Specialization.ToString(),
            craftsman.Experience,
            craftsman.Rating,
            craftsman.Description,
            craftsman.ProfilePicture,
            craftsman.IsAvialable,
            craftsman.ProfileVerified
        );
    }

    public static IEnumerable<CraftsmanDto> CraftsmanDtos(this IEnumerable<Craftsman> craftsmen)
    {
        return craftsmen.Select(user => user.MapToCraftsmanDto());
    }
}