using AutoMapper;
using TajMaster.Application.UseCases.CartItems.CartItemDTos;
using TajMaster.Application.UseCases.Carts.Commands;
using TajMaster.Application.UseCases.CartStatuses.Command.Create;
using TajMaster.Application.UseCases.CartStatuses.Command.Update;
using TajMaster.Application.UseCases.Categories.Commands.Create;
using TajMaster.Application.UseCases.Categories.Commands.Update;
using TajMaster.Application.UseCases.Craftsmen.Commands.Create.CompleteCraftsmanProfile;
using TajMaster.Application.UseCases.Craftsmen.Commands.Create.CreateCraftsman;
using TajMaster.Application.UseCases.Craftsmen.Commands.Update.UpdateAvailability;
using TajMaster.Application.UseCases.Craftsmen.Commands.Update.UpdateCraftsman;
using TajMaster.Application.UseCases.OrderItems;
using TajMaster.Application.UseCases.Orders.Create;
using TajMaster.Application.UseCases.OrderStatuses.Commands.Create;
using TajMaster.Application.UseCases.OrderStatuses.Commands.Update;
using TajMaster.Application.UseCases.Reviews.Commands.Create;
using TajMaster.Application.UseCases.Reviews.Commands.Update;
using TajMaster.Application.UseCases.Reviews.ReviewDtos;
using TajMaster.Application.UseCases.Services.Commands.Create;
using TajMaster.Application.UseCases.Services.Commands.Update;
using TajMaster.Application.UseCases.Specializations.Commands.Create;
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
            .ForMember(dest => dest.HashedPassword, opt 
                => opt.MapFrom(src => src.Password));
        CreateMap<UpdateUserCommand, User>();

        CreateMap<CreateServiceCommand, Service>()
            .ForMember(dest => dest.CategoryServices, opt 
                => opt.Ignore());
        CreateMap<UpdateServiceCommand, Service>()
            .ForMember(dest => dest.CategoryServices, opt 
                => opt.Ignore());

        CreateMap<CreateReviewCommand, Review>();
        CreateMap<UpdateReviewCommand, Review>();
        CreateMap<Review, ReviewDto>()
            .ForMember(dest => dest.ReviewId, opt 
                => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.CreatedDate, opt 
                => opt.MapFrom(src => src.ReviewDate));

        CreateMap<OrderItem, OrderItemDto>();

        CreateMap<CreateOrderCommand, Order>();

        CreateMap<CompleteCraftsmanProfileCommand, Craftsman>()
            .ForMember(c => c.Description, opt
                => opt.MapFrom(src => src.About))
            .ForMember(c => c.ProfilePicture, opt
                => opt.Ignore())
            .ForMember(c => c.Specialization, opt 
                => opt.Ignore());

        CreateMap<CreateCraftsmanCommand, User>()
            .ForMember(dest => dest.HashedPassword, opt 
                => opt.MapFrom(src => src.Password));
        CreateMap<UpdateCraftsmanCommand, Craftsman>()
            .ForPath(dest => dest.Specialization.Name, opt 
                => opt.MapFrom(src => src.Specialization));
        CreateMap<UpdateCraftsmanAvailabilityCommand, Craftsman>();

        CreateMap<CreateCategoryCommand, Category>();
        CreateMap<UpdateCategoryCommand, Category>();

        CreateMap<CartItem, CartItemDto>()
            .ForMember(dest => dest.ServiceName, opt 
                => opt.MapFrom(src => src.Service.Title));

        CreateMap<CreateCartCommand, Cart>();

        CreateMap<CreateCartStatusCommand, CartStatus>();
        CreateMap<UpdateCartStatusCommand, CartStatus>();

        CreateMap<CreateOrderStatusCommand, OrderStatus>();
        CreateMap<UpdateOrderStatusCommand, OrderStatus>();

        CreateMap<CreateSpecializationCommand, Specialization>();
        CreateMap<UpdateSpecializationCommand, Specialization>();
    }
}