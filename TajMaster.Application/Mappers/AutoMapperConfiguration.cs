using AutoMapper;
using TajMaster.Application.UseCases.Cart.Commands;
using TajMaster.Application.UseCases.CartItem.CartItemDTos;
using TajMaster.Application.UseCases.CartStatus.Command;
using TajMaster.Application.UseCases.CartStatus.Command.Update;
using TajMaster.Application.UseCases.CartStatuses.Command.Create;
using TajMaster.Application.UseCases.Categories.Commands.Create;
using TajMaster.Application.UseCases.Categories.Commands.Update;
using TajMaster.Application.UseCases.Craftsmen.Commands.Create.CompleteCraftsmanProfile;
using TajMaster.Application.UseCases.Craftsmen.Commands.Create.CreateCraftsman;
using TajMaster.Application.UseCases.Craftsmen.Commands.Update.UpdateCraftsman;
using TajMaster.Application.UseCases.OrderItems;
using TajMaster.Application.UseCases.Orders.Create;
using TajMaster.Application.UseCases.Reviews.Commands.Create;
using TajMaster.Application.UseCases.Reviews.Commands.Update;
using TajMaster.Application.UseCases.Reviews.ReviewDtos;
using TajMaster.Application.UseCases.Services.Commands.Create;
using TajMaster.Application.UseCases.Services.Commands.Update;
using TajMaster.Application.UseCases.Specializations.Command.Create;
using TajMaster.Application.UseCases.Specializations.Commands.Update;
using TajMaster.Application.UseCases.Users.Commands.Create;
using TajMaster.Application.UseCases.Users.Commands.Update;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.Mappers;

public class AutoMapperConfiguration : Profile
{
    public AutoMapperConfiguration()
    {
        CreateMap<CreateUserCommand, User>()
            .ForMember(dest => dest.HashedPassword, opt => opt.MapFrom(src => src.Password));
        CreateMap<UpdateUserCommand, User>();

        CreateMap<CreateServiceCommand, Service>()
            .ForMember(dest => dest.CategoryServices, opt => opt.Ignore());
        CreateMap<UpdateServiceCommand, Service>()
            .ForMember(dest => dest.CategoryServices, opt => opt.Ignore());

        CreateMap<CreateReviewCommand, Review>();
        CreateMap<UpdateReviewCommand, Review>();
        CreateMap<Review, ReviewDto>()
            .ForMember(dest => dest.ReviewId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.ReviewDate));

        CreateMap<OrderItem, OrderItemDto>();

        CreateMap<CreateOrderCommand, Order>();


        CreateMap<CompleteCraftsmanProfileCommand, Craftsman>()
            .ForMember(c => c.Description, opt => opt.MapFrom(src => src.About))
            .ForMember(c => c.Specialization, opt => opt.MapFrom(src => src.Specialization))
            .ForMember(c => c.ProfilePicture, opt => opt.Ignore());
        CreateMap<CreateCraftsmanCommand, User>()
            .ForMember(dest => dest.HashedPassword, opt => opt.MapFrom(src => src.Password));
        CreateMap<UpdateCraftsmanCommand, Craftsman>();

        CreateMap<CreateCategoryCommand, Category>();
        CreateMap<UpdateCategoryCommand, Category>();

        CreateMap<CartItem, CartItemDto>()
            .ForMember(dest => dest.ServiceName, opt => opt.MapFrom(src => src.Service.Title));

        CreateMap<CreateCartCommand, Cart>();

        CreateMap<CreateCartStatusCommand, CartStatusEntity>();
        CreateMap<UpdateCartStatusCommand, CartStatusEntity>();

        CreateMap<CreateSpecializationCommand, Specialization>();
        CreateMap<UpdateSpecializationCommand, Specialization>();
    }
}