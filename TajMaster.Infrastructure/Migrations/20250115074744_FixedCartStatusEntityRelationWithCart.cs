using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TajMaster.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixedCartStatusEntityRelationWithCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartStatuses_Carts_CartId",
                table: "CartStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryServices",
                table: "CategoryServices");

            migrationBuilder.DropIndex(
                name: "IX_CartStatuses_CartId",
                table: "CartStatuses");

            migrationBuilder.DropColumn(
                name: "Specialization",
                table: "Craftsmen");

            migrationBuilder.DropColumn(
                name: "CartStatusId",
                table: "Carts");

            migrationBuilder.AddColumn<Guid>(
                name: "SpecializationId",
                table: "Craftsmen",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "CategoryServices",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "CartStatus",
                table: "Carts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryServices",
                table: "CategoryServices",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Specializations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specializations", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Craftsmen_SpecializationId",
                table: "Craftsmen",
                column: "SpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryServices_CategoryId",
                table: "CategoryServices",
                column: "CategoryId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Craftsmen_Specializations_SpecializationId",
                table: "Craftsmen",
                column: "SpecializationId",
                principalTable: "Specializations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartStatuses_Carts_CartId",
                table: "CartStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_Craftsmen_Specializations_SpecializationId",
                table: "Craftsmen");

            migrationBuilder.DropTable(
                name: "Specializations");

            migrationBuilder.DropIndex(
                name: "IX_Craftsmen_SpecializationId",
                table: "Craftsmen");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryServices",
                table: "CategoryServices");

            migrationBuilder.DropIndex(
                name: "IX_CategoryServices_CategoryId",
                table: "CategoryServices");

            migrationBuilder.DropIndex(
                name: "IX_CartStatuses_CartId",
                table: "CartStatuses");

            migrationBuilder.DropColumn(
                name: "SpecializationId",
                table: "Craftsmen");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CategoryServices");

            migrationBuilder.DropColumn(
                name: "CartStatus",
                table: "Carts");

            migrationBuilder.AddColumn<string>(
                name: "Specialization",
                table: "Craftsmen",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "CartStatusId",
                table: "Carts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryServices",
                table: "CategoryServices",
                columns: new[] { "CategoryId", "ServiceId" });

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
    }
}
