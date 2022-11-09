using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HospitalLibrary.Migrations
{
    public partial class UpdatePatientModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Rooms",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BloodType",
                table: "Patients",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Patients",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Patients",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Pin",
                table: "Patients",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Bed",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoomId = table.Column<int>(type: "integer", nullable: false),
                    Available = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bed", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bed_Rooms_RoomId",
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
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    DischargeReason = table.Column<string>(type: "text", nullable: false),
                    PatientId = table.Column<int>(type: "integer", nullable: false),
                    BedId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TreatmentHistories_Bed_BedId",
                        column: x => x.BedId,
                        principalTable: "Bed",
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
                name: "Therapy",
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
                    table.PrimaryKey("PK_Therapy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Therapy_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Therapy_TreatmentHistories_TreatmentHistoryId",
                        column: x => x.TreatmentHistoryId,
                        principalTable: "TreatmentHistories",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Pin" },
                values: new object[] { "peraperic@gmail.com", "2201000120492" });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BloodType", "Email", "Pin" },
                values: new object[] { 7, "markomarkovic@gmail.com", "1412995012451" });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BloodType", "Email", "Pin" },
                values: new object[] { 5, "dusanbaljinac@gmail.com", "2008004124293" });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BloodType", "Email", "Pin" },
                values: new object[] { 3, "slobodanradulovic@gmail.com", "1111978020204" });

            migrationBuilder.CreateIndex(
                name: "IX_Bed_RoomId",
                table: "Bed",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Therapy_DoctorId",
                table: "Therapy",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Therapy_TreatmentHistoryId",
                table: "Therapy",
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
                name: "Therapy");

            migrationBuilder.DropTable(
                name: "TreatmentHistories");

            migrationBuilder.DropTable(
                name: "Bed");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "BloodType",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Pin",
                table: "Patients");
        }
    }
}
