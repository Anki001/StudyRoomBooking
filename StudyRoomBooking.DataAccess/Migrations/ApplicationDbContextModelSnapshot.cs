﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudyRoomBooking.DataAccess;

#nullable disable

namespace StudyRoomBooking.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("StudyRoomBooking.Models.StudyRoom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("RoomNumber")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("StudyRooms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsAvailable = true,
                            Name = "Earth",
                            RoomNumber = "A101"
                        },
                        new
                        {
                            Id = 2,
                            IsAvailable = true,
                            Name = "Neptune",
                            RoomNumber = "A102"
                        },
                        new
                        {
                            Id = 3,
                            IsAvailable = true,
                            Name = "Mercury",
                            RoomNumber = "A103"
                        },
                        new
                        {
                            Id = 4,
                            IsAvailable = true,
                            Name = "Saturn",
                            RoomNumber = "A201"
                        },
                        new
                        {
                            Id = 5,
                            IsAvailable = true,
                            Name = "Uranus",
                            RoomNumber = "A202"
                        },
                        new
                        {
                            Id = 6,
                            IsAvailable = true,
                            Name = "Mars",
                            RoomNumber = "A203"
                        },
                        new
                        {
                            Id = 7,
                            IsAvailable = true,
                            Name = "Venus",
                            RoomNumber = "A301"
                        },
                        new
                        {
                            Id = 8,
                            IsAvailable = true,
                            Name = "Jupiter",
                            RoomNumber = "A302"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
