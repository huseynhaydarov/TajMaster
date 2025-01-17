using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TajMaster.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixedCartStatusEntityRelationWithCartSecondary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "CartStatuses",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldMaxLength: 50);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Code",
                table: "CartStatuses",
                type: "integer",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<Guid>(
                name: "CartId",
                table: "CartStatuses",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_CartStatuses_CartId",
                table: "CartStatuses",
                column: "CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartStatuses_Carts_CartId",
                table: "CartStatuses",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
