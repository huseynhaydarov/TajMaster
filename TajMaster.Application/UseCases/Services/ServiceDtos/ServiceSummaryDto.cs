namespace TajMaster.Application.UseCases.Services.ServiceDtos;

public record ServiceSummaryDto(
    int ServiceId,
    string Title,
    string Description,
    decimal BasePrice);