using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TajMaster.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixSeedUserRoleEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserRoleEnum_UserRoleId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "UserRoleEnum");

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "Id", "Code", "IsActive", "Name" },
                values: new object[,]
                {
                    { new Guid("a56f5cb3-8b5b-432b-92f5-61d99f9fa4e8"), "user-admin", true, "Admin" },
                    { new Guid("b66f6db3-9b6c-442b-93f6-71e99f9fa5f9"), "user-guest", true, "Guest" },
                    { new Guid("e36f8db3-6b4a-412a-90f4-41b98f9fa2c6"), "user-customer", true, "Customer" },
                    { new Guid("f46e4db3-7a4b-422b-91e4-51c99f9fa3d7"), "user-craftsman", true, "Craftsman" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserRole_UserRoleId",
                table: "Users",
                column: "UserRoleId",
                principalTable: "UserRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserRole_UserRoleId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.CreateTable(
                name: "UserRoleEnum",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoleEnum", x => x.Id);
                });

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

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserRoleEnum_UserRoleId",
                table: "Users",
                column: "UserRoleId",
                principalTable: "UserRoleEnum",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
