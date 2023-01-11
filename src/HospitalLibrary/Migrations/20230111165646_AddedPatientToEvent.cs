using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HospitalLibrary.Migrations
{
    public partial class AddedPatientToEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventWrappers");

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

            migrationBuilder.UpdateData(
                table: "Therapies",
                keyColumn: "Id",
                keyValue: 1,
                column: "WhenPrescribed",
                value: new DateTime(2023, 1, 11, 16, 56, 46, 54, DateTimeKind.Utc).AddTicks(8098));

            migrationBuilder.UpdateData(
                table: "Therapies",
                keyColumn: "Id",
                keyValue: 2,
                column: "WhenPrescribed",
                value: new DateTime(2023, 1, 11, 16, 56, 46, 54, DateTimeKind.Utc).AddTicks(8100));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 1, 11, 16, 56, 46, 54, DateTimeKind.Utc).AddTicks(8071), new DateTime(2023, 1, 11, 16, 56, 46, 54, DateTimeKind.Utc).AddTicks(8070) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 1, 11, 16, 56, 46, 54, DateTimeKind.Utc).AddTicks(8074), new DateTime(2023, 1, 11, 16, 56, 46, 54, DateTimeKind.Utc).AddTicks(8074) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 1, 11, 16, 56, 46, 54, DateTimeKind.Utc).AddTicks(8075), new DateTime(2023, 1, 11, 16, 56, 46, 54, DateTimeKind.Utc).AddTicks(8075) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 4,
                column: "StartDate",
                value: new DateTime(2023, 1, 11, 16, 56, 46, 54, DateTimeKind.Utc).AddTicks(8076));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 5,
                column: "StartDate",
                value: new DateTime(2023, 1, 11, 16, 56, 46, 54, DateTimeKind.Utc).AddTicks(8077));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 6,
                column: "StartDate",
                value: new DateTime(2023, 1, 11, 16, 56, 46, 54, DateTimeKind.Utc).AddTicks(8078));

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentEventWrappers_PatientId",
                table: "AppointmentEventWrappers",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointmentEventWrappers");

            migrationBuilder.CreateTable(
                name: "EventWrappers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AggregateId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Data = table.Column<object>(type: "json", nullable: false),
                    EventType = table.Column<int>(type: "integer", nullable: false),
                    PatientId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventWrappers", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Therapies",
                keyColumn: "Id",
                keyValue: 1,
                column: "WhenPrescribed",
                value: new DateTime(2023, 1, 11, 16, 38, 47, 60, DateTimeKind.Utc).AddTicks(9369));

            migrationBuilder.UpdateData(
                table: "Therapies",
                keyColumn: "Id",
                keyValue: 2,
                column: "WhenPrescribed",
                value: new DateTime(2023, 1, 11, 16, 38, 47, 60, DateTimeKind.Utc).AddTicks(9371));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 1, 11, 16, 38, 47, 60, DateTimeKind.Utc).AddTicks(9322), new DateTime(2023, 1, 11, 16, 38, 47, 60, DateTimeKind.Utc).AddTicks(9321) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 1, 11, 16, 38, 47, 60, DateTimeKind.Utc).AddTicks(9325), new DateTime(2023, 1, 11, 16, 38, 47, 60, DateTimeKind.Utc).AddTicks(9325) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 1, 11, 16, 38, 47, 60, DateTimeKind.Utc).AddTicks(9326), new DateTime(2023, 1, 11, 16, 38, 47, 60, DateTimeKind.Utc).AddTicks(9326) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 4,
                column: "StartDate",
                value: new DateTime(2023, 1, 11, 16, 38, 47, 60, DateTimeKind.Utc).AddTicks(9327));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 5,
                column: "StartDate",
                value: new DateTime(2023, 1, 11, 16, 38, 47, 60, DateTimeKind.Utc).AddTicks(9328));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 6,
                column: "StartDate",
                value: new DateTime(2023, 1, 11, 16, 38, 47, 60, DateTimeKind.Utc).AddTicks(9329));
        }
    }
}
