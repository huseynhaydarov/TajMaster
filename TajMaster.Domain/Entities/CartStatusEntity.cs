using TajMaster.Domain.Abstractions;

namespace TajMaster.Domain.Entities
{
    public class CartStatusEntity : BaseEntity
    {
        public required string Name { get; set; }
        public required string Code { get; set; }
       
    }
}