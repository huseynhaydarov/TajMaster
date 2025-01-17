using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TajMaster.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixedCartStatusRelationWithCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CartStatus",
                table: "Carts");

            migrationBuilder.AddColumn<Guid>(
                name: "CartStatusId",
                table: "Carts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Carts_CartStatusId",
                table: "Carts",
                column: "CartStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_CartStatuses_CartStatusId",
                table: "Carts",
                column: "CartStatusId",
                principalTable: "CartStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_CartStatuses_CartStatusId",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_CartStatusId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "CartStatusId",
                table: "Carts");

            migrationBuilder.AddColumn<string>(
                name: "CartStatus",
                table: "Carts",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
