using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TajMaster.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCartStatusEnumTypeToModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Carts_cartid",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Services_serviceid",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Users_userid",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryServices_Categories_categoryid",
                table: "CategoryServices");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryServices_Services_serviceid",
                table: "CategoryServices");

            migrationBuilder.DropForeignKey(
                name: "FK_Craftsmen_Users_userid",
                table: "Craftsmen");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_orderid",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Services_serviceid",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Craftsmen_craftsmanid",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_userid",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Craftsmen_craftsmanid",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Orders_orderid",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Users_userid",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Craftsmen_craftsmanid",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "cartstatus",
                table: "Carts");

            migrationBuilder.RenameColumn(
                name: "roles",
                table: "Users",
                newName: "Roles");

            migrationBuilder.RenameColumn(
                name: "registereddate",
                table: "Users",
                newName: "RegisteredDate");

            migrationBuilder.RenameColumn(
                name: "phone",
                table: "Users",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "isactive",
                table: "Users",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "hashedpassword",
                table: "Users",
                newName: "HashedPassword");

            migrationBuilder.RenameColumn(
                name: "fullname",
                table: "Users",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "Users",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Users_email",
                table: "Users",
                newName: "IX_Users_Email");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "Services",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Services",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "craftsmanid",
                table: "Services",
                newName: "CraftsmanId");

            migrationBuilder.RenameColumn(
                name: "baseprice",
                table: "Services",
                newName: "BasePrice");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Services",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Services_craftsmanid",
                table: "Services",
                newName: "IX_Services_CraftsmanId");

            migrationBuilder.RenameColumn(
                name: "userid",
                table: "Reviews",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "reviewdate",
                table: "Reviews",
                newName: "ReviewDate");

            migrationBuilder.RenameColumn(
                name: "rating",
                table: "Reviews",
                newName: "Rating");

            migrationBuilder.RenameColumn(
                name: "orderid",
                table: "Reviews",
                newName: "OrderId");

            migrationBuilder.RenameColumn(
                name: "craftsmanid",
                table: "Reviews",
                newName: "CraftsmanId");

            migrationBuilder.RenameColumn(
                name: "comment",
                table: "Reviews",
                newName: "Comment");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Reviews",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_userid",
                table: "Reviews",
                newName: "IX_Reviews_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_orderid",
                table: "Reviews",
                newName: "IX_Reviews_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_craftsmanid",
                table: "Reviews",
                newName: "IX_Reviews_CraftsmanId");

            migrationBuilder.RenameColumn(
                name: "userid",
                table: "Orders",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "totalprice",
                table: "Orders",
                newName: "TotalPrice");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Orders",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "craftsmanid",
                table: "Orders",
                newName: "CraftsmanId");

            migrationBuilder.RenameColumn(
                name: "appointmentdate",
                table: "Orders",
                newName: "AppointmentDate");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "Orders",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Orders",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_userid",
                table: "Orders",
                newName: "IX_Orders_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_craftsmanid",
                table: "Orders",
                newName: "IX_Orders_CraftsmanId");

            migrationBuilder.RenameColumn(
                name: "serviceid",
                table: "OrderItems",
                newName: "ServiceId");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "OrderItems",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "OrderItems",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "orderid",
                table: "OrderItems",
                newName: "OrderId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "OrderItems",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_serviceid",
                table: "OrderItems",
                newName: "IX_OrderItems_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_orderid",
                table: "OrderItems",
                newName: "IX_OrderItems_OrderId");

            migrationBuilder.RenameColumn(
                name: "userid",
                table: "Craftsmen",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "specialization",
                table: "Craftsmen",
                newName: "Specialization");

            migrationBuilder.RenameColumn(
                name: "rating",
                table: "Craftsmen",
                newName: "Rating");

            migrationBuilder.RenameColumn(
                name: "profileverified",
                table: "Craftsmen",
                newName: "ProfileVerified");

            migrationBuilder.RenameColumn(
                name: "profilepicture",
                table: "Craftsmen",
                newName: "ProfilePicture");

            migrationBuilder.RenameColumn(
                name: "isavialable",
                table: "Craftsmen",
                newName: "IsAvialable");

            migrationBuilder.RenameColumn(
                name: "experience",
                table: "Craftsmen",
                newName: "Experience");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Craftsmen",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Craftsmen",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Craftsmen_userid",
                table: "Craftsmen",
                newName: "IX_Craftsmen_UserId");

            migrationBuilder.RenameColumn(
                name: "serviceid",
                table: "CategoryServices",
                newName: "ServiceId");

            migrationBuilder.RenameColumn(
                name: "categoryid",
                table: "CategoryServices",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryServices_serviceid",
                table: "CategoryServices",
                newName: "IX_CategoryServices_ServiceId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Categories",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Categories",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Categories",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "userid",
                table: "Carts",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Carts",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Carts_userid",
                table: "Carts",
                newName: "IX_Carts_UserId");

            migrationBuilder.RenameColumn(
                name: "serviceid",
                table: "CartItems",
                newName: "ServiceId");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "CartItems",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "CartItems",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "cartid",
                table: "CartItems",
                newName: "CartId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "CartItems",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_CartItems_serviceid",
                table: "CartItems",
                newName: "IX_CartItems_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_CartItems_cartid",
                table: "CartItems",
                newName: "IX_CartItems_CartId");

            migrationBuilder.CreateTable(
                name: "CartStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Code = table.Column<int>(type: "integer", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartStatuses", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Carts_CartId",
                table: "CartItems",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Services_ServiceId",
                table: "CartItems",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_CartStatuses_Id",
                table: "Carts",
                column: "Id",
                principalTable: "CartStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Users_UserId",
                table: "Carts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryServices_Categories_CategoryId",
                table: "CategoryServices",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryServices_Services_ServiceId",
                table: "CategoryServices",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Craftsmen_Users_UserId",
                table: "Craftsmen",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Services_ServiceId",
                table: "OrderItems",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Craftsmen_CraftsmanId",
                table: "Orders",
                column: "CraftsmanId",
                principalTable: "Craftsmen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Craftsmen_CraftsmanId",
                table: "Reviews",
                column: "CraftsmanId",
                principalTable: "Craftsmen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Orders_OrderId",
                table: "Reviews",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Users_UserId",
                table: "Reviews",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Craftsmen_CraftsmanId",
                table: "Services",
                column: "CraftsmanId",
                principalTable: "Craftsmen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Carts_CartId",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Services_ServiceId",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_CartStatuses_Id",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Users_UserId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryServices_Categories_CategoryId",
                table: "CategoryServices");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryServices_Services_ServiceId",
                table: "CategoryServices");

            migrationBuilder.DropForeignKey(
                name: "FK_Craftsmen_Users_UserId",
                table: "Craftsmen");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Services_ServiceId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Craftsmen_CraftsmanId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Craftsmen_CraftsmanId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Orders_OrderId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Users_UserId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Craftsmen_CraftsmanId",
                table: "Services");

            migrationBuilder.DropTable(
                name: "CartStatuses");

            migrationBuilder.RenameColumn(
                name: "Roles",
                table: "Users",
                newName: "roles");

            migrationBuilder.RenameColumn(
                name: "RegisteredDate",
                table: "Users",
                newName: "registereddate");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Users",
                newName: "phone");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Users",
                newName: "isactive");

            migrationBuilder.RenameColumn(
                name: "HashedPassword",
                table: "Users",
                newName: "hashedpassword");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Users",
                newName: "fullname");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Users",
                newName: "address");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Users_Email",
                table: "Users",
                newName: "IX_Users_email");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Services",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Services",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "CraftsmanId",
                table: "Services",
                newName: "craftsmanid");

            migrationBuilder.RenameColumn(
                name: "BasePrice",
                table: "Services",
                newName: "baseprice");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Services",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Services_CraftsmanId",
                table: "Services",
                newName: "IX_Services_craftsmanid");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Reviews",
                newName: "userid");

            migrationBuilder.RenameColumn(
                name: "ReviewDate",
                table: "Reviews",
                newName: "reviewdate");

            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "Reviews",
                newName: "rating");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Reviews",
                newName: "orderid");

            migrationBuilder.RenameColumn(
                name: "CraftsmanId",
                table: "Reviews",
                newName: "craftsmanid");

            migrationBuilder.RenameColumn(
                name: "Comment",
                table: "Reviews",
                newName: "comment");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Reviews",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                newName: "IX_Reviews_userid");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_OrderId",
                table: "Reviews",
                newName: "IX_Reviews_orderid");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_CraftsmanId",
                table: "Reviews",
                newName: "IX_Reviews_craftsmanid");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Orders",
                newName: "userid");

            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                table: "Orders",
                newName: "totalprice");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Orders",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "CraftsmanId",
                table: "Orders",
                newName: "craftsmanid");

            migrationBuilder.RenameColumn(
                name: "AppointmentDate",
                table: "Orders",
                newName: "appointmentdate");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Orders",
                newName: "address");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Orders",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                newName: "IX_Orders_userid");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_CraftsmanId",
                table: "Orders",
                newName: "IX_Orders_craftsmanid");

            migrationBuilder.RenameColumn(
                name: "ServiceId",
                table: "OrderItems",
                newName: "serviceid");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "OrderItems",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "OrderItems",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "OrderItems",
                newName: "orderid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "OrderItems",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_ServiceId",
                table: "OrderItems",
                newName: "IX_OrderItems_serviceid");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                newName: "IX_OrderItems_orderid");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Craftsmen",
                newName: "userid");

            migrationBuilder.RenameColumn(
                name: "Specialization",
                table: "Craftsmen",
                newName: "specialization");

            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "Craftsmen",
                newName: "rating");

            migrationBuilder.RenameColumn(
                name: "ProfileVerified",
                table: "Craftsmen",
                newName: "profileverified");

            migrationBuilder.RenameColumn(
                name: "ProfilePicture",
                table: "Craftsmen",
                newName: "profilepicture");

            migrationBuilder.RenameColumn(
                name: "IsAvialable",
                table: "Craftsmen",
                newName: "isavialable");

            migrationBuilder.RenameColumn(
                name: "Experience",
                table: "Craftsmen",
                newName: "experience");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Craftsmen",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Craftsmen",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Craftsmen_UserId",
                table: "Craftsmen",
                newName: "IX_Craftsmen_userid");

            migrationBuilder.RenameColumn(
                name: "ServiceId",
                table: "CategoryServices",
                newName: "serviceid");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "CategoryServices",
                newName: "categoryid");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryServices_ServiceId",
                table: "CategoryServices",
                newName: "IX_CategoryServices_serviceid");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Categories",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Categories",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Categories",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Carts",
                newName: "userid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Carts",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                newName: "IX_Carts_userid");

            migrationBuilder.RenameColumn(
                name: "ServiceId",
                table: "CartItems",
                newName: "serviceid");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "CartItems",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "CartItems",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "CartId",
                table: "CartItems",
                newName: "cartid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CartItems",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_CartItems_ServiceId",
                table: "CartItems",
                newName: "IX_CartItems_serviceid");

            migrationBuilder.RenameIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                newName: "IX_CartItems_cartid");

            migrationBuilder.AddColumn<string>(
                name: "cartstatus",
                table: "Carts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Carts_cartid",
                table: "CartItems",
                column: "cartid",
                principalTable: "Carts",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Services_serviceid",
                table: "CartItems",
                column: "serviceid",
                principalTable: "Services",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Users_userid",
                table: "Carts",
                column: "userid",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryServices_Categories_categoryid",
                table: "CategoryServices",
                column: "categoryid",
                principalTable: "Categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryServices_Services_serviceid",
                table: "CategoryServices",
                column: "serviceid",
                principalTable: "Services",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Craftsmen_Users_userid",
                table: "Craftsmen",
                column: "userid",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_orderid",
                table: "OrderItems",
                column: "orderid",
                principalTable: "Orders",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Services_serviceid",
                table: "OrderItems",
                column: "serviceid",
                principalTable: "Services",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Craftsmen_craftsmanid",
                table: "Orders",
                column: "craftsmanid",
                principalTable: "Craftsmen",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_userid",
                table: "Orders",
                column: "userid",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Craftsmen_craftsmanid",
                table: "Reviews",
                column: "craftsmanid",
                principalTable: "Craftsmen",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Orders_orderid",
                table: "Reviews",
                column: "orderid",
                principalTable: "Orders",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Users_userid",
                table: "Reviews",
                column: "userid",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Craftsmen_craftsmanid",
                table: "Services",
                column: "craftsmanid",
                principalTable: "Craftsmen",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
