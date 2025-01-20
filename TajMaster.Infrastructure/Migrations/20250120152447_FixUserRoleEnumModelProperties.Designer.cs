﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TajMaster.Infrastructure.Persistence.Data;

#nullable disable

namespace TajMaster.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250120152447_FixUserRoleEnumModelProperties")]
    partial class FixUserRoleEnumModelProperties
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TajMaster.Domain.Entities.Cart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CartStatusId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CartStatusId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("TajMaster.Domain.Entities.CartItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CartId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Price")
                        .HasPrecision(14, 2)
                        .HasColumnType("numeric(14,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<Guid>("ServiceId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("ServiceId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("TajMaster.Domain.Entities.CartStatus", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("CartStatuses");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c750262b-312f-462d-9737-fd66e75efafe"),
                            Code = "cart-created",
                            IsActive = true,
                            Name = "Создан"
                        },
                        new
                        {
                            Id = new Guid("a801a3e9-72e2-4ac6-b3ec-79890492c1cf"),
                            Code = "cart-active",
                            IsActive = true,
                            Name = "Активный"
                        },
                        new
                        {
                            Id = new Guid("cb57360a-7021-4042-a971-abdafa48c28b"),
                            Code = "cart-inactive",
                            IsActive = false,
                            Name = "Неактивный"
                        });
                });

            modelBuilder.Entity("TajMaster.Domain.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("TajMaster.Domain.Entities.CategoryService", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ServiceId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ServiceId");

                    b.ToTable("CategoryServices");
                });

            modelBuilder.Entity("TajMaster.Domain.Entities.Craftsman", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<int>("Experience")
                        .HasColumnType("integer");

                    b.Property<bool>("IsAvialable")
                        .HasColumnType("boolean");

                    b.Property<string>("ProfilePicture")
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<bool>("ProfileVerified")
                        .HasColumnType("boolean");

                    b.Property<int>("Rating")
                        .HasColumnType("integer");

                    b.Property<Guid>("SpecializationId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("SpecializationId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Craftsmen");
                });

            modelBuilder.Entity("TajMaster.Domain.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<DateTime>("AppointmentDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CraftsmanId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("OrderStatusId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("TotalPrice")
                        .HasPrecision(14, 2)
                        .HasColumnType("numeric(14,2)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CraftsmanId");

                    b.HasIndex("OrderStatusId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("TajMaster.Domain.Entities.OrderItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Price")
                        .HasPrecision(14, 2)
                        .HasColumnType("numeric(14,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<Guid>("ServiceId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ServiceId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("TajMaster.Domain.Entities.OrderStatus", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("OrderStatuses");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e5b50c69-b4d4-4c48-85a1-65a8e77f6459"),
                            Code = "order-pending",
                            IsActive = true,
                            Name = "В ожидании"
                        },
                        new
                        {
                            Id = new Guid("95b331c6-c258-4d1c-8eb3-431f34845f2b"),
                            Code = "order-accepted",
                            IsActive = true,
                            Name = "Принято"
                        },
                        new
                        {
                            Id = new Guid("29d3b5ac-308f-4b9f-88cc-f50e85ebd62f"),
                            Code = "order-shipped",
                            IsActive = true,
                            Name = "Отправлен"
                        },
                        new
                        {
                            Id = new Guid("82b4051c-24b8-4a4e-9c75-5b892556d5a7"),
                            Code = "order-cancelled",
                            IsActive = false,
                            Name = "Отменён"
                        },
                        new
                        {
                            Id = new Guid("34f87352-d87d-41f5-bc7c-7dbf7fcff805"),
                            Code = "order-completed",
                            IsActive = true,
                            Name = "Завершён"
                        },
                        new
                        {
                            Id = new Guid("d7a6c7a2-f742-4f6c-ae3d-0eb6f8f372ec"),
                            Code = "order-in-progress",
                            IsActive = true,
                            Name = "В процессе"
                        });
                });

            modelBuilder.Entity("TajMaster.Domain.Entities.Review", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Comment")
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)");

                    b.Property<Guid>("CraftsmanId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uuid");

                    b.Property<int>("Rating")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ReviewDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CraftsmanId");

                    b.HasIndex("OrderId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("TajMaster.Domain.Entities.Service", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("BasePrice")
                        .HasPrecision(14, 2)
                        .HasColumnType("numeric(14,2)");

                    b.Property<Guid>("CraftsmanId")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.HasIndex("CraftsmanId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("TajMaster.Domain.Entities.Specialization", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Specializations");
                });

            modelBuilder.Entity("TajMaster.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Phone")
                        .HasMaxLength(9)
                        .HasColumnType("character varying(9)");

                    b.Property<DateTime>("RegisteredDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserRoleId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("UserRoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TajMaster.Domain.Enumerations.UserRoleEnum", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("UserRoleEnum");
                });

            modelBuilder.Entity("TajMaster.Domain.Entities.Cart", b =>
                {
                    b.HasOne("TajMaster.Domain.Entities.CartStatus", "CartStatus")
                        .WithMany("Carts")
                        .HasForeignKey("CartStatusId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TajMaster.Domain.Entities.User", "User")
                        .WithOne("Cart")
                        .HasForeignKey("TajMaster.Domain.Entities.Cart", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CartStatus");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TajMaster.Domain.Entities.CartItem", b =>
                {
                    b.HasOne("TajMaster.Domain.Entities.Cart", "Cart")
                        .WithMany("CartItems")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TajMaster.Domain.Entities.Service", "Service")
                        .WithMany("CartItems")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("TajMaster.Domain.Entities.CategoryService", b =>
                {
                    b.HasOne("TajMaster.Domain.Entities.Category", "Category")
                        .WithMany("CategoryServices")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TajMaster.Domain.Entities.Service", "Service")
                        .WithMany("CategoryServices")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("TajMaster.Domain.Entities.Craftsman", b =>
                {
                    b.HasOne("TajMaster.Domain.Entities.Specialization", "Specialization")
                        .WithMany("Craftsmen")
                        .HasForeignKey("SpecializationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TajMaster.Domain.Entities.User", "User")
                        .WithOne("Craftsman")
                        .HasForeignKey("TajMaster.Domain.Entities.Craftsman", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Specialization");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TajMaster.Domain.Entities.Order", b =>
                {
                    b.HasOne("TajMaster.Domain.Entities.Craftsman", "Craftsman")
                        .WithMany("Orders")
                        .HasForeignKey("CraftsmanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TajMaster.Domain.Entities.OrderStatus", "OrderStatus")
                        .WithMany("Orders")
                        .HasForeignKey("OrderStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TajMaster.Domain.Entities.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Craftsman");

                    b.Navigation("OrderStatus");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TajMaster.Domain.Entities.OrderItem", b =>
                {
                    b.HasOne("TajMaster.Domain.Entities.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TajMaster.Domain.Entities.Service", "Service")
                        .WithMany("OrderItems")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("TajMaster.Domain.Entities.Review", b =>
                {
                    b.HasOne("TajMaster.Domain.Entities.Craftsman", "Craftsman")
                        .WithMany("Reviews")
                        .HasForeignKey("CraftsmanId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TajMaster.Domain.Entities.Order", "Order")
                        .WithMany("Reviews")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TajMaster.Domain.Entities.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Craftsman");

                    b.Navigation("Order");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TajMaster.Domain.Entities.Service", b =>
                {
                    b.HasOne("TajMaster.Domain.Entities.Craftsman", "Craftsman")
                        .WithMany("Services")
                        .HasForeignKey("CraftsmanId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Craftsman");
                });

            modelBuilder.Entity("TajMaster.Domain.Entities.User", b =>
                {
                    b.HasOne("TajMaster.Domain.Enumerations.UserRoleEnum", "UserRole")
                        .WithMany()
                        .HasForeignKey("UserRoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("TajMaster.Domain.Entities.Cart", b =>
                {
                    b.Navigation("CartItems");
                });

            modelBuilder.Entity("TajMaster.Domain.Entities.CartStatus", b =>
                {
                    b.Navigation("Carts");
                });

            modelBuilder.Entity("TajMaster.Domain.Entities.Category", b =>
                {
                    b.Navigation("CategoryServices");
                });

            modelBuilder.Entity("TajMaster.Domain.Entities.Craftsman", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Reviews");

                    b.Navigation("Services");
                });

            modelBuilder.Entity("TajMaster.Domain.Entities.Order", b =>
                {
                    b.Navigation("OrderItems");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("TajMaster.Domain.Entities.OrderStatus", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("TajMaster.Domain.Entities.Service", b =>
                {
                    b.Navigation("CartItems");

                    b.Navigation("CategoryServices");

                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("TajMaster.Domain.Entities.Specialization", b =>
                {
                    b.Navigation("Craftsmen");
                });

            modelBuilder.Entity("TajMaster.Domain.Entities.User", b =>
                {
                    b.Navigation("Cart")
                        .IsRequired();

                    b.Navigation("Craftsman")
                        .IsRequired();

                    b.Navigation("Orders");

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
