using AutoMapper;
using TajMaster.Application.UseCases.Reviews.Commands.Create;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.Reviews.ReviewMappings;

public class CreateReviewMapper : Profile
{
    public CreateReviewMapper()
    {
        CreateMap<CreateReviewCommand, Review>();
    }
}