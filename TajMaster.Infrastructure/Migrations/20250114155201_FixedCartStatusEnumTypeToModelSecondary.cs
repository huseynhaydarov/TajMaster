using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TajMaster.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixedCartStatusEnumTypeToModelSecondary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartStatuses_Carts_Id",
                table: "CartStatuses");

            migrationBuilder.DropColumn(
                name: "CartStatusId",
                table: "CartStatuses");

            migrationBuilder.AddColumn<Guid>(
                name: "CartStatusId",
                table: "Carts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_CartStatuses_Id",
                table: "Carts",
                column: "Id",
                principalTable: "CartStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_CartStatuses_Id",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "CartStatusId",
                table: "Carts");

            migrationBuilder.AddColumn<Guid>(
                name: "CartStatusId",
                table: "CartStatuses",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CartStatuses_Carts_Id",
                table: "CartStatuses",
                column: "Id",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
