using TajMaster.Application.UseCases.Services.ServiceDtos;

namespace TajMaster.Application.UseCases.Categories.CategoryDto;

public record CategoryDto(
    int CategoryId,
    string Name,
    string Description);