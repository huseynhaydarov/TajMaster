using TajMaster.Application.UseCases.Categories.CategoryDto;
using TajMaster.Application.UseCases.DTO;

namespace TajMaster.Application.UseCases.Services.ServiceDtos;

public record ServiceDto(
    int ServiceId,
    string Title,
    string Description,
    decimal BasePrice,
    List<CategoryDto>? Categories);