namespace TajMaster.Application.UseCases.Categories.CategoryDtos;

public record CategoryDto(
    Guid CategoryId,
    string Name,
    string Description);