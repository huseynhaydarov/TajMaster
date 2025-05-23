﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TajMaster.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixEntityRelationOrderCraftsman : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Craftsmen_CraftsmanId",
                table: "Orders");

            migrationBuilder.AlterColumn<Guid>(
                name: "CraftsmanId",
                table: "Orders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Craftsmen_CraftsmanId",
                table: "Orders",
                column: "CraftsmanId",
                principalTable: "Craftsmen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Craftsmen_CraftsmanId",
                table: "Orders");

            migrationBuilder.AlterColumn<Guid>(
                name: "CraftsmanId",
                table: "Orders",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Craftsmen_CraftsmanId",
                table: "Orders",
                column: "CraftsmanId",
                principalTable: "Craftsmen",
                principalColumn: "Id");
        }
    }
}
