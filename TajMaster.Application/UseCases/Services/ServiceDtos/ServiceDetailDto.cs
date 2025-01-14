using TajMaster.Application.UseCases.Categories.CategoryDto;

namespace TajMaster.Application.UseCases.Services.ServiceDtos;

public record ServiceDetailDto(
    Guid ServiceId,
    string Title,
    string Description,
    decimal BasePrice,
    List<CategoryDto>? Categories);