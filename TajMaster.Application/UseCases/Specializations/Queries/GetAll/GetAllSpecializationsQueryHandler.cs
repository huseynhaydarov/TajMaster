using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Common.Pagination;
using TajMaster.Application.UseCases.Specializations.SpecializationDtos;

namespace TajMaster.Application.UseCases.Specializations.Queries.GetAll;

public class GetAllSpecializationsQueryHandler(
    IApplicationDbContext context)
    : IQueryHandler<GetAllSpecializationsQuery, PaginatedResult<SpecializationDto>>
{
    public async Task<PaginatedResult<SpecializationDto>> Handle(GetAllSpecializationsQuery query,
        CancellationToken cancellationToken)
    {
        var pagingParams = query.PagingParameters;

        // Query Specializations with AsNoTracking for read-only operation
        var request = context.Specializations
            .AsNoTracking()
            .AsQueryable();

        request = (bool)pagingParams.OrderByDescending!
            ? request.OrderByDescending(s => s.Id)
            : request.OrderBy(s => s.Id);

        var totalCount = await request.CountAsync(cancellationToken);

        var specializationDtoList = await request
            .Skip((int)((pagingParams.PageNumber - 1) * pagingParams.PageSize)!)
            .Take((int)pagingParams.PageSize!)
            .Select(s => new SpecializationDto(s.Id, s.Name, s.Description))
            .ToListAsync(cancellationToken);

        return new PaginatedResult<SpecializationDto>(
            (int)pagingParams.PageNumber!,
            (int)pagingParams.PageSize,
            totalCount,
            specializationDtoList
        );
    }
}