using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.UseCases.DTO;

namespace TajMaster.Application.UseCases.Craftsmen.Queries.SearchCraftsmen;

public class SearchCraftsmenQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<SearchCraftsmenQuery, List<CraftsmanDto>>
{
    public async Task<List<CraftsmanDto>> Handle(SearchCraftsmenQuery request, CancellationToken cancellationToken)
    {
            var query = unitOfWork.CraftsmanRepository.GetAll(); // Assuming a GetAll method exists
            

            if (!string.IsNullOrEmpty(request.Specialization))
            {
                query = query.Where(c => c.Specialization.ToString().Contains(request.Specialization, StringComparison.OrdinalIgnoreCase));
            }

            if (request.Availability.HasValue)
            {
                query = query.Where(c => c.IsAvialable == request.Availability.Value);
            }

            if (request.ProfileVerified.HasValue)
            {
                query = query.Where(c => c.ProfileVerified == request.ProfileVerified.Value);
            }

            if (request.MinExperience.HasValue)
            {
                query = query.Where(c => c.Experience >= request.MinExperience.Value);
            }

            if (request.MinRating.HasValue)
            {
                query = query.Where(c => c.Rating >= request.MinRating.Value);
            }

            // Execute query and return the result as a list of CraftsmanDto
            var result = await query.ToListAsync(cancellationToken);

            return mapper.Map<List<CraftsmanDto>>(result);
    }
}

