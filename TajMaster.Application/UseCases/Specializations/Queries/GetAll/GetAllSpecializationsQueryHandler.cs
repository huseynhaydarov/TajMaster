using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.UseCases.Specializations.SpecializationDtos;
using TajMaster.Application.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace TajMaster.Application.UseCases.Specializations.Queries.GetAll
{
    public class GetAllSpecializationsQueryHandler(IApplicationDbContext context)
        : IQueryHandler<GetAllSpecializationsQuery, List<SpecializationDto>>
    {
        public async Task<List<SpecializationDto>> Handle(GetAllSpecializationsQuery query, 
            CancellationToken cancellationToken)
        {
            var specializations = await context.Specializations
                .AsNoTracking()
                .Include(c => c.Craftsmen)
                .ToListAsync(cancellationToken);

            if (specializations == null || !specializations.Any())
            {
                throw new NotFoundException("No specializations found");
            }
            
            var specializationsDto = new List<SpecializationDto>();
            
            return specializationsDto;
        }
    }
}