using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HospitalLibrary.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Country = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    Street = table.Column<string>(type: "text", nullable: false),
                    Number = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Allergens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bloods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bloods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BloodUnits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DatePrescribed = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    BloodType = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodUnits", x => x.Id);
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
                name: "Consiliums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Subject = table.Column<string>(type: "text", nullable: false),
                    Interval_Start = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Interval_End = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consiliums", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentTransfers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Amount = table.Column<int>(type: "integer", nullable: false),
                    FromRoomId = table.Column<int>(type: "integer", nullable: false),
                    ToRoomId = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: false),
                    EquipmentName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentTransfers", x => x.Id);
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
                name: "MedicalDrugs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalDrugs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RenovationEventWrappers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AggregateId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Data = table.Column<object>(type: "json", nullable: false),
                    EventType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RenovationEventWrappers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Renovations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    RoomId = table.Column<int>(type: "integer", nullable: false),
                    Interval = table.Column<int>(type: "integer", nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: false),
                    Available = table.Column<int>(type: "integer", nullable: false),
                    Changes = table.Column<int>(type: "integer", nullable: false),
                    Schedule = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Renovations", x => x.Id);
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
                    Pin_Value = table.Column<string>(type: "text", nullable: false),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    BloodType = table.Column<int>(type: "integer", nullable: false),
                    AddressId = table.Column<int>(type: "integer", nullable: false),
                    SelectedDoctorId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "AllergenPatient",
                columns: table => new
                {
                    AllergensId = table.Column<int>(type: "integer", nullable: false),
                    PatientsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllergenPatient", x => new { x.AllergensId, x.PatientsId });
                    table.ForeignKey(
                        name: "FK_AllergenPatient_Allergens_AllergensId",
                        column: x => x.AllergensId,
                        principalTable: "Allergens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AllergenPatient_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentEventWrappers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AggregateId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientId = table.Column<int>(type: "integer", nullable: false),
                    Data = table.Column<object>(type: "json", nullable: false),
                    EventType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentEventWrappers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppointmentEventWrappers_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
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
                    Rating_Rating = table.Column<int>(type: "integer", nullable: false),
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
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Number = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    FloorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Floors_FloorId",
                        column: x => x.FloorId,
                        principalTable: "Floors",
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
                    Specialization = table.Column<int>(type: "integer", nullable: false),
                    RoomId = table.Column<int>(type: "integer", nullable: false),
                    WorkHour_Start = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    WorkHour_End = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
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
                name: "Equipments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<int>(type: "integer", nullable: false),
                    RoomId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipments_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MapRooms",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "integer", nullable: false),
                    X = table.Column<int>(type: "integer", nullable: false),
                    Y = table.Column<int>(type: "integer", nullable: false),
                    Width = table.Column<int>(type: "integer", nullable: false),
                    Height = table.Column<int>(type: "integer", nullable: false),
                    Color = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MapRooms", x => x.RoomId);
                    table.ForeignKey(
                        name: "FK_MapRooms_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TreatmentHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    DischargeReason = table.Column<string>(type: "text", nullable: false),
                    PatientId = table.Column<int>(type: "integer", nullable: false),
                    BedId = table.Column<int>(type: "integer", nullable: false),
                    RoomId = table.Column<int>(type: "integer", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_TreatmentHistories_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BloodUnitRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    AmountL = table.Column<int>(type: "integer", nullable: false),
                    Reason = table.Column<string>(type: "text", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DoctorId = table.Column<int>(type: "integer", nullable: false),
                    ManagerComment = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodUnitRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BloodUnitRequests_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConsiliumDoctor",
                columns: table => new
                {
                    ConsiliumsId = table.Column<int>(type: "integer", nullable: false),
                    DoctorsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsiliumDoctor", x => new { x.ConsiliumsId, x.DoctorsId });
                    table.ForeignKey(
                        name: "FK_ConsiliumDoctor_Consiliums_ConsiliumsId",
                        column: x => x.ConsiliumsId,
                        principalTable: "Consiliums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConsiliumDoctor_Doctors_DoctorsId",
                        column: x => x.DoctorsId,
                        principalTable: "Doctors",
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
                    DateRange_Start = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateRange_End = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
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
                    WhenPrescribed = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Amount = table.Column<int>(type: "integer", nullable: false),
                    Reason = table.Column<string>(type: "text", nullable: false),
                    TherapyType = table.Column<int>(type: "integer", nullable: false),
                    TherapySubject = table.Column<string>(type: "text", nullable: false),
                    DoctorId = table.Column<int>(type: "integer", nullable: false),
                    TreatmentHistoryId = table.Column<int>(type: "integer", nullable: false)
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
                        name: "FK_Therapies_TreatmentHistories_TreatmentHistoryId",
                        column: x => x.TreatmentHistoryId,
                        principalTable: "TreatmentHistories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExaminationsDone",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ExaminationId = table.Column<int>(type: "integer", nullable: false),
                    Record = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExaminationsDone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExaminationsDone_Examinations_ExaminationId",
                        column: x => x.ExaminationId,
                        principalTable: "Examinations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prescription",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ExaminationDoneId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prescription_ExaminationsDone_ExaminationDoneId",
                        column: x => x.ExaminationDoneId,
                        principalTable: "ExaminationsDone",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Symptoms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ExaminationDoneId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Symptoms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Symptoms_ExaminationsDone_ExaminationDoneId",
                        column: x => x.ExaminationDoneId,
                        principalTable: "ExaminationsDone",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PrescriptionItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MedicalDrugId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    PrescriptionId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescriptionItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrescriptionItem_MedicalDrugs_MedicalDrugId",
                        column: x => x.MedicalDrugId,
                        principalTable: "MedicalDrugs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrescriptionItem_Prescription_PrescriptionId",
                        column: x => x.PrescriptionId,
                        principalTable: "Prescription",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Country", "Number", "Street" },
                values: new object[,]
                {
                    { 1, "Novi Sad", "Srbija", "12", "Dunavska 29" },
                    { 2, "Beograd", "Srbija", "10", "Beogradska" },
                    { 3, "Sremska Mitrovica", "Srbija", "15", "Skolska" },
                    { 4, "Gradska", "Srbija", "25", "Njegoseva" }
                });

            migrationBuilder.InsertData(
                table: "Allergens",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Penicilin" },
                    { 2, "Sulfonamidi " },
                    { 3, "Salicilna kiselina" }
                });

            migrationBuilder.InsertData(
                table: "Bloods",
                columns: new[] { "Id", "Quantity", "Type" },
                values: new object[,]
                {
                    { 1, 100, 0 },
                    { 2, 100, 1 },
                    { 3, 100, 2 },
                    { 4, 100, 3 },
                    { 5, 100, 4 },
                    { 6, 100, 5 },
                    { 7, 100, 6 },
                    { 8, 100, 7 }
                });

            migrationBuilder.InsertData(
                table: "Buildings",
                columns: new[] { "Id", "Color", "Height", "Name", "Width", "X", "Y" },
                values: new object[,]
                {
                    { 1, "gray", 150, "A-Wing", 450, 100, 100 },
                    { 2, "gray", 450, "B-Wing", 150, 600, 100 },
                    { 3, "gray", 130, "Y-Wing", 400, 400, 600 }
                });

            migrationBuilder.InsertData(
                table: "Consiliums",
                columns: new[] { "Id", "Duration", "Subject", "Interval_End", "Interval_Start" },
                values: new object[,]
                {
                    { 1, 120, "New disease", new DateTime(2023, 1, 22, 16, 30, 0, 0, DateTimeKind.Utc), new DateTime(2023, 1, 22, 15, 30, 0, 0, DateTimeKind.Utc) },
                    { 2, 180, "Covid-19", new DateTime(2022, 10, 20, 12, 15, 0, 0, DateTimeKind.Utc), new DateTime(2022, 10, 20, 9, 15, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "Forms",
                columns: new[] { "Id", "Description", "EndHourSaturday", "EndHourSunday", "EndHourWorkDay", "Name", "RoomId", "StartHourSaturday", "StartHourSunday", "StartHourWorkDay" },
                values: new object[,]
                {
                    { 1, "Neuroloske operacije i zahvati", "17:00h", "CLOSED", "17:00h", "101,Neurohirurgija", 1, "12:00h", "CLOSED", "8:00h" },
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
                    { 17, "Operacija endokrinog sistema", "17:00h", "CLOSED", "17:00h", "102b,Endokrinologija", 17, "12:00h", "CLOSED", "10:00h" },
                    { 18, "...", "17:00h", "CLOSED", "17:00h", "201b,Gastronomija", 18, "12:00h", "CLOSED", "10:00h" },
                    { 19, "...", "17:00h", "CLOSED", "17:00h", "301b,Magacin", 19, "12:00h", "CLOSED", "10:00h" }
                });

            migrationBuilder.InsertData(
                table: "MedicalDrugs",
                columns: new[] { "Id", "Amount", "Code", "Name" },
                values: new object[,]
                {
                    { 1, 50, "Code1", "Drugs1" },
                    { 2, 50, "Code2", "Drugs2" },
                    { 3, 50, "Code3", "Drugs3" }
                });

            migrationBuilder.InsertData(
                table: "Renovations",
                columns: new[] { "Id", "Available", "Changes", "Duration", "Interval", "RoomId", "Schedule", "Type" },
                values: new object[,]
                {
                    { 1, 3, 1, 3, 3, 2, 1, 2 },
                    { 2, 3, 1, 3, 1, 2, 1, 1 },
                    { 3, 2, 1, 3, 2, 1, 1, 1 },
                    { 4, 2, 1, 3, 2, 3, 0, 2 },
                    { 5, 2, 0, 2, 2, 3, 0, 2 },
                    { 6, 2, 1, 2, 2, 2, 1, 2 },
                    { 7, 1, 1, 3, 3, 2, 1, 1 },
                    { 8, 0, 0, 1, 1, 1, 0, 1 },
                    { 9, 1, 0, 1, 2, 2, 0, 2 }
                });

            migrationBuilder.InsertData(
                table: "Symptoms",
                columns: new[] { "Id", "ExaminationDoneId", "Name" },
                values: new object[,]
                {
                    { 1, null, "Temperatura" },
                    { 2, null, "Glavobolja" },
                    { 3, null, "Bol u stomaku" }
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

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "AddressId", "BloodType", "Email", "FirstName", "Gender", "LastName", "SelectedDoctorId", "UserId", "Pin_Value" },
                values: new object[,]
                {
                    { 1, 1, 0, "peraperic@gmail.com", "Pera", 0, "Peric", 1, 5, "2201000120492" },
                    { 2, 2, 7, "markomarkovic@gmail.com", "Marko", 0, "Markovic", 2, 6, "1412995012451" },
                    { 3, 3, 5, "dusanbaljinac@gmail.com", "Dusan", 0, "Baljinac", 1, 7, "2008004124293" },
                    { 4, 4, 3, "slobodanradulovic@gmail.com", "Slobodan", 0, "Radulovic", 2, 8, "1111952020204" }
                });

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "Id", "CreationDate", "IsAnonymous", "IsPublic", "PatientId", "Status", "Text", "Rating_Rating" },
                values: new object[,]
                {
                    { 1, new DateOnly(2022, 10, 24), true, true, 1, 0, "Bolnica je dobra", 3 },
                    { 2, new DateOnly(2022, 10, 24), false, true, 2, 0, "Bolnica je losa", 4 },
                    { 3, new DateOnly(2022, 10, 24), false, true, 3, 1, "Bolnica je odlicna", 5 },
                    { 4, new DateOnly(2022, 10, 24), true, true, 4, 0, "Bolnica je solidna", 5 }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "FloorId", "Name", "Number", "Type" },
                values: new object[,]
                {
                    { 1, 1, "Neurohirurgija", "101", 3 },
                    { 2, 1, "Kafeterija", "102", 2 },
                    { 3, 1, "Otorinolaringologija", "103", 0 },
                    { 4, 2, "Fizioterapeut", "201", 0 },
                    { 5, 2, "Stomatologija", "202", 0 },
                    { 6, 3, "Magacin", "301", 4 },
                    { 7, 3, "Opsta nega", "302", 0 },
                    { 8, 3, "Cekaonica", "303", 0 },
                    { 9, 4, "Kardiologija", "101a", 3 },
                    { 10, 4, "Vaskularne bolesti", "102a", 0 },
                    { 11, 4, "Hirurgija", "103a", 3 },
                    { 12, 5, "Papirologija", "201a", 0 },
                    { 13, 5, "Prijavna soba", "202a", 0 },
                    { 14, 5, "Uplasta/isplata", "203a", 0 },
                    { 15, 5, "Izgubljeno/nadjeno", "204a", 0 },
                    { 16, 6, "Onkologija", "101b", 0 },
                    { 17, 6, "Endokrinologija", "102b", 3 },
                    { 18, 7, "Gastronomija", "201b", 0 },
                    { 19, 8, "Magacin", "301b", 4 }
                });

            migrationBuilder.InsertData(
                table: "Beds",
                columns: new[] { "Id", "Available", "RoomId" },
                values: new object[,]
                {
                    { 1, false, 1 },
                    { 2, false, 1 },
                    { 3, true, 1 },
                    { 4, false, 1 },
                    { 5, true, 3 },
                    { 6, true, 3 },
                    { 7, true, 3 },
                    { 8, true, 3 },
                    { 9, true, 3 },
                    { 10, true, 3 },
                    { 11, true, 9 },
                    { 12, true, 9 },
                    { 13, true, 9 },
                    { 14, true, 9 },
                    { 15, true, 16 },
                    { 16, true, 16 },
                    { 17, true, 16 },
                    { 18, true, 16 },
                    { 19, true, 17 },
                    { 20, true, 17 },
                    { 21, true, 17 },
                    { 22, true, 17 }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "FirstName", "LastName", "RoomId", "Specialization", "WorkHour_End", "WorkHour_Start" },
                values: new object[,]
                {
                    { 1, "Slobodan", "Radulovic", 1, 0, new DateTime(2022, 12, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 12, 1, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Aleksa", "Zindovic", 2, 0, new DateTime(2022, 12, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 12, 1, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Mica", "Micic", 3, 0, new DateTime(2022, 12, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 12, 1, 8, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "Id", "Amount", "Name", "RoomId" },
                values: new object[,]
                {
                    { 1, 2, "Krevet", 1 },
                    { 2, 2, "Stetoskop", 1 },
                    { 3, 4, "Stolica", 1 },
                    { 4, 20, "Stolica", 2 },
                    { 5, 2, "Aparat za kafu", 2 },
                    { 6, 4, "Fotelja", 2 },
                    { 7, 2, "Busilica", 3 },
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
                table: "MapRooms",
                columns: new[] { "RoomId", "Color", "Height", "Width", "X", "Y" },
                values: new object[,]
                {
                    { 1, "blue", 160, 260, 0, 0 },
                    { 2, "blue", 140, 220, 0, 338 },
                    { 3, "blue", 180, 300, 237, 0 },
                    { 4, "blue", 100, 200, 270, 378 },
                    { 5, "blue", 180, 360, 0, 0 },
                    { 6, "blue", 180, 260, 0, 0 },
                    { 7, "blue", 140, 220, 0, 338 },
                    { 8, "blue", 140, 220, 330, 158 },
                    { 9, "blue", 170, 320, 0, 0 },
                    { 10, "blue", 140, 220, 0, 365 },
                    { 11, "blue", 140, 220, 245, 0 },
                    { 12, "blue", 140, 220, 0, 0 },
                    { 13, "blue", 140, 220, 200, 0 },
                    { 14, "blue", 140, 220, 0, 350 },
                    { 15, "blue", 140, 220, 200, 350 },
                    { 16, "blue", 190, 320, 0, 0 },
                    { 17, "blue", 240, 250, 200, 300 },
                    { 18, "blue", 280, 420, 50, 100 },
                    { 19, "blue", 170, 320, 100, 138 }
                });

            migrationBuilder.InsertData(
                table: "Examinations",
                columns: new[] { "Id", "DoctorId", "PatientId", "RoomId", "Status", "DateRange_End", "DateRange_Start" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, 1, new DateTime(2022, 12, 1, 7, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 12, 1, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, 1, 2, 1, new DateTime(2022, 12, 1, 8, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 12, 1, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 2, 1, 2, 0, new DateTime(2022, 12, 15, 12, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 12, 15, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 3, 1, 3, 0, new DateTime(2023, 1, 22, 8, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 22, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 1, 1, 1, 0, new DateTime(2023, 2, 5, 9, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 5, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 1, 1, 1, 0, new DateTime(2022, 12, 27, 7, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 12, 27, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 1, 3, 3, 1, new DateTime(2022, 12, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 12, 1, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 1, 3, 3, 0, new DateTime(2023, 1, 23, 7, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 23, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 1, 1, 3, 0, new DateTime(2023, 1, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 23, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 1, 2, 3, 0, new DateTime(2023, 1, 23, 8, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 23, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 1, 3, 3, 0, new DateTime(2023, 1, 23, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 23, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 1, 4, 3, 0, new DateTime(2023, 1, 23, 9, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 23, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 1, 1, 3, 0, new DateTime(2023, 1, 23, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 23, 9, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 1, 2, 3, 0, new DateTime(2023, 1, 23, 10, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 23, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 1, 3, 3, 0, new DateTime(2023, 1, 23, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 23, 10, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 16, 1, 4, 3, 0, new DateTime(2023, 1, 23, 11, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 23, 11, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, 1, 1, 3, 0, new DateTime(2023, 1, 23, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 23, 11, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 18, 1, 2, 3, 0, new DateTime(2023, 1, 23, 12, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 23, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, 1, 3, 3, 0, new DateTime(2023, 1, 23, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 23, 12, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 20, 1, 4, 3, 0, new DateTime(2023, 1, 23, 13, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 23, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, 1, 1, 3, 0, new DateTime(2023, 1, 23, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 23, 13, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 22, 1, 2, 3, 0, new DateTime(2023, 1, 23, 14, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 23, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, 1, 3, 3, 0, new DateTime(2023, 1, 23, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 23, 14, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 24, 1, 4, 3, 0, new DateTime(2023, 1, 23, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 23, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, 1, 1, 3, 0, new DateTime(2023, 1, 23, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 23, 15, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 26, 1, 2, 3, 0, new DateTime(2023, 1, 23, 16, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 23, 16, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27, 1, 3, 3, 0, new DateTime(2023, 1, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 23, 16, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 28, 1, 4, 3, 0, new DateTime(2023, 1, 23, 17, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 23, 17, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29, 1, 1, 3, 0, new DateTime(2023, 1, 23, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 23, 17, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 30, 1, 2, 3, 0, new DateTime(2023, 1, 23, 18, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 23, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 31, 1, 3, 3, 0, new DateTime(2023, 1, 23, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 23, 18, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 32, 1, 4, 3, 0, new DateTime(2023, 1, 23, 19, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 23, 19, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 33, 1, 1, 3, 0, new DateTime(2023, 1, 23, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 23, 19, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 34, 1, 3, 3, 0, new DateTime(2023, 1, 24, 7, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 24, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 35, 1, 1, 3, 0, new DateTime(2023, 1, 24, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 24, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 36, 1, 2, 3, 0, new DateTime(2023, 1, 24, 8, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 24, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 37, 1, 3, 3, 0, new DateTime(2023, 1, 24, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 24, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 38, 1, 4, 3, 0, new DateTime(2023, 1, 24, 9, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 24, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 39, 1, 1, 3, 0, new DateTime(2023, 1, 24, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 24, 9, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 40, 1, 2, 3, 0, new DateTime(2023, 1, 24, 10, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 24, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 41, 1, 3, 3, 0, new DateTime(2023, 1, 24, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 24, 10, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 42, 1, 4, 3, 0, new DateTime(2023, 1, 24, 11, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 24, 11, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 43, 1, 1, 3, 0, new DateTime(2023, 1, 24, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 24, 11, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 44, 1, 2, 3, 0, new DateTime(2023, 1, 24, 12, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 24, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 45, 1, 3, 3, 0, new DateTime(2023, 1, 24, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 24, 12, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 46, 1, 4, 3, 0, new DateTime(2023, 1, 24, 13, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 24, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 47, 1, 1, 3, 0, new DateTime(2023, 1, 24, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 24, 13, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 48, 1, 2, 3, 0, new DateTime(2023, 1, 24, 14, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 24, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 49, 1, 3, 3, 0, new DateTime(2023, 1, 24, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 24, 14, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 50, 1, 4, 3, 0, new DateTime(2023, 1, 24, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 24, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 51, 1, 1, 3, 0, new DateTime(2023, 1, 24, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 24, 15, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 52, 1, 2, 3, 0, new DateTime(2023, 1, 24, 16, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 24, 16, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 53, 1, 3, 3, 0, new DateTime(2023, 1, 24, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 24, 16, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 54, 1, 4, 3, 0, new DateTime(2023, 1, 24, 17, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 24, 17, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 55, 1, 1, 3, 0, new DateTime(2023, 1, 24, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 24, 17, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 56, 1, 2, 3, 0, new DateTime(2023, 1, 24, 18, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 24, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 57, 1, 3, 3, 0, new DateTime(2023, 1, 24, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 24, 18, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 58, 1, 4, 3, 0, new DateTime(2023, 1, 24, 19, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 24, 19, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 59, 1, 1, 3, 0, new DateTime(2023, 1, 24, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 24, 19, 30, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "TreatmentHistories",
                columns: new[] { "Id", "Active", "BedId", "DischargeReason", "EndDate", "PatientId", "Reason", "RoomId", "StartDate" },
                values: new object[,]
                {
                    { 1, false, 1, "abc", new DateTime(2023, 1, 15, 17, 6, 25, 627, DateTimeKind.Utc).AddTicks(1881), 1, "reason1", 1, new DateTime(2023, 1, 15, 17, 6, 25, 627, DateTimeKind.Utc).AddTicks(1879) },
                    { 2, false, 2, "abc", new DateTime(2023, 1, 15, 17, 6, 25, 627, DateTimeKind.Utc).AddTicks(1886), 2, "reason2", 1, new DateTime(2023, 1, 15, 17, 6, 25, 627, DateTimeKind.Utc).AddTicks(1885) },
                    { 3, false, 4, "abc", new DateTime(2023, 1, 15, 17, 6, 25, 627, DateTimeKind.Utc).AddTicks(1888), 3, "reason3", 2, new DateTime(2023, 1, 15, 17, 6, 25, 627, DateTimeKind.Utc).AddTicks(1887) },
                    { 4, true, 1, "abc", null, 1, "reason1", 1, new DateTime(2023, 1, 15, 17, 6, 25, 627, DateTimeKind.Utc).AddTicks(1889) },
                    { 5, true, 2, "abc", null, 2, "reason2", 1, new DateTime(2023, 1, 15, 17, 6, 25, 627, DateTimeKind.Utc).AddTicks(1889) },
                    { 6, true, 4, "abc", null, 3, "reason3", 2, new DateTime(2023, 1, 15, 17, 6, 25, 627, DateTimeKind.Utc).AddTicks(1890) }
                });

            migrationBuilder.InsertData(
                table: "ExaminationsDone",
                columns: new[] { "Id", "ExaminationId", "Record" },
                values: new object[,]
                {
                    { 1, 1, "Patient successfully recovered." },
                    { 2, 2, "Patient successfully recovered after having stomach problems." },
                    { 3, 3, "Patient feels great." }
                });

            migrationBuilder.InsertData(
                table: "Therapies",
                columns: new[] { "Id", "Amount", "DoctorId", "Reason", "TherapySubject", "TherapyType", "TreatmentHistoryId", "WhenPrescribed" },
                values: new object[,]
                {
                    { 1, 1, 1, "Headache", "Bromazepam 500mg", 0, 1, new DateTime(2023, 1, 15, 17, 6, 25, 627, DateTimeKind.Utc).AddTicks(1950) },
                    { 2, 1, 2, "Blood loss", "A+ 500ml", 1, 1, new DateTime(2023, 1, 15, 17, 6, 25, 627, DateTimeKind.Utc).AddTicks(1952) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AllergenPatient_PatientsId",
                table: "AllergenPatient",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentEventWrappers_PatientId",
                table: "AppointmentEventWrappers",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Beds_RoomId",
                table: "Beds",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Bloods_Type",
                table: "Bloods",
                column: "Type",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BloodUnitRequests_DoctorId",
                table: "BloodUnitRequests",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsiliumDoctor_DoctorsId",
                table: "ConsiliumDoctor",
                column: "DoctorsId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_RoomId",
                table: "Doctors",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_RoomId",
                table: "Equipments",
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
                name: "IX_ExaminationsDone_ExaminationId",
                table: "ExaminationsDone",
                column: "ExaminationId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_PatientId",
                table: "Feedbacks",
                column: "PatientId");

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
                name: "IX_MedicalDrugs_Code",
                table: "MedicalDrugs",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_AddressId",
                table: "Patients",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_ExaminationDoneId",
                table: "Prescription",
                column: "ExaminationDoneId");

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionItem_MedicalDrugId",
                table: "PrescriptionItem",
                column: "MedicalDrugId");

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionItem_PrescriptionId",
                table: "PrescriptionItem",
                column: "PrescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_FloorId",
                table: "Rooms",
                column: "FloorId");

            migrationBuilder.CreateIndex(
                name: "IX_Symptoms_ExaminationDoneId",
                table: "Symptoms",
                column: "ExaminationDoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Therapies_DoctorId",
                table: "Therapies",
                column: "DoctorId");

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

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentHistories_RoomId",
                table: "TreatmentHistories",
                column: "RoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllergenPatient");

            migrationBuilder.DropTable(
                name: "AppointmentEventWrappers");

            migrationBuilder.DropTable(
                name: "Bloods");

            migrationBuilder.DropTable(
                name: "BloodUnitRequests");

            migrationBuilder.DropTable(
                name: "BloodUnits");

            migrationBuilder.DropTable(
                name: "ConsiliumDoctor");

            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "EquipmentTransfers");

            migrationBuilder.DropTable(
                name: "Feedbacks");

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
                name: "PrescriptionItem");

            migrationBuilder.DropTable(
                name: "RenovationEventWrappers");

            migrationBuilder.DropTable(
                name: "Renovations");

            migrationBuilder.DropTable(
                name: "Symptoms");

            migrationBuilder.DropTable(
                name: "Therapies");

            migrationBuilder.DropTable(
                name: "Allergens");

            migrationBuilder.DropTable(
                name: "Consiliums");

            migrationBuilder.DropTable(
                name: "MedicalDrugs");

            migrationBuilder.DropTable(
                name: "Prescription");

            migrationBuilder.DropTable(
                name: "TreatmentHistories");

            migrationBuilder.DropTable(
                name: "ExaminationsDone");

            migrationBuilder.DropTable(
                name: "Beds");

            migrationBuilder.DropTable(
                name: "Examinations");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Floors");

            migrationBuilder.DropTable(
                name: "Buildings");
        }
    }
}
