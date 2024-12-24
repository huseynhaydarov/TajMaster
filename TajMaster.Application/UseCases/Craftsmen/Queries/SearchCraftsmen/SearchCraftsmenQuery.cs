using TajMaster.Application.UseCases.DTO;
using TajMaster.Application.Common.Interfaces.CQRS;

namespace TajMaster.Application.UseCases.Craftsmen.Queries.SearchCraftsmen;

public record SearchCraftsmenQuery(
    string? Specialization, 
    bool? Availability,
    bool? ProfileVerified,   // Filter by profile verification
    int? MinExperience,      // Minimum experience filter
    int? MinRating           // Minimum rating filter
) : IQuery<List<CraftsmanDto>>;