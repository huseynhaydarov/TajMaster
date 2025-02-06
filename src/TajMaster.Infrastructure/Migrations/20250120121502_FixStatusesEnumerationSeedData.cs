using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TajMaster.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixStatusesEnumerationSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CartStatuses",
                columns: new[] { "Id", "Code", "IsActive", "Name" },
                values: new object[,]
                {
                    { new Guid("a801a3e9-72e2-4ac6-b3ec-79890492c1cf"), "cart-active", true, "Активный" },
                    { new Guid("c750262b-312f-462d-9737-fd66e75efafe"), "cart-created", true, "Создан" },
                    { new Guid("cb57360a-7021-4042-a971-abdafa48c28b"), "cart-inactive", false, "Неактивный" }
                });

            migrationBuilder.InsertData(
                table: "OrderStatuses",
                columns: new[] { "Id", "Code", "IsActive", "Name" },
                values: new object[,]
                {
                    { new Guid("29d3b5ac-308f-4b9f-88cc-f50e85ebd62f"), "order-shipped", true, "Отправлен" },
                    { new Guid("34f87352-d87d-41f5-bc7c-7dbf7fcff805"), "order-completed", true, "Завершён" },
                    { new Guid("82b4051c-24b8-4a4e-9c75-5b892556d5a7"), "order-cancelled", false, "Отменён" },
                    { new Guid("95b331c6-c258-4d1c-8eb3-431f34845f2b"), "order-accepted", true, "Принято" },
                    { new Guid("d7a6c7a2-f742-4f6c-ae3d-0eb6f8f372ec"), "order-in-progress", true, "В процессе" },
                    { new Guid("e5b50c69-b4d4-4c48-85a1-65a8e77f6459"), "order-pending", true, "В ожидании" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CartStatuses",
                keyColumn: "Id",
                keyValue: new Guid("a801a3e9-72e2-4ac6-b3ec-79890492c1cf"));

            migrationBuilder.DeleteData(
                table: "CartStatuses",
                keyColumn: "Id",
                keyValue: new Guid("c750262b-312f-462d-9737-fd66e75efafe"));

            migrationBuilder.DeleteData(
                table: "CartStatuses",
                keyColumn: "Id",
                keyValue: new Guid("cb57360a-7021-4042-a971-abdafa48c28b"));

            migrationBuilder.DeleteData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: new Guid("29d3b5ac-308f-4b9f-88cc-f50e85ebd62f"));

            migrationBuilder.DeleteData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: new Guid("34f87352-d87d-41f5-bc7c-7dbf7fcff805"));

            migrationBuilder.DeleteData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: new Guid("82b4051c-24b8-4a4e-9c75-5b892556d5a7"));

            migrationBuilder.DeleteData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: new Guid("95b331c6-c258-4d1c-8eb3-431f34845f2b"));

            migrationBuilder.DeleteData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: new Guid("d7a6c7a2-f742-4f6c-ae3d-0eb6f8f372ec"));

            migrationBuilder.DeleteData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: new Guid("e5b50c69-b4d4-4c48-85a1-65a8e77f6459"));
        }
    }
}
