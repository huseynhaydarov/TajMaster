using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TajMaster.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixedCartStatusEntityRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_CartStatuses_Id",
                table: "Carts");

            migrationBuilder.AddColumn<Guid>(
                name: "CartId",
                table: "CartStatuses",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_CartStatuses_CartId",
                table: "CartStatuses",
                column: "CartId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CartStatuses_Carts_CartId",
                table: "CartStatuses",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartStatuses_Carts_CartId",
                table: "CartStatuses");

            migrationBuilder.DropIndex(
                name: "IX_CartStatuses_CartId",
                table: "CartStatuses");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "CartStatuses");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_CartStatuses_Id",
                table: "Carts",
                column: "Id",
                principalTable: "CartStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
