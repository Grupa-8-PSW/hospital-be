﻿// <auto-generated />
using System;
using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HospitalLibrary.Migrations
{
    [DbContext(typeof(HospitalDbContext))]
    partial class HospitalDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FloorRoom", b =>
                {
                    b.Property<int>("FloorsId")
                        .HasColumnType("integer");

                    b.Property<int>("RoomsId")
                        .HasColumnType("integer");

                    b.HasKey("FloorsId", "RoomsId");

                    b.HasIndex("RoomsId");

                    b.ToTable("FloorRoom");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Model.Feedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("CreationDate")
                        .HasColumnType("date");

                    b.Property<bool>("IsAnonymous")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("boolean");

                    b.Property<int>("PatientId")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("Feedbacks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreationDate = new DateOnly(2022, 10, 24),
                            IsAnonymous = true,
                            IsPublic = true,
                            PatientId = 1,
                            Status = 0,
                            Text = "Bolnica je dobra"
                        },
                        new
                        {
                            Id = 2,
                            CreationDate = new DateOnly(2022, 10, 24),
                            IsAnonymous = false,
                            IsPublic = true,
                            PatientId = 2,
                            Status = 0,
                            Text = "Bolnica je losa"
                        },
                        new
                        {
                            Id = 3,
                            CreationDate = new DateOnly(2022, 10, 24),
                            IsAnonymous = false,
                            IsPublic = true,
                            PatientId = 3,
                            Status = 1,
                            Text = "Bolnica je odlicna"
                        },
                        new
                        {
                            Id = 4,
                            CreationDate = new DateOnly(2022, 10, 24),
                            IsAnonymous = true,
                            IsPublic = true,
                            PatientId = 4,
                            Status = 0,
                            Text = "Bolnica je solidna"
                        });
                });

            modelBuilder.Entity("HospitalLibrary.Core.Model.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Patients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Pera",
                            LastName = "Peric"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Marko",
                            LastName = "Markovic"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Dusan",
                            LastName = "Baljinac"
                        },
                        new
                        {
                            Id = 4,
                            FirstName = "Slobodan",
                            LastName = "Radulovic"
                        });
                });

            modelBuilder.Entity("HospitalLibrary.GraphicalEditor.Model.Building", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Height")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Width")
                        .HasColumnType("integer");

                    b.Property<int>("X")
                        .HasColumnType("integer");

                    b.Property<int>("Y")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Buildings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Color = "gray",
                            Height = 150,
                            Name = "One",
                            Width = 450,
                            X = 100,
                            Y = 100
                        },
                        new
                        {
                            Id = 2,
                            Color = "gray",
                            Height = 450,
                            Name = "Too",
                            Width = 150,
                            X = 600,
                            Y = 100
                        },
                        new
                        {
                            Id = 3,
                            Color = "gray",
                            Height = 130,
                            Name = "Tre",
                            Width = 400,
                            X = 400,
                            Y = 600
                        });
                });

            modelBuilder.Entity("HospitalLibrary.GraphicalEditor.Model.Floor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BuildingId")
                        .HasColumnType("integer");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Height")
                        .HasColumnType("integer");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Width")
                        .HasColumnType("integer");

                    b.Property<int>("X")
                        .HasColumnType("integer");

                    b.Property<int>("Y")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BuildingId");

                    b.ToTable("Floors");

                    b.HasData(
                        new
                        {
                            Id = 3,
                            BuildingId = 1,
                            Color = "white",
                            Height = 100,
                            Number = "Floor 3",
                            Width = 300,
                            X = 100,
                            Y = 70
                        },
                        new
                        {
                            Id = 2,
                            BuildingId = 1,
                            Color = "white",
                            Height = 100,
                            Number = "Floor 2",
                            Width = 300,
                            X = 100,
                            Y = 170
                        },
                        new
                        {
                            Id = 1,
                            BuildingId = 1,
                            Color = "white",
                            Height = 100,
                            Number = "Floor 1",
                            Width = 300,
                            X = 100,
                            Y = 270
                        },
                        new
                        {
                            Id = 5,
                            BuildingId = 2,
                            Color = "white",
                            Height = 100,
                            Number = "Floor 2",
                            Width = 300,
                            X = 100,
                            Y = 170
                        },
                        new
                        {
                            Id = 4,
                            BuildingId = 2,
                            Color = "white",
                            Height = 100,
                            Number = "Floor 1",
                            Width = 300,
                            X = 100,
                            Y = 270
                        },
                        new
                        {
                            Id = 8,
                            BuildingId = 3,
                            Color = "white",
                            Height = 100,
                            Number = "Floor 3",
                            Width = 300,
                            X = 100,
                            Y = 70
                        },
                        new
                        {
                            Id = 7,
                            BuildingId = 3,
                            Color = "white",
                            Height = 100,
                            Number = "Floor 2",
                            Width = 300,
                            X = 100,
                            Y = 170
                        },
                        new
                        {
                            Id = 6,
                            BuildingId = 3,
                            Color = "white",
                            Height = 100,
                            Number = "Floor 1",
                            Width = 300,
                            X = 100,
                            Y = 270
                        });
                });

            modelBuilder.Entity("HospitalLibrary.GraphicalEditor.Model.Form", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("EndHourSaturday")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("EndHourSunday")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("EndHourWorkDay")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RoomId")
                        .HasColumnType("integer");

                    b.Property<string>("StartHourSaturday")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("StartHourSunday")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("StartHourWorkDay")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Forms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Pregledi za decu",
                            EndHourSaturday = "17:00h",
                            EndHourSunday = "CLOSED",
                            EndHourWorkDay = "17:00h",
                            Name = "101,Pedijatrija",
                            RoomId = 1,
                            StartHourSaturday = "12:00h",
                            StartHourSunday = "CLOSED",
                            StartHourWorkDay = "10:00h"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Opustanje za radnike i posetioce",
                            EndHourSaturday = "17:00h",
                            EndHourSunday = "CLOSED",
                            EndHourWorkDay = "17:00h",
                            Name = "102,Kafeterija",
                            RoomId = 2,
                            StartHourSaturday = "12:00h",
                            StartHourSunday = "CLOSED",
                            StartHourWorkDay = "10:00h"
                        },
                        new
                        {
                            Id = 3,
                            Description = "UHO,GRLO,NOS",
                            EndHourSaturday = "17:00h",
                            EndHourSunday = "CLOSED",
                            EndHourWorkDay = "17:00h",
                            Name = "103,Otorinolaringologija",
                            RoomId = 3,
                            StartHourSaturday = "12:00h",
                            StartHourSunday = "CLOSED",
                            StartHourWorkDay = "10:00h"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Pregled misica i povreda",
                            EndHourSaturday = "17:00h",
                            EndHourSunday = "CLOSED",
                            EndHourWorkDay = "17:00h",
                            Name = "201,Fizioterapeut",
                            RoomId = 4,
                            StartHourSaturday = "12:00h",
                            StartHourSunday = "CLOSED",
                            StartHourWorkDay = "10:00h"
                        });
                });

            modelBuilder.Entity("HospitalLibrary.GraphicalEditor.Model.Map.MapBuilding", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BuildingId")
                        .HasColumnType("integer");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Height")
                        .HasColumnType("integer");

                    b.Property<int>("Width")
                        .HasColumnType("integer");

                    b.Property<int>("X")
                        .HasColumnType("integer");

                    b.Property<int>("Y")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BuildingId")
                        .IsUnique();

                    b.ToTable("MapBuildings");
                });

            modelBuilder.Entity("HospitalLibrary.GraphicalEditor.Model.Map.MapFloor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("FloorId")
                        .HasColumnType("integer");

                    b.Property<int>("Height")
                        .HasColumnType("integer");

                    b.Property<int>("Width")
                        .HasColumnType("integer");

                    b.Property<int>("X")
                        .HasColumnType("integer");

                    b.Property<int>("Y")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("FloorId")
                        .IsUnique();

                    b.ToTable("MapFloors");
                });

            modelBuilder.Entity("HospitalLibrary.GraphicalEditor.Model.Map.MapRoom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Height")
                        .HasColumnType("integer");

                    b.Property<int>("Width")
                        .HasColumnType("integer");

                    b.Property<int>("X")
                        .HasColumnType("integer");

                    b.Property<int>("Y")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("MapRoom");
                });

            modelBuilder.Entity("HospitalLibrary.GraphicalEditor.Model.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("FloorId")
                        .HasColumnType("integer");

                    b.Property<int>("Height")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Width")
                        .HasColumnType("integer");

                    b.Property<int>("X")
                        .HasColumnType("integer");

                    b.Property<int>("Y")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Color = "blue",
                            FloorId = 1,
                            Height = 160,
                            Name = "Pedijatrija",
                            Width = 260,
                            X = 0,
                            Y = 0
                        },
                        new
                        {
                            Id = 2,
                            Color = "blue",
                            FloorId = 1,
                            Height = 140,
                            Name = "Kafeterija",
                            Width = 220,
                            X = 0,
                            Y = 338
                        },
                        new
                        {
                            Id = 3,
                            Color = "blue",
                            FloorId = 1,
                            Height = 180,
                            Name = "Otorinolaringologija",
                            Width = 300,
                            X = 237,
                            Y = 0
                        },
                        new
                        {
                            Id = 4,
                            Color = "blue",
                            FloorId = 2,
                            Height = 100,
                            Name = "Fizioterapeut",
                            Width = 200,
                            X = 270,
                            Y = 378
                        },
                        new
                        {
                            Id = 5,
                            Color = "blue",
                            FloorId = 2,
                            Height = 180,
                            Name = "Stomatologija",
                            Width = 360,
                            X = 0,
                            Y = 0
                        },
                        new
                        {
                            Id = 6,
                            Color = "blue",
                            FloorId = 3,
                            Height = 180,
                            Name = "Magacin",
                            Width = 260,
                            X = 0,
                            Y = 0
                        },
                        new
                        {
                            Id = 7,
                            Color = "blue",
                            FloorId = 3,
                            Height = 140,
                            Name = "Opsta nega",
                            Width = 220,
                            X = 0,
                            Y = 338
                        },
                        new
                        {
                            Id = 8,
                            Color = "blue",
                            FloorId = 3,
                            Height = 140,
                            Name = "Cekaonica",
                            Width = 220,
                            X = 330,
                            Y = 158
                        },
                        new
                        {
                            Id = 9,
                            Color = "blue",
                            FloorId = 4,
                            Height = 170,
                            Name = "Kardiologija",
                            Width = 320,
                            X = 0,
                            Y = 0
                        },
                        new
                        {
                            Id = 10,
                            Color = "blue",
                            FloorId = 4,
                            Height = 140,
                            Name = "Vaskularne bolesti",
                            Width = 220,
                            X = 0,
                            Y = 365
                        },
                        new
                        {
                            Id = 11,
                            Color = "blue",
                            FloorId = 4,
                            Height = 140,
                            Name = "Hirurgija",
                            Width = 220,
                            X = 245,
                            Y = 0
                        },
                        new
                        {
                            Id = 12,
                            Color = "blue",
                            FloorId = 5,
                            Height = 140,
                            Name = "Papirologija",
                            Width = 220,
                            X = 0,
                            Y = 0
                        },
                        new
                        {
                            Id = 13,
                            Color = "blue",
                            FloorId = 5,
                            Height = 140,
                            Name = "Prijavna soba",
                            Width = 220,
                            X = 200,
                            Y = 0
                        },
                        new
                        {
                            Id = 14,
                            Color = "blue",
                            FloorId = 5,
                            Height = 140,
                            Name = "Uplasta/isplata",
                            Width = 220,
                            X = 0,
                            Y = 350
                        },
                        new
                        {
                            Id = 15,
                            Color = "blue",
                            FloorId = 5,
                            Height = 140,
                            Name = "Izgubljeno/nadjeno",
                            Width = 220,
                            X = 200,
                            Y = 350
                        },
                        new
                        {
                            Id = 16,
                            Color = "blue",
                            FloorId = 6,
                            Height = 190,
                            Name = "Onkologija",
                            Width = 320,
                            X = 0,
                            Y = 0
                        },
                        new
                        {
                            Id = 17,
                            Color = "blue",
                            FloorId = 6,
                            Height = 240,
                            Name = "Onkologija",
                            Width = 250,
                            X = 200,
                            Y = 300
                        },
                        new
                        {
                            Id = 18,
                            Color = "blue",
                            FloorId = 7,
                            Height = 280,
                            Name = "Gastronomija",
                            Width = 420,
                            X = 50,
                            Y = 100
                        },
                        new
                        {
                            Id = 19,
                            Color = "blue",
                            FloorId = 8,
                            Height = 170,
                            Name = "Magacin",
                            Width = 320,
                            X = 100,
                            Y = 138
                        });
                });

            modelBuilder.Entity("FloorRoom", b =>
                {
                    b.HasOne("HospitalLibrary.GraphicalEditor.Model.Floor", null)
                        .WithMany()
                        .HasForeignKey("FloorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalLibrary.GraphicalEditor.Model.Room", null)
                        .WithMany()
                        .HasForeignKey("RoomsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HospitalLibrary.Core.Model.Feedback", b =>
                {
                    b.HasOne("HospitalLibrary.Core.Model.Patient", "Patient")
                        .WithMany("Feedbacks")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("HospitalLibrary.GraphicalEditor.Model.Floor", b =>
                {
                    b.HasOne("HospitalLibrary.GraphicalEditor.Model.Building", "Building")
                        .WithMany("Floors")
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Building");
                });

            modelBuilder.Entity("HospitalLibrary.GraphicalEditor.Model.Map.MapBuilding", b =>
                {
                    b.HasOne("HospitalLibrary.GraphicalEditor.Model.Building", "Building")
                        .WithOne("Map")
                        .HasForeignKey("HospitalLibrary.GraphicalEditor.Model.Map.MapBuilding", "BuildingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Building");
                });

            modelBuilder.Entity("HospitalLibrary.GraphicalEditor.Model.Map.MapFloor", b =>
                {
                    b.HasOne("HospitalLibrary.GraphicalEditor.Model.Floor", "Floor")
                        .WithOne("Map")
                        .HasForeignKey("HospitalLibrary.GraphicalEditor.Model.Map.MapFloor", "FloorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Floor");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Model.Patient", b =>
                {
                    b.Navigation("Feedbacks");
                });

            modelBuilder.Entity("HospitalLibrary.GraphicalEditor.Model.Building", b =>
                {
                    b.Navigation("Floors");

                    b.Navigation("Map")
                        .IsRequired();
                });

            modelBuilder.Entity("HospitalLibrary.GraphicalEditor.Model.Floor", b =>
                {
                    b.Navigation("Map")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
