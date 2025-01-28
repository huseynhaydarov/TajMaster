using AutoMapper;
using TajMaster.Application.UseCases.Reviews.Commands.Update;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.Reviews.ReviewMappings;

public class UpdateReviewMapper : Profile
{
    public UpdateReviewMapper()
    {
        CreateMap<UpdateReviewCommand, Review>();
    }
}