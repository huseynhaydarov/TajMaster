namespace TajMaster.Application.UseCases.DTO;

public record ReviewDto(
    int ReviewId,
    int OrderId,
    int UserId,
    int CraftsmanId,
    int Rating,
    string? Comment,
    DateTime CreatedDate);