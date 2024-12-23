using AutoMapper;
using TajMaster.Application.UseCases.Categories.Commands;
using TajMaster.Application.UseCases.Categories.Commands.Create;
using TajMaster.Application.UseCases.Categories.Commands.Update;
using TajMaster.Application.UseCases.DTO;
using TajMaster.Application.UseCases.Orders;
using TajMaster.Application.UseCases.Orders.Create;
using TajMaster.Application.UseCases.Reviews.Commands.Create;
using TajMaster.Application.UseCases.Reviews.Commands.Update;
using TajMaster.Application.UseCases.Services.Commands.Create;
using TajMaster.Application.UseCases.Services.Commands.Update;
using TajMaster.Application.UseCases.Users.Commands.Create;
using TajMaster.Application.UseCases.Users.Commands.Update;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.Mappers;

public class AutoMapperConfiguration : Profile
{
    public AutoMapperConfiguration()
    {
        CreateMap<CreateUserCommand, User>();
        CreateMap<UpdateUserCommand, User>();
        CreateMap<User, UserDto>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.RegisterDate, opt => opt.MapFrom(src => src.RegisteredDate))
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Roles.ToString()));


        CreateMap<CreateServiceCommand, Service>()
            .ForMember(dest => dest.Categories, opt => opt.Ignore());
        CreateMap<UpdateServiceCommand, Service>();
        CreateMap<Service, ServiceDto>()
            .ForMember(dest => dest.ServiceId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.Categories));

       CreateMap<CreateReviewCommand, Review>();
       CreateMap<UpdateReviewCommand, Review>();
        CreateMap<Review, ReviewDto>()
            .ForMember(dest => dest.ReviewId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.ReviewDate));

        CreateMap<OrderItem, OrderItemDto>();

        CreateMap<CreateOrderCommand, Order>();
        CreateMap<Order, OrderDto>()
            .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.OrderStatus, opt => opt.MapFrom(src => src.Status.ToString()))
            .ForMember(dest => dest.Reviews, opt => opt.MapFrom(src => src.Reviews))
            .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems));

        CreateMap<Craftsman, CraftsmanDto>()
            .ForMember(dest => dest.CraftsmanId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Specialization, opt => opt.MapFrom(src => src.Specialization.ToString()))
            .ForMember(dest => dest.Avialable, opt => opt.MapFrom(src => src.IsAvialable))
            .ForMember(dest => dest.Orders, opt => opt.MapFrom(src => src.Orders))
            .ForMember(dest => dest.Services, opt => opt.MapFrom(src => src.Services))
            .ForMember(dest => dest.ReviewsCraftsman, opt => opt.MapFrom(src => src.Reviews));

        CreateMap<CreateCategoryCommand, Category>();
        CreateMap<UpdateCategoryCommand, Category>();
        CreateMap<Category, CategoryDto>()
            .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Services, opt => opt.MapFrom(src => src.Services));

        CreateMap<CartItem, CartItemDto>()
            .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.Price * src.Quantity))
            .ForMember(dest => dest.ServiceName, opt => opt.MapFrom(src => src.Service.Title));

        CreateMap<Cart, CartDto>()
            .ForMember(dest => dest.CartId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.CartStatus, opt => opt.MapFrom(src => src.CartStatus.ToString()))
            .ForMember(dest => dest.CartItems, opt => opt.MapFrom(src => src.CartItems));
    }
}