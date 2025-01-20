using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TajMaster.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedUserRoleEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserRoleEnum",
                columns: new[] { "Id", "Code", "IsActive", "Name" },
                values: new object[,]
                {
                    { new Guid("a56f5cb3-8b5b-432b-92f5-61d99f9fa4e8"), "user-admin", true, "Admin" },
                    { new Guid("b66f6db3-9b6c-442b-93f6-71e99f9fa5f9"), "user-guest", true, "Guest" },
                    { new Guid("e36f8db3-6b4a-412a-90f4-41b98f9fa2c6"), "user-customer", true, "Customer" },
                    { new Guid("f46e4db3-7a4b-422b-91e4-51c99f9fa3d7"), "user-craftsman", true, "Craftsman" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoleEnum",
                keyColumn: "Id",
                keyValue: new Guid("a56f5cb3-8b5b-432b-92f5-61d99f9fa4e8"));

            migrationBuilder.DeleteData(
                table: "UserRoleEnum",
                keyColumn: "Id",
                keyValue: new Guid("b66f6db3-9b6c-442b-93f6-71e99f9fa5f9"));

            migrationBuilder.DeleteData(
                table: "UserRoleEnum",
                keyColumn: "Id",
                keyValue: new Guid("e36f8db3-6b4a-412a-90f4-41b98f9fa2c6"));

            migrationBuilder.DeleteData(
                table: "UserRoleEnum",
                keyColumn: "Id",
                keyValue: new Guid("f46e4db3-7a4b-422b-91e4-51c99f9fa3d7"));
        }
    }
}
