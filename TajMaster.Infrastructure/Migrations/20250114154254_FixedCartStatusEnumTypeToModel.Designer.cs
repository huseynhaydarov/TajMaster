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
    [Migration("20250114154254_FixedCartStatusEnumTypeToModel")]
    partial class FixedCartStatusEnumTypeToModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CategoryServices", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ServiceId")
                        .HasColumnType("uuid");

                    b.HasKey("CategoryId", "ServiceId");

                    b.HasIndex("ServiceId");

                    b.ToTable("CategoryServices");
                });

            modelBuilder.Entity("TajMaster.Domain.Entities.Cart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

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

            modelBuilder.Entity("TajMaster.Domain.Entities.CartStatusEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CartStatusId")
                        .HasColumnType("uuid");

                    b.Property<int>("Code")
                        .HasMaxLength(50)
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("CartStatuses");
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

                    b.Property<string>("Specialization")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

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

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("TotalPrice")
                        .HasPrecision(14, 2)
                        .HasColumnType("numeric(14,2)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CraftsmanId");

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

                    b.Property<string>("Roles")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CategoryServices", b =>
                {
                    b.HasOne("TajMaster.Domain.Entities.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TajMaster.Domain.Entities.Service", null)
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TajMaster.Domain.Entities.Cart", b =>
                {
                    b.HasOne("TajMaster.Domain.Entities.User", "User")
                        .WithOne("Cart")
                        .HasForeignKey("TajMaster.Domain.Entities.Cart", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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

            modelBuilder.Entity("TajMaster.Domain.Entities.CartStatusEntity", b =>
                {
                    b.HasOne("TajMaster.Domain.Entities.Cart", "Cart")
                        .WithMany("CartStatuses")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cart");
                });

            modelBuilder.Entity("TajMaster.Domain.Entities.Craftsman", b =>
                {
                    b.HasOne("TajMaster.Domain.Entities.User", "User")
                        .WithOne("Craftsman")
                        .HasForeignKey("TajMaster.Domain.Entities.Craftsman", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TajMaster.Domain.Entities.Order", b =>
                {
                    b.HasOne("TajMaster.Domain.Entities.Craftsman", "Craftsman")
                        .WithMany("Orders")
                        .HasForeignKey("CraftsmanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TajMaster.Domain.Entities.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Craftsman");

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

            modelBuilder.Entity("TajMaster.Domain.Entities.Cart", b =>
                {
                    b.Navigation("CartItems");

                    b.Navigation("CartStatuses");
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

            modelBuilder.Entity("TajMaster.Domain.Entities.Service", b =>
                {
                    b.Navigation("CartItems");

                    b.Navigation("OrderItems");
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
