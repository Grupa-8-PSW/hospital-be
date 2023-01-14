﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HospitalLibrary.Migrations
{
    public partial class RenovationSourcingMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Renovations_Rooms_RoomId",
                table: "Renovations");

            migrationBuilder.DropIndex(
                name: "IX_Renovations_RoomId",
                table: "Renovations");

            migrationBuilder.DropColumn(
                name: "DateRange_End",
                table: "Renovations");

            migrationBuilder.DropColumn(
                name: "DateRange_Start",
                table: "Renovations");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Renovations",
                newName: "Schedule");

            migrationBuilder.AddColumn<int>(
                name: "Available",
                table: "Renovations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Changes",
                table: "Renovations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "Renovations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Interval",
                table: "Renovations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.UpdateData(
                table: "Therapies",
                keyColumn: "Id",
                keyValue: 1,
                column: "WhenPrescribed",
                value: new DateTime(2023, 1, 13, 20, 14, 9, 860, DateTimeKind.Utc).AddTicks(9721));

            migrationBuilder.UpdateData(
                table: "Therapies",
                keyColumn: "Id",
                keyValue: 2,
                column: "WhenPrescribed",
                value: new DateTime(2023, 1, 13, 20, 14, 9, 860, DateTimeKind.Utc).AddTicks(9723));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 1, 13, 20, 14, 9, 860, DateTimeKind.Utc).AddTicks(9617), new DateTime(2023, 1, 13, 20, 14, 9, 860, DateTimeKind.Utc).AddTicks(9616) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 1, 13, 20, 14, 9, 860, DateTimeKind.Utc).AddTicks(9621), new DateTime(2023, 1, 13, 20, 14, 9, 860, DateTimeKind.Utc).AddTicks(9621) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 1, 13, 20, 14, 9, 860, DateTimeKind.Utc).AddTicks(9623), new DateTime(2023, 1, 13, 20, 14, 9, 860, DateTimeKind.Utc).AddTicks(9623) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 4,
                column: "StartDate",
                value: new DateTime(2023, 1, 13, 20, 14, 9, 860, DateTimeKind.Utc).AddTicks(9625));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 5,
                column: "StartDate",
                value: new DateTime(2023, 1, 13, 20, 14, 9, 860, DateTimeKind.Utc).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 6,
                column: "StartDate",
                value: new DateTime(2023, 1, 13, 20, 14, 9, 860, DateTimeKind.Utc).AddTicks(9628));

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentEventWrappers_PatientId",
                table: "AppointmentEventWrappers",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointmentEventWrappers");

            migrationBuilder.DropTable(
                name: "RenovationEventWrappers");

            migrationBuilder.DeleteData(
                table: "Renovations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Renovations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Renovations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Renovations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Renovations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Renovations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Renovations",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Renovations",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Renovations",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DropColumn(
                name: "Available",
                table: "Renovations");

            migrationBuilder.DropColumn(
                name: "Changes",
                table: "Renovations");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Renovations");

            migrationBuilder.DropColumn(
                name: "Interval",
                table: "Renovations");

            migrationBuilder.RenameColumn(
                name: "Schedule",
                table: "Renovations",
                newName: "Status");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRange_End",
                table: "Renovations",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRange_Start",
                table: "Renovations",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Therapies",
                keyColumn: "Id",
                keyValue: 1,
                column: "WhenPrescribed",
                value: new DateTime(2023, 1, 5, 21, 11, 13, 783, DateTimeKind.Utc).AddTicks(297));

            migrationBuilder.UpdateData(
                table: "Therapies",
                keyColumn: "Id",
                keyValue: 2,
                column: "WhenPrescribed",
                value: new DateTime(2023, 1, 5, 21, 11, 13, 783, DateTimeKind.Utc).AddTicks(298));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 1, 5, 21, 11, 13, 783, DateTimeKind.Utc).AddTicks(243), new DateTime(2023, 1, 5, 21, 11, 13, 783, DateTimeKind.Utc).AddTicks(242) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 1, 5, 21, 11, 13, 783, DateTimeKind.Utc).AddTicks(249), new DateTime(2023, 1, 5, 21, 11, 13, 783, DateTimeKind.Utc).AddTicks(248) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 1, 5, 21, 11, 13, 783, DateTimeKind.Utc).AddTicks(250), new DateTime(2023, 1, 5, 21, 11, 13, 783, DateTimeKind.Utc).AddTicks(250) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 4,
                column: "StartDate",
                value: new DateTime(2023, 1, 5, 21, 11, 13, 783, DateTimeKind.Utc).AddTicks(251));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 5,
                column: "StartDate",
                value: new DateTime(2023, 1, 5, 21, 11, 13, 783, DateTimeKind.Utc).AddTicks(252));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 6,
                column: "StartDate",
                value: new DateTime(2023, 1, 5, 21, 11, 13, 783, DateTimeKind.Utc).AddTicks(254));

            migrationBuilder.CreateIndex(
                name: "IX_Renovations_RoomId",
                table: "Renovations",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Renovations_Rooms_RoomId",
                table: "Renovations",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
