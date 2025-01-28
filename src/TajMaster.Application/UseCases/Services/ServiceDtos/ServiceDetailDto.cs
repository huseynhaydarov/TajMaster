using TajMaster.Application.UseCases.Categories.CategoryDtos;

namespace TajMaster.Application.UseCases.Services.ServiceDtos;

public record ServiceDetailDto(
    Guid ServiceId,
    string Title,
    string Description,
    decimal BasePrice,
    List<CategoryDto>? Categories);