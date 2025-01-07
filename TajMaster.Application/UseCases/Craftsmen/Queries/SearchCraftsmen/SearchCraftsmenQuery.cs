using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.UseCases.Craftsmen.CraftsmanDTos;

namespace TajMaster.Application.UseCases.Craftsmen.Queries.SearchCraftsmen;

public record SearchCraftsmenQuery(
    string? Specialization,
    bool? Availability,
    bool? ProfileVerified, // Filter by profile verification
    int? MinExperience, // Minimum experience filter
    int? MinRating // Minimum rating filter
) : IQuery<List<CraftsmanDto>>;