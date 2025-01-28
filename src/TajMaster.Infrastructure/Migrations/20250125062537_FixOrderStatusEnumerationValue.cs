using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TajMaster.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixOrderStatusEnumerationValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: new Guid("29d3b5ac-308f-4b9f-88cc-f50e85ebd62f"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "OrderStatuses",
                columns: new[] { "Id", "Code", "IsActive", "Name" },
                values: new object[] { new Guid("29d3b5ac-308f-4b9f-88cc-f50e85ebd62f"), "order-shipped", true, "Отправлен" });
        }
    }
}
