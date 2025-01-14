namespace TajMaster.Application.UseCases.Categories.CategoryDto;

public record CategoryDto(
    Guid CategoryId,
    string Name,
    string Description);