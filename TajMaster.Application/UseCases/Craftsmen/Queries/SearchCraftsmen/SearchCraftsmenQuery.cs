using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.UseCases.Craftsmen.CraftsmanDTos;

namespace TajMaster.Application.UseCases.Craftsmen.Queries.SearchCraftsmen;

public record SearchCraftsmenQuery(
    string? Specialization,
    bool? Availability,
    bool? ProfileVerified, 
    int? MinExperience, 
    int? MinRating) : IQuery<IEnumerable<CraftsmanDto>>;