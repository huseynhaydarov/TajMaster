using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Common.Interfaces.CacheService;
using TajMaster.Application.Common.Pagination;
using TajMaster.Application.UseCases.Specializations.SpecializationDtos;

namespace TajMaster.Application.UseCases.Specializations.Queries.GetAll;

public class GetAllSpecializationsQueryHandler(
    IApplicationDbContext context,
    ICacheService cacheService,
    ILogger<GetAllSpecializationsQueryHandler> logger)
    : IQueryHandler<GetAllSpecializationsQuery, PaginatedResult<SpecializationDto>>
{
    public async Task<PaginatedResult<SpecializationDto>> Handle(GetAllSpecializationsQuery query,
        CancellationToken cancellationToken)
    {
        var pagingParams = query.PagingParameters;

        var cacheKey = "Specializations";

        var specializationsCache = await cacheService.GetOrSetAsync(cacheKey, async () =>
        {
            logger.LogInformation("Cache miss. Fetching specializations from database.");

            var request = context.Specializations
                .AsNoTracking()
                .AsQueryable();

            request = pagingParams.OrderByDescending == true
                ? request.OrderByDescending(s => s.Name)
                : request.OrderBy(s => s.Name);

            var totalCount = await request.CountAsync(cancellationToken);

            var specializationDtoList = await request
                .Skip((int)((pagingParams.PageNumber - 1) * pagingParams.PageSize)! )
                .Take((int)pagingParams.PageSize!)
                .Select(s => new SpecializationDto(s.Id, s.Name, s.Description))
                .ToListAsync(cancellationToken);

            return new PaginatedResult<SpecializationDto>(
                (int)pagingParams.PageNumber!,
                (int)pagingParams.PageSize!,
                totalCount,
                specializationDtoList
            );
        });

        return specializationsCache!;
    }
}
