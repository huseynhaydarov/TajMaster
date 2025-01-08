﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TajMaster.Infrastructure.Persistence.Data;

#nullable disable

namespace TajMaster.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CategoryServices", b =>
                {
                    b.Property<int>("CategoryId")
                        .HasColumnType("integer")
                        .HasColumnName("categoryid");

                    b.Property<int>("ServiceId")
                        .HasColumnType("integer")
                        .HasColumnName("serviceid");

                    b.HasKey("CategoryId", "ServiceId");

                    b.HasIndex("ServiceId");

                    b.ToTable("CategoryServices");
                });

            modelBuilder.Entity("TajMaster.Domain.Entities.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CartStatus")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("cartstatus");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("userid");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("TajMaster.Domain.Entities.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CartId")
                        .HasColumnType("integer")
                        .HasColumnName("cartid");

                    b.Property<decimal>("Price")
                        .HasPrecision(14, 2)
                        .HasColumnType("numeric(14,2)")
                        .HasColumnName("price");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer")
                        .HasColumnName("quantity");

                    b.Property<int>("ServiceId")
                        .HasColumnType("integer")
                        .HasColumnName("serviceid");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("ServiceId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("TajMaster.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("TajMaster.Domain.Entities.Craftsman", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("description");

                    b.Property<int>("Experience")
                        .HasColumnType("integer")
                        .HasColumnName("experience");

                    b.Property<bool>("IsAvialable")
                        .HasColumnType("boolean")
                        .HasColumnName("isavialable");

                    b.Property<string>("ProfilePicture")
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)")
                        .HasColumnName("profilepicture");

                    b.Property<bool>("ProfileVerified")
                        .HasColumnType("boolean")
                        .HasColumnName("profileverified");

                    b.Property<int>("Rating")
                        .HasColumnType("integer")
                        .HasColumnName("rating");

                    b.Property<string>("Specialization")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("specialization");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("userid");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Craftsmen");
                });

            modelBuilder.Entity("TajMaster.Domain.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)")
                        .HasColumnName("address");

                    b.Property<DateTime>("AppointmentDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("appointmentdate");

                    b.Property<int>("CraftsmanId")
                        .HasColumnType("integer")
                        .HasColumnName("craftsmanid");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("status");

                    b.Property<decimal>("TotalPrice")
                        .HasPrecision(14, 2)
                        .HasColumnType("numeric(14,2)")
                        .HasColumnName("totalprice");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("userid");

                    b.HasKey("Id");

                    b.HasIndex("CraftsmanId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("TajMaster.Domain.Entities.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("OrderId")
                        .HasColumnType("integer")
                        .HasColumnName("orderid");

                    b.Property<decimal>("Price")
                        .HasPrecision(14, 2)
                        .HasColumnType("numeric(14,2)")
                        .HasColumnName("price");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer")
                        .HasColumnName("quantity");

                    b.Property<int>("ServiceId")
                        .HasColumnType("integer")
                        .HasColumnName("serviceid");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ServiceId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("TajMaster.Domain.Entities.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)")
                        .HasColumnName("comment");

                    b.Property<int>("CraftsmanId")
                        .HasColumnType("integer")
                        .HasColumnName("craftsmanid");

                    b.Property<int>("OrderId")
                        .HasColumnType("integer")
                        .HasColumnName("orderid");

                    b.Property<int>("Rating")
                        .HasColumnType("integer")
                        .HasColumnName("rating");

                    b.Property<DateTime>("ReviewDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("reviewdate");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("userid");

                    b.HasKey("Id");

                    b.HasIndex("CraftsmanId");

                    b.HasIndex("OrderId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("TajMaster.Domain.Entities.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("BasePrice")
                        .HasPrecision(14, 2)
                        .HasColumnType("numeric(14,2)")
                        .HasColumnName("baseprice");

                    b.Property<int>("CraftsmanId")
                        .HasColumnType("integer")
                        .HasColumnName("craftsmanid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("description");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.HasIndex("CraftsmanId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("TajMaster.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("address");

                    b.Property<string>("Email")
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("fullname");

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("hashedpassword");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("isactive");

                    b.Property<string>("Phone")
                        .HasMaxLength(9)
                        .HasColumnType("character varying(9)")
                        .HasColumnName("phone");

                    b.Property<DateTime>("RegisteredDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("registereddate");

                    b.Property<string>("Roles")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("roles");

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
