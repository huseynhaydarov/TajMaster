using MediatR;
using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;
using TajMaster.Application.UseCases.Specializations.SpecializationDtos;

namespace TajMaster.Application.UseCases.Specializations.Queries.GetById;

public class GetSpecializationByIdQueryHandler(
    IApplicationDbContext context)
    : IRequestHandler<GetSpecializationByIdQuery, SpecializationDto>
{
    public async Task<SpecializationDto> Handle(GetSpecializationByIdQuery query,
        CancellationToken cancellationToken)
    {
        var specialization = await context.Specializations
            .FirstOrDefaultAsync(s => s.Id == query.SpecializationId, cancellationToken);

        if (specialization == null)
            throw new NotFoundException($"Specialization with ID {query.SpecializationId} not found");

        var specializationDto = new SpecializationDto(
            specialization.Id,
            specialization.Name,
            specialization.Description);

        return specializationDto;
    }
}