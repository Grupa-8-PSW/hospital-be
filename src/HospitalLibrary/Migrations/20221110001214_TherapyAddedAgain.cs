﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HospitalLibrary.Migrations
{
    public partial class TherapyAddedAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BloodUnitRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    AmountL = table.Column<int>(type: "integer", nullable: false),
                    Reason = table.Column<string>(type: "text", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodUnitRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    X = table.Column<int>(type: "integer", nullable: false),
                    Y = table.Column<int>(type: "integer", nullable: false),
                    Width = table.Column<int>(type: "integer", nullable: false),
                    Height = table.Column<int>(type: "integer", nullable: false),
                    Color = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    EquipmentId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<int>(type: "integer", nullable: false),
                    RoomId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.EquipmentId);
                });

            migrationBuilder.CreateTable(
                name: "Forms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    StartHourWorkDay = table.Column<string>(type: "text", nullable: false),
                    EndHourWorkDay = table.Column<string>(type: "text", nullable: false),
                    StartHourSaturday = table.Column<string>(type: "text", nullable: false),
                    EndHourSaturday = table.Column<string>(type: "text", nullable: false),
                    StartHourSunday = table.Column<string>(type: "text", nullable: false),
                    EndHourSunday = table.Column<string>(type: "text", nullable: false),
                    RoomId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ITherapySubject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    BloodType = table.Column<int>(type: "integer", nullable: true),
                    AmountMl = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ITherapySubject", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MapForms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    StartHourWorkDay = table.Column<string>(type: "text", nullable: false),
                    EndHourWorkDay = table.Column<string>(type: "text", nullable: false),
                    StartHourSaturday = table.Column<string>(type: "text", nullable: false),
                    EndHourSaturday = table.Column<string>(type: "text", nullable: false),
                    StartHourSunday = table.Column<string>(type: "text", nullable: false),
                    EndHourSunday = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MapForms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MapRooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    X = table.Column<int>(type: "integer", nullable: false),
                    Y = table.Column<int>(type: "integer", nullable: false),
                    Width = table.Column<int>(type: "integer", nullable: false),
                    Height = table.Column<int>(type: "integer", nullable: false),
                    Color = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MapRooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Pin = table.Column<string>(type: "text", nullable: false),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    BloodType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    X = table.Column<int>(type: "integer", nullable: false),
                    Y = table.Column<int>(type: "integer", nullable: false),
                    Width = table.Column<int>(type: "integer", nullable: false),
                    Height = table.Column<int>(type: "integer", nullable: false),
                    Color = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    FloorId = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Floors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    X = table.Column<int>(type: "integer", nullable: false),
                    Y = table.Column<int>(type: "integer", nullable: false),
                    Width = table.Column<int>(type: "integer", nullable: false),
                    Height = table.Column<int>(type: "integer", nullable: false),
                    Color = table.Column<string>(type: "text", nullable: false),
                    Number = table.Column<string>(type: "text", nullable: false),
                    BuildingId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Floors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Floors_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MapBuildings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    X = table.Column<int>(type: "integer", nullable: false),
                    Y = table.Column<int>(type: "integer", nullable: false),
                    Width = table.Column<int>(type: "integer", nullable: false),
                    Height = table.Column<int>(type: "integer", nullable: false),
                    Color = table.Column<string>(type: "text", nullable: false),
                    BuildingId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MapBuildings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MapBuildings_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientId = table.Column<int>(type: "integer", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false),
                    CreationDate = table.Column<DateOnly>(type: "date", nullable: false),
                    IsAnonymous = table.Column<bool>(type: "boolean", nullable: false),
                    IsPublic = table.Column<bool>(type: "boolean", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Beds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoomId = table.Column<int>(type: "integer", nullable: false),
                    Available = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Beds_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    RoomId = table.Column<int>(type: "integer", nullable: false),
                    StartWork = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndWork = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FloorRoom",
                columns: table => new
                {
                    FloorsId = table.Column<int>(type: "integer", nullable: false),
                    RoomsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FloorRoom", x => new { x.FloorsId, x.RoomsId });
                    table.ForeignKey(
                        name: "FK_FloorRoom_Floors_FloorsId",
                        column: x => x.FloorsId,
                        principalTable: "Floors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FloorRoom_Rooms_RoomsId",
                        column: x => x.RoomsId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MapFloors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    X = table.Column<int>(type: "integer", nullable: false),
                    Y = table.Column<int>(type: "integer", nullable: false),
                    Width = table.Column<int>(type: "integer", nullable: false),
                    Height = table.Column<int>(type: "integer", nullable: false),
                    Color = table.Column<string>(type: "text", nullable: false),
                    FloorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MapFloors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MapFloors_Floors_FloorId",
                        column: x => x.FloorId,
                        principalTable: "Floors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TreatmentHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    DischargeReason = table.Column<string>(type: "text", nullable: false),
                    PatientId = table.Column<int>(type: "integer", nullable: false),
                    BedId = table.Column<int>(type: "integer", nullable: false),
                    Reason = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TreatmentHistories_Beds_BedId",
                        column: x => x.BedId,
                        principalTable: "Beds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TreatmentHistories_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Examinations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DoctorId = table.Column<int>(type: "integer", nullable: false),
                    PatientId = table.Column<int>(type: "integer", nullable: false),
                    RoomId = table.Column<int>(type: "integer", nullable: false),
                    StartTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Examinations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Examinations_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Examinations_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Examinations_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Therapies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WhenPrescribed = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Amount = table.Column<int>(type: "integer", nullable: false),
                    Reason = table.Column<string>(type: "text", nullable: false),
                    PrescribedId = table.Column<int>(type: "integer", nullable: false),
                    DoctorId = table.Column<int>(type: "integer", nullable: false),
                    TreatmentHistoryId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Therapies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Therapies_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Therapies_ITherapySubject_PrescribedId",
                        column: x => x.PrescribedId,
                        principalTable: "ITherapySubject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Therapies_TreatmentHistories_TreatmentHistoryId",
                        column: x => x.TreatmentHistoryId,
                        principalTable: "TreatmentHistories",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Buildings",
                columns: new[] { "Id", "Color", "Height", "Name", "Width", "X", "Y" },
                values: new object[,]
                {
                    { 1, "gray", 150, "One", 450, 100, 100 },
                    { 2, "gray", 450, "Too", 150, 600, 100 },
                    { 3, "gray", 130, "Tre", 400, 400, 600 }
                });

            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "EquipmentId", "Amount", "Name", "RoomId" },
                values: new object[,]
                {
                    { 1, 2, "Krevet", 1 },
                    { 2, 2, "Stetoskop", 1 },
                    { 3, 4, "Stolica", 1 },
                    { 4, 20, "Stolica", 2 },
                    { 5, 2, "Aparat za kafu", 2 },
                    { 6, 4, "Fotelja", 2 },
                    { 7, 2, "Spric za ispiranje usiju", 3 },
                    { 8, 3, "Otoskop", 3 },
                    { 9, 2, "Stetoskop", 4 },
                    { 10, 3, "Bolnicki krevet", 4 },
                    { 11, 2, "Aparat za merenje pritiska", 4 },
                    { 12, 4, "Stolica", 5 },
                    { 13, 50, "Zavoji", 6 },
                    { 14, 24, "Spricevi", 6 },
                    { 15, 12, "Gips", 6 },
                    { 16, 200, "Flasteri", 6 },
                    { 17, 20, "Bolnicki krevet", 7 },
                    { 18, 20, "Infuzija", 7 },
                    { 19, 20, "Stolica", 8 },
                    { 20, 2, "Stetoskop", 9 },
                    { 21, 4, "Stolica", 10 },
                    { 22, 2, "Krevet", 11 },
                    { 23, 2, "Stetoskop", 12 },
                    { 24, 4, "Infuzija", 13 },
                    { 25, 1, "Fotelja", 13 },
                    { 26, 20, "Stolica", 13 }
                });

            migrationBuilder.InsertData(
                table: "Forms",
                columns: new[] { "Id", "Description", "EndHourSaturday", "EndHourSunday", "EndHourWorkDay", "Name", "RoomId", "StartHourSaturday", "StartHourSunday", "StartHourWorkDay" },
                values: new object[,]
                {
                    { 1, "Pregledi za decu", "17:00h", "CLOSED", "17:00h", "101,Pedijatrija", 1, "12:00h", "CLOSED", "10:00h" },
                    { 2, "Opustanje za radnike i posetioce", "17:00h", "CLOSED", "17:00h", "102,Kafeterija", 2, "12:00h", "CLOSED", "10:00h" },
                    { 3, "UHO,GRLO,NOS", "17:00h", "CLOSED", "17:00h", "103,Otorinolaringologija", 3, "12:00h", "CLOSED", "10:00h" },
                    { 4, "Pregled misica i povreda", "17:00h", "CLOSED", "17:00h", "201,Fizioterapeut", 4, "12:00h", "CLOSED", "10:00h" },
                    { 5, "Pregledi za decu", "17:00h", "CLOSED", "17:00h", "202,Stomatologija", 5, "12:00h", "CLOSED", "10:00h" },
                    { 6, "Stanje robe u objektu", "17:00h", "CLOSED", "17:00h", "301,Magacin", 6, "12:00h", "CLOSED", "10:00h" },
                    { 7, "Kreveti i sve potrebno za oporavku", "17:00h", "CLOSED", "17:00h", "302,Opsta nega", 7, "12:00h", "CLOSED", "10:00h" },
                    { 8, "Stolice i fotelje za cekanje", "17:00h", "CLOSED", "17:00h", "303,Cekaonica", 8, "12:00h", "CLOSED", "10:00h" },
                    { 9, "...", "17:00h", "CLOSED", "17:00h", "101a,Kardiologija", 9, "12:00h", "CLOSED", "10:00h" },
                    { 10, "...", "17:00h", "CLOSED", "17:00h", "102a,Vaskularne bolesti", 10, "12:00h", "CLOSED", "10:00h" },
                    { 11, "...,...,...", "17:00h", "CLOSED", "17:00h", "103a,Hirurgija", 11, "12:00h", "CLOSED", "10:00h" },
                    { 12, "... ... ... ...", "17:00h", "CLOSED", "17:00h", "201a,Papirologija", 12, "12:00h", "CLOSED", "10:00h" },
                    { 13, "...", "17:00h", "CLOSED", "17:00h", "202a,Prijavna soba", 13, "12:00h", "CLOSED", "10:00h" },
                    { 14, "...", "17:00h", "CLOSED", "17:00h", "203a,Uplasta/isplata", 14, "12:00h", "CLOSED", "10:00h" },
                    { 15, "...", "17:00h", "CLOSED", "17:00h", "204a,Izgubljeno/nadjeno", 15, "12:00h", "CLOSED", "10:00h" },
                    { 16, "...", "17:00h", "CLOSED", "17:00h", "101b,Onkologija", 16, "12:00h", "CLOSED", "10:00h" },
                    { 17, "...", "17:00h", "CLOSED", "17:00h", "102b,Pedijatrija", 17, "12:00h", "CLOSED", "10:00h" },
                    { 18, "...", "17:00h", "CLOSED", "17:00h", "201b,Gastronomija", 18, "12:00h", "CLOSED", "10:00h" },
                    { 19, "...", "17:00h", "CLOSED", "17:00h", "301b,Magacin", 19, "12:00h", "CLOSED", "10:00h" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "BloodType", "Email", "FirstName", "Gender", "LastName", "Pin" },
                values: new object[,]
                {
                    { 1, 0, "peraperic@gmail.com", "Pera", 0, "Peric", "2201000120492" },
                    { 2, 7, "markomarkovic@gmail.com", "Marko", 0, "Markovic", "1412995012451" },
                    { 3, 5, "dusanbaljinac@gmail.com", "Dusan", 0, "Baljinac", "2008004124293" },
                    { 4, 3, "slobodanradulovic@gmail.com", "Slobodan", 0, "Radulovic", "1111978020204" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Color", "FloorId", "Height", "Name", "Type", "Width", "X", "Y" },
                values: new object[,]
                {
                    { 1, "blue", 1, 160, "Pedijatrija", 0, 260, 0, 0 },
                    { 2, "blue", 1, 140, "Kafeterija", 0, 220, 0, 338 },
                    { 3, "blue", 1, 180, "Otorinolaringologija", 0, 300, 237, 0 },
                    { 4, "blue", 2, 100, "Fizioterapeut", 0, 200, 270, 378 },
                    { 5, "blue", 2, 180, "Stomatologija", 0, 360, 0, 0 },
                    { 6, "blue", 3, 180, "Magacin", 0, 260, 0, 0 },
                    { 7, "blue", 3, 140, "Opsta nega", 0, 220, 0, 338 },
                    { 8, "blue", 3, 140, "Cekaonica", 0, 220, 330, 158 },
                    { 9, "blue", 4, 170, "Kardiologija", 0, 320, 0, 0 },
                    { 10, "blue", 4, 140, "Vaskularne bolesti", 0, 220, 0, 365 },
                    { 11, "blue", 4, 140, "Hirurgija", 0, 220, 245, 0 },
                    { 12, "blue", 5, 140, "Papirologija", 0, 220, 0, 0 },
                    { 13, "blue", 5, 140, "Prijavna soba", 0, 220, 200, 0 },
                    { 14, "blue", 5, 140, "Uplasta/isplata", 0, 220, 0, 350 },
                    { 15, "blue", 5, 140, "Izgubljeno/nadjeno", 0, 220, 200, 350 },
                    { 16, "blue", 6, 190, "Onkologija", 0, 320, 0, 0 },
                    { 17, "blue", 6, 240, "Onkologija", 0, 250, 200, 300 },
                    { 18, "blue", 7, 280, "Gastronomija", 0, 420, 50, 100 },
                    { 19, "blue", 8, 170, "Magacin", 0, 320, 100, 138 }
                });

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "Id", "CreationDate", "IsAnonymous", "IsPublic", "PatientId", "Status", "Text" },
                values: new object[,]
                {
                    { 1, new DateOnly(2022, 10, 24), true, true, 1, 0, "Bolnica je dobra" },
                    { 2, new DateOnly(2022, 10, 24), false, true, 2, 0, "Bolnica je losa" },
                    { 3, new DateOnly(2022, 10, 24), false, true, 3, 1, "Bolnica je odlicna" },
                    { 4, new DateOnly(2022, 10, 24), true, true, 4, 0, "Bolnica je solidna" }
                });

            migrationBuilder.InsertData(
                table: "Floors",
                columns: new[] { "Id", "BuildingId", "Color", "Height", "Number", "Width", "X", "Y" },
                values: new object[,]
                {
                    { 1, 1, "white", 100, "Floor 1", 300, 100, 270 },
                    { 2, 1, "white", 100, "Floor 2", 300, 100, 170 },
                    { 3, 1, "white", 100, "Floor 3", 300, 100, 70 },
                    { 4, 2, "white", 100, "Floor 1", 300, 100, 270 },
                    { 5, 2, "white", 100, "Floor 2", 300, 100, 170 },
                    { 6, 3, "white", 100, "Floor 1", 300, 100, 270 },
                    { 7, 3, "white", 100, "Floor 2", 300, 100, 170 },
                    { 8, 3, "white", 100, "Floor 3", 300, 100, 70 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beds_RoomId",
                table: "Beds",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_RoomId",
                table: "Doctors",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Examinations_DoctorId",
                table: "Examinations",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Examinations_PatientId",
                table: "Examinations",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Examinations_RoomId",
                table: "Examinations",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_PatientId",
                table: "Feedbacks",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_FloorRoom_RoomsId",
                table: "FloorRoom",
                column: "RoomsId");

            migrationBuilder.CreateIndex(
                name: "IX_Floors_BuildingId",
                table: "Floors",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_MapBuildings_BuildingId",
                table: "MapBuildings",
                column: "BuildingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MapFloors_FloorId",
                table: "MapFloors",
                column: "FloorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Therapies_DoctorId",
                table: "Therapies",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Therapies_PrescribedId",
                table: "Therapies",
                column: "PrescribedId");

            migrationBuilder.CreateIndex(
                name: "IX_Therapies_TreatmentHistoryId",
                table: "Therapies",
                column: "TreatmentHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentHistories_BedId",
                table: "TreatmentHistories",
                column: "BedId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentHistories_PatientId",
                table: "TreatmentHistories",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BloodUnitRequests");

            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "Examinations");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "FloorRoom");

            migrationBuilder.DropTable(
                name: "Forms");

            migrationBuilder.DropTable(
                name: "MapBuildings");

            migrationBuilder.DropTable(
                name: "MapFloors");

            migrationBuilder.DropTable(
                name: "MapForms");

            migrationBuilder.DropTable(
                name: "MapRooms");

            migrationBuilder.DropTable(
                name: "Therapies");

            migrationBuilder.DropTable(
                name: "Floors");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "ITherapySubject");

            migrationBuilder.DropTable(
                name: "TreatmentHistories");

            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DropTable(
                name: "Beds");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
