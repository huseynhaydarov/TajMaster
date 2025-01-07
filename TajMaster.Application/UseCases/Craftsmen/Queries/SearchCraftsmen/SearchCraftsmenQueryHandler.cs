using MediatR;
using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.UseCases.Craftsmen.CraftsmanDTos;
using TajMaster.Application.UseCases.Craftsmen.CraftsmenExtension;

namespace TajMaster.Application.UseCases.Craftsmen.Queries.SearchCraftsmen;

public class SearchCraftsmenQueryHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<SearchCraftsmenQuery, List<CraftsmanDto>>
{
    public async Task<List<CraftsmanDto>> Handle(SearchCraftsmenQuery request, CancellationToken cancellationToken)
    {
        var query = unitOfWork.CraftsmanRepository.GetAll();


        if (!string.IsNullOrEmpty(request.Specialization))
            // Compare Specialization directly as a string
            query = query.Where(c =>
                c.Specialization.ToString().Contains(request.Specialization, StringComparison.OrdinalIgnoreCase));
        if (request.Availability.HasValue) query = query.Where(c => c.IsAvialable == request.Availability.Value);

        if (request.ProfileVerified.HasValue)
            query = query.Where(c => c.ProfileVerified == request.ProfileVerified.Value);

        if (request.MinExperience.HasValue) query = query.Where(c => c.Experience >= request.MinExperience.Value);

        if (request.MinRating.HasValue) query = query.Where(c => c.Rating >= request.MinRating.Value);

        var result = await query.ToListAsync(cancellationToken);

        return result.CraftsmanDtos().ToList();
    }
}