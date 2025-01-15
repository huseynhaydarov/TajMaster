using MediatR;
using Microsoft.EntityFrameworkCore;
using TajMaster.Application.UseCases.Specializations.SpecializationDtos;
using TajMaster.Domain.Entities;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions; 

namespace TajMaster.Application.UseCases.Specializations.Queries.GetById
{
    public class GetSpecializationByIdQueryHandler(IApplicationDbContext context)
        : IRequestHandler<GetSpecializationByIdQuery, SpecializationDto>
    {
        public async Task<SpecializationDto> Handle(GetSpecializationByIdQuery request, CancellationToken cancellationToken)
        {
            var specialization = await context.Specializations
                .FirstOrDefaultAsync(s => s.Id == request.SpecializationId, cancellationToken);
            
            if (specialization == null)
            {
                throw new NotFoundException(nameof(Specialization));
            }
            
            var specializationDto = new SpecializationDto(specialization.Id, specialization.Name, specialization.Description);

            return specializationDto;
        }
    }
}