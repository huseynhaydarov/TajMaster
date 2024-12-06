using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.Repositories;
using TajMaster.Domain.Entities;

namespace TajMaster.Infrastructure.Persistence.Repositories;


public class OrderItemRepository(DbContext context) : Repository<OrderItem>(context), IOrderItemRepository
{
}