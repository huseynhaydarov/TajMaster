using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TajMaster.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedCartStatusEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CartStatuses",
                columns: new[] { "Id", "Code", "IsActive", "Name" },
                values: new object[] { new Guid("2b34e0bc-41c4-4030-bb74-60af17b09634"), "cart-archived", true, "Архивирован" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CartStatuses",
                keyColumn: "Id",
                keyValue: new Guid("2b34e0bc-41c4-4030-bb74-60af17b09634"));
        }
    }
}
