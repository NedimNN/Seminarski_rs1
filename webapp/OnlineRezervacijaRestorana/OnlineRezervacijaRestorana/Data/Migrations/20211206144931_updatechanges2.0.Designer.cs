﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Online_Rezervacija_Restorana.Data;

namespace Online_Rezervacija_Restorana.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211206144931_updatechanges2.0")]
    partial class updatechanges20
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Online_Rezervacija_Restorana.Models.Category", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Online_Rezervacija_Restorana.Models.City", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CountryID")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CountryID");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            ID = 1L,
                            CountryID = 1L,
                            Name = "Sarajevo"
                        },
                        new
                        {
                            ID = 2L,
                            CountryID = 1L,
                            Name = "Mostar"
                        });
                });

            modelBuilder.Entity("Online_Rezervacija_Restorana.Models.Country", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            ID = 1L,
                            Name = "Bosna i Hercegovina"
                        });
                });

            modelBuilder.Entity("Online_Rezervacija_Restorana.Models.Coupon", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Percentage")
                        .HasColumnType("int");

                    b.Property<int>("RestaurantID")
                        .HasColumnType("int");

                    b.Property<long?>("RestaurantID1")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("ValidUntil")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("RestaurantID1");

                    b.ToTable("Coupons");
                });

            modelBuilder.Entity("Online_Rezervacija_Restorana.Models.Image", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RestaurantID")
                        .HasColumnType("int");

                    b.Property<long?>("RestaurantID1")
                        .HasColumnType("bigint");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("RestaurantID1");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("Online_Rezervacija_Restorana.Models.Log", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("UserID")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("time")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("Online_Rezervacija_Restorana.Models.Meal", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MealTypeID")
                        .HasColumnType("int");

                    b.Property<long?>("MealTypeID1")
                        .HasColumnType("bigint");

                    b.Property<int>("MenuID")
                        .HasColumnType("int");

                    b.Property<long?>("MenuID1")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("OrderDetailID")
                        .HasColumnType("bigint");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasKey("ID");

                    b.HasIndex("MealTypeID1");

                    b.HasIndex("MenuID1");

                    b.HasIndex("OrderDetailID");

                    b.ToTable("Meals");
                });

            modelBuilder.Entity("Online_Rezervacija_Restorana.Models.MealType", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("MealTypes");
                });

            modelBuilder.Entity("Online_Rezervacija_Restorana.Models.Menu", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("Online_Rezervacija_Restorana.Models.Notification", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("CouponID")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("RestaurantID")
                        .HasColumnType("bigint");

                    b.Property<long>("UserID")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("CouponID");

                    b.HasIndex("RestaurantID");

                    b.HasIndex("UserID");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("Online_Rezervacija_Restorana.Models.Order", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ReservationID")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("ReservationID")
                        .IsUnique();

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Online_Rezervacija_Restorana.Models.OrderDetail", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Allergies")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("OrderID")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("OrderID");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("Online_Rezervacija_Restorana.Models.PaymentDetail", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CCV")
                        .HasColumnType("int");

                    b.Property<string>("Ccnumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("PaymentTypeID")
                        .HasColumnType("bigint");

                    b.Property<long>("UserID")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("PaymentTypeID");

                    b.HasIndex("UserID");

                    b.ToTable("PaymentDetails");
                });

            modelBuilder.Entity("Online_Rezervacija_Restorana.Models.PaymentType", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("PaymentTypes");
                });

            modelBuilder.Entity("Online_Rezervacija_Restorana.Models.Rating", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Mark")
                        .HasColumnType("int");

                    b.Property<long>("RestaurantID")
                        .HasColumnType("bigint");

                    b.Property<long>("UserID")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("RestaurantID");

                    b.HasIndex("UserID");

                    b.ToTable("Ratings");

                    b.HasData(
                        new
                        {
                            ID = 1L,
                            Comment = "Good food, nice place...",
                            InsertTime = new DateTime(2005, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Mark = 3,
                            RestaurantID = 1L,
                            UserID = 1L
                        });
                });

            modelBuilder.Entity("Online_Rezervacija_Restorana.Models.Request", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("UserID")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("Online_Rezervacija_Restorana.Models.Reservation", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("GuestNumber")
                        .HasColumnType("int");

                    b.Property<bool>("IsTemporary")
                        .HasColumnType("bit");

                    b.Property<bool>("NotifiedReminder")
                        .HasColumnType("bit");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecialRequest")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<long>("TableID")
                        .HasColumnType("bigint");

                    b.Property<long>("UserID")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("TableID");

                    b.HasIndex("UserID");

                    b.ToTable("Reservations");

                    b.HasData(
                        new
                        {
                            ID = 1L,
                            CreatedOn = new DateTime(2021, 12, 6, 14, 49, 30, 493, DateTimeKind.Local).AddTicks(4441),
                            Email = "ridvan_appa@hotmail.com",
                            EndTime = new DateTime(2005, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GuestNumber = 5,
                            IsTemporary = false,
                            NotifiedReminder = true,
                            Number = "38761641709",
                            SpecialRequest = "I want plates...",
                            StartTime = new DateTime(2005, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TableID = 1L,
                            UserID = 1L
                        });
                });

            modelBuilder.Entity("Online_Rezervacija_Restorana.Models.Restaurant", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CityId")
                        .HasColumnType("bigint");

                    b.Property<string>("City_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("Latitude")
                        .HasColumnType("real");

                    b.Property<float?>("Longitude")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PriceRange")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CityId");

                    b.ToTable("Restaurants");

                    b.HasData(
                        new
                        {
                            ID = 1L,
                            CityId = 1L,
                            City_name = "Sarajevo",
                            Description = "Description...",
                            Name = "Restoran",
                            PriceRange = 0
                        },
                        new
                        {
                            ID = 2L,
                            CityId = 2L,
                            City_name = "Mostar",
                            Description = "Odlican restoran malo skup...",
                            Name = "Prestige",
                            PriceRange = 2
                        },
                        new
                        {
                            ID = 3L,
                            CityId = 2L,
                            City_name = "Mostar",
                            Description = "Na samom ulasku u Stari Grad...",
                            Name = "Emen",
                            PriceRange = 1
                        },
                        new
                        {
                            ID = 4L,
                            CityId = 2L,
                            City_name = "Mostar",
                            Description = "Hrana odlicna prikladna cijeni...",
                            Name = "Megi",
                            PriceRange = 1
                        },
                        new
                        {
                            ID = 5L,
                            CityId = 1L,
                            City_name = "Sarajevo",
                            Description = "Restoran je odlican i u centru...",
                            Name = "Metropolis",
                            PriceRange = 1
                        },
                        new
                        {
                            ID = 6L,
                            CityId = 1L,
                            City_name = "Sarajevo",
                            Description = "Ako volite azijsku kuhinju...",
                            Name = "Kimono",
                            PriceRange = 2
                        });
                });

            modelBuilder.Entity("Online_Rezervacija_Restorana.Models.Table", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("RestaurantId")
                        .HasColumnType("bigint");

                    b.Property<int>("SittingPlaces")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Tables");

                    b.HasData(
                        new
                        {
                            ID = 1L,
                            RestaurantId = 1L,
                            SittingPlaces = 5
                        });
                });

            modelBuilder.Entity("Online_Rezervacija_Restorana.Models.User", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserRoleID")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("UserRoleID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            ID = 1L,
                            Email = "ridvan_appa@hotmail.com",
                            Password = "123",
                            UserRoleID = 1L
                        },
                        new
                        {
                            ID = 2L,
                            Email = "nedim_nurkovic@fit.ba",
                            Password = "123",
                            UserRoleID = 2L
                        },
                        new
                        {
                            ID = 3L,
                            Email = "emrah_djulan@fit.ba",
                            Password = "123",
                            UserRoleID = 3L
                        },
                        new
                        {
                            ID = 4L,
                            Email = "bob_maril@wow.ba",
                            Password = "123",
                            UserRoleID = 2L
                        });
                });

            modelBuilder.Entity("Online_Rezervacija_Restorana.Models.UserData", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserID")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("UserID")
                        .IsUnique();

                    b.ToTable("UserData");

                    b.HasData(
                        new
                        {
                            ID = 1L,
                            FirstName = "Ridvan",
                            LastName = "Appa",
                            PhoneNumber = "061641709",
                            UserID = 1L
                        },
                        new
                        {
                            ID = 2L,
                            FirstName = "Nedim",
                            LastName = "Nurkovic",
                            PhoneNumber = "061641709",
                            UserID = 2L
                        },
                        new
                        {
                            ID = 3L,
                            FirstName = "Emrah",
                            LastName = "Djulan",
                            PhoneNumber = "061641709",
                            UserID = 3L
                        },
                        new
                        {
                            ID = 4L,
                            FirstName = "Bob",
                            LastName = "Maril",
                            PhoneNumber = "061641709",
                            UserID = 4L
                        });
                });

            modelBuilder.Entity("Online_Rezervacija_Restorana.Models.UserFollowing", b =>
                {
                    b.Property<long>("UserID")
                        .HasColumnType("bigint");

                    b.Property<long>("RestaurantID")
                        .HasColumnType("bigint");

                    b.HasKey("UserID", "RestaurantID");

                    b.HasAlternateKey("RestaurantID", "UserID");

                    b.ToTable("UserFollowings");
                });

            modelBuilder.Entity("Online_Rezervacija_Restorana.Models.UserRole", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            ID = 1L,
                            Role = 0
                        },
                        new
                        {
                            ID = 2L,
                            Role = 1
                        },
                        new
                        {
                            ID = 3L,
                            Role = 2
                        });
                });

            modelBuilder.Entity("Online_Rezervacija_Restorana.Models.City", b =>
                {
                    b.HasOne("Online_Rezervacija_Restorana.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Online_Rezervacija_Restorana.Models.Coupon", b =>
                {
                    b.HasOne("Online_Rezervacija_Restorana.Models.Restaurant", "Restaurant")
                        .WithMany()
                        .HasForeignKey("RestaurantID1");
                });

            modelBuilder.Entity("Online_Rezervacija_Restorana.Models.Image", b =>
                {
                    b.HasOne("Online_Rezervacija_Restorana.Models.Restaurant", "Restaurant")
                        .WithMany()
                        .HasForeignKey("RestaurantID1");
                });

            modelBuilder.Entity("Online_Rezervacija_Restorana.Models.Meal", b =>
                {
                    b.HasOne("Online_Rezervacija_Restorana.Models.MealType", "MealType")
                        .WithMany()
                        .HasForeignKey("MealTypeID1");

                    b.HasOne("Online_Rezervacija_Restorana.Models.Menu", "Menu")
                        .WithMany("Meals")
                        .HasForeignKey("MenuID1");

                    b.HasOne("Online_Rezervacija_Restorana.Models.OrderDetail", null)
                        .WithMany("Meals")
                        .HasForeignKey("OrderDetailID");
                });

            modelBuilder.Entity("Online_Rezervacija_Restorana.Models.Notification", b =>
                {
                    b.HasOne("Online_Rezervacija_Restorana.Models.Coupon", "Coupon")
                        .WithMany()
                        .HasForeignKey("CouponID");

                    b.HasOne("Online_Rezervacija_Restorana.Models.Restaurant", "Restaurant")
                        .WithMany()
                        .HasForeignKey("RestaurantID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Online_Rezervacija_Restorana.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Online_Rezervacija_Restorana.Models.Order", b =>
                {
                    b.HasOne("Online_Rezervacija_Restorana.Models.Reservation", "Reservation")
                        .WithOne("Order")
                        .HasForeignKey("Online_Rezervacija_Restorana.Models.Order", "ReservationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Online_Rezervacija_Restorana.Models.OrderDetail", b =>
                {
                    b.HasOne("Online_Rezervacija_Restorana.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Online_Rezervacija_Restorana.Models.PaymentDetail", b =>
                {
                    b.HasOne("Online_Rezervacija_Restorana.Models.PaymentType", "PaymentType")
                        .WithMany()
                        .HasForeignKey("PaymentTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Online_Rezervacija_Restorana.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Online_Rezervacija_Restorana.Models.Rating", b =>
                {
                    b.HasOne("Online_Rezervacija_Restorana.Models.Restaurant", "Restaurant")
                        .WithMany("Ratings")
                        .HasForeignKey("RestaurantID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Online_Rezervacija_Restorana.Models.User", "User")
                        .WithMany("Ratings")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Online_Rezervacija_Restorana.Models.Request", b =>
                {
                    b.HasOne("Online_Rezervacija_Restorana.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Online_Rezervacija_Restorana.Models.Reservation", b =>
                {
                    b.HasOne("Online_Rezervacija_Restorana.Models.Table", "Table")
                        .WithMany("Reservations")
                        .HasForeignKey("TableID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Online_Rezervacija_Restorana.Models.User", "User")
                        .WithMany("Reservations")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Online_Rezervacija_Restorana.Models.Restaurant", b =>
                {
                    b.HasOne("Online_Rezervacija_Restorana.Models.City", null)
                        .WithMany("Restaurants")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Online_Rezervacija_Restorana.Models.Table", b =>
                {
                    b.HasOne("Online_Rezervacija_Restorana.Models.Restaurant", "Restaurant")
                        .WithMany("Tables")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Online_Rezervacija_Restorana.Models.User", b =>
                {
                    b.HasOne("Online_Rezervacija_Restorana.Models.UserRole", "UserRole")
                        .WithMany()
                        .HasForeignKey("UserRoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Online_Rezervacija_Restorana.Models.UserData", b =>
                {
                    b.HasOne("Online_Rezervacija_Restorana.Models.User", "User")
                        .WithOne("UserData")
                        .HasForeignKey("Online_Rezervacija_Restorana.Models.UserData", "UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Online_Rezervacija_Restorana.Models.UserFollowing", b =>
                {
                    b.HasOne("Online_Rezervacija_Restorana.Models.Restaurant", "Restaurant")
                        .WithMany()
                        .HasForeignKey("RestaurantID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Online_Rezervacija_Restorana.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
