using TajMaster.Domain.Abstractions;

namespace TajMaster.Domain.Enumerations
{
    public class OrderEnum : BaseEnum
    {
        public static readonly OrderEnum Pending =
            new(Guid.Parse("e5b50c69-b4d4-4c48-85a1-65a8e77f6459"), "В ожидании", "order-pending", true);

        public static readonly OrderEnum Accepted =
            new(Guid.Parse("95b331c6-c258-4d1c-8eb3-431f34845f2b"), "Принято", "order-accepted", true);

        public static readonly OrderEnum Shipped =
            new(Guid.Parse("29d3b5ac-308f-4b9f-88cc-f50e85ebd62f"), "Отправлен", "order-shipped", true);

        public static readonly OrderEnum Cancelled =
            new(Guid.Parse("82b4051c-24b8-4a4e-9c75-5b892556d5a7"), "Отменён", "order-cancelled", false);

        public static readonly OrderEnum Completed =
            new(Guid.Parse("34f87352-d87d-41f5-bc7c-7dbf7fcff805"), "Завершён", "order-completed", true);

        public static readonly OrderEnum InProgress =
            new(Guid.Parse("d7a6c7a2-f742-4f6c-ae3d-0eb6f8f372ec"), "В процессе", "order-in-progress", true);


        private OrderEnum(Guid id, string name, string code, bool isActive)
            : base(name, code, isActive)
        {
            Id = id;
        }
    }
}