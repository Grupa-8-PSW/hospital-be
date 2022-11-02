﻿// <auto-generated />
using System;
using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HospitalLibrary.Migrations
{
    [DbContext(typeof(HospitalDbContext))]
    [Migration("20221102095247_MapAddBuildingDataMigration")]
    partial class MapAddBuildingDataMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

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

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BuildingId");

                    b.ToTable("Floors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BuildingId = 1,
                            Number = "One"
                        },
                        new
                        {
                            Id = 2,
                            BuildingId = 1,
                            Number = "Too"
                        },
                        new
                        {
                            Id = 3,
                            BuildingId = 1,
                            Number = "Tre"
                        },
                        new
                        {
                            Id = 4,
                            BuildingId = 2,
                            Number = "Noo"
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

                    b.Property<int>("RoomId")
                        .HasColumnType("integer");

                    b.Property<int>("Width")
                        .HasColumnType("integer");

                    b.Property<int>("X")
                        .HasColumnType("integer");

                    b.Property<int>("Y")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RoomId")
                        .IsUnique();

                    b.ToTable("MapRooms");
                });

            modelBuilder.Entity("HospitalLibrary.GraphicalEditor.Model.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("FloorId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("FloorId");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FloorId = 1,
                            Name = "One",
                            Number = "101A"
                        },
                        new
                        {
                            Id = 2,
                            FloorId = 2,
                            Name = "Too",
                            Number = "204"
                        },
                        new
                        {
                            Id = 3,
                            FloorId = 3,
                            Name = "Tre",
                            Number = "305B"
                        });
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

            modelBuilder.Entity("HospitalLibrary.GraphicalEditor.Model.Map.MapRoom", b =>
                {
                    b.HasOne("HospitalLibrary.GraphicalEditor.Model.Room", "Room")
                        .WithOne("Map")
                        .HasForeignKey("HospitalLibrary.GraphicalEditor.Model.Map.MapRoom", "RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("HospitalLibrary.GraphicalEditor.Model.Room", b =>
                {
                    b.HasOne("HospitalLibrary.GraphicalEditor.Model.Floor", "Floor")
                        .WithMany("Rooms")
                        .HasForeignKey("FloorId")
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

                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("HospitalLibrary.GraphicalEditor.Model.Room", b =>
                {
                    b.Navigation("Map")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
