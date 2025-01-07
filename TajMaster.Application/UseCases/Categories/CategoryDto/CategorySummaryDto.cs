using TajMaster.Application.UseCases.Services.ServiceDtos;

namespace TajMaster.Application.UseCases.Categories.CategoryDto;

public record CategorySummaryDto(
    int CategoryId,
    string Name,
    string Description,
    List<ServiceDetailDto> Services);