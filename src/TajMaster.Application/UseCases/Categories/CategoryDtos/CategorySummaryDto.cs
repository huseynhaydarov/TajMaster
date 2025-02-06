using TajMaster.Application.UseCases.Services.ServiceDtos;

namespace TajMaster.Application.UseCases.Categories.CategoryDtos;

public record CategorySummaryDto(
    Guid CategoryId,
    string Name,
    string Description,
    List<ServiceDetailDto> Services);