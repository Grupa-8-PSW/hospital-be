using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalLibrary.Migrations
{
    public partial class ge_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "TreatmentHistories",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "TreatmentHistories",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "WhenPrescribed",
                table: "Therapies",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartTime",
                table: "Examinations",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartWork",
                table: "Doctors",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndWork",
                table: "Doctors",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DatePrescribed",
                table: "BloodUnits",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "BloodUnitRequests",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndWork", "FirstName", "LastName", "StartWork" },
                values: new object[] { new DateTime(2022, 11, 22, 18, 10, 10, 0, DateTimeKind.Unspecified), "Pera", "Peric", new DateTime(2022, 11, 22, 10, 10, 10, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndWork", "FirstName", "LastName", "RoomId", "StartWork" },
                values: new object[] { new DateTime(2022, 11, 22, 19, 10, 10, 0, DateTimeKind.Unspecified), "Sergej", "Milinkovic-Savic", 1, new DateTime(2022, 11, 22, 10, 10, 10, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Examinations",
                columns: new[] { "Id", "DoctorId", "Duration", "PatientId", "RoomId", "StartTime" },
                values: new object[,]
                {
                    { 1, 1, 200, 1, 1, new DateTime(2022, 11, 22, 10, 10, 10, 0, DateTimeKind.Unspecified) },
                    { 2, 2, 100, 2, 2, new DateTime(2022, 11, 22, 14, 10, 10, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name", "StartHourWorkDay" },
                values: new object[] { "Neuroloske operacije i zahvati", "101,Neurohirurgija", "8:00h" });

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Operacija endokrinog sistema", "102b,Endokrinologija" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "Type" },
                values: new object[] { "Neurohirurgija", 3 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2,
                column: "Type",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 6,
                column: "Type",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 9,
                column: "Type",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 11,
                column: "Type",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Name", "Type" },
                values: new object[] { "Endokrinologija", 3 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 19,
                column: "Type",
                value: 4);

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 28, 19, 47, 54, 992, DateTimeKind.Utc).AddTicks(4593), new DateTime(2022, 11, 28, 19, 47, 54, 992, DateTimeKind.Utc).AddTicks(4591) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 28, 19, 47, 54, 992, DateTimeKind.Utc).AddTicks(4597), new DateTime(2022, 11, 28, 19, 47, 54, 992, DateTimeKind.Utc).AddTicks(4596) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 28, 19, 47, 54, 992, DateTimeKind.Utc).AddTicks(4598), new DateTime(2022, 11, 28, 19, 47, 54, 992, DateTimeKind.Utc).AddTicks(4598) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 4,
                column: "StartDate",
                value: new DateTime(2022, 11, 28, 19, 47, 54, 992, DateTimeKind.Utc).AddTicks(4599));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 5,
                column: "StartDate",
                value: new DateTime(2022, 11, 28, 19, 47, 54, 992, DateTimeKind.Utc).AddTicks(4600));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 6,
                column: "StartDate",
                value: new DateTime(2022, 11, 28, 19, 47, 54, 992, DateTimeKind.Utc).AddTicks(4601));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "TreatmentHistories",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "TreatmentHistories",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "WhenPrescribed",
                table: "Therapies",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartTime",
                table: "Examinations",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartWork",
                table: "Doctors",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndWork",
                table: "Doctors",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DatePrescribed",
                table: "BloodUnits",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "BloodUnitRequests",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndWork", "FirstName", "LastName", "StartWork" },
                values: new object[] { new DateTime(1998, 4, 30, 15, 0, 0, 0, DateTimeKind.Utc), "Zeljko", "Babic", new DateTime(1998, 4, 30, 7, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndWork", "FirstName", "LastName", "RoomId", "StartWork" },
                values: new object[] { new DateTime(1998, 4, 30, 16, 0, 0, 0, DateTimeKind.Utc), "Bora", "Stevanovic", 2, new DateTime(1998, 4, 30, 8, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name", "StartHourWorkDay" },
                values: new object[] { "Pregledi za decu", "101,Pedijatrija", "10:00h" });

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Description", "Name" },
                values: new object[] { "...", "102b,Pedijatrija" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "Type" },
                values: new object[] { "Pedijatrija", 0 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2,
                column: "Type",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 6,
                column: "Type",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 9,
                column: "Type",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 11,
                column: "Type",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Name", "Type" },
                values: new object[] { "Onkologija", 0 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 19,
                column: "Type",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 24, 1, 16, 20, 513, DateTimeKind.Utc).AddTicks(7247), new DateTime(2022, 11, 24, 1, 16, 20, 513, DateTimeKind.Utc).AddTicks(7246) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 24, 1, 16, 20, 513, DateTimeKind.Utc).AddTicks(7252), new DateTime(2022, 11, 24, 1, 16, 20, 513, DateTimeKind.Utc).AddTicks(7251) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 24, 1, 16, 20, 513, DateTimeKind.Utc).AddTicks(7253), new DateTime(2022, 11, 24, 1, 16, 20, 513, DateTimeKind.Utc).AddTicks(7253) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 4,
                column: "StartDate",
                value: new DateTime(2022, 11, 24, 1, 16, 20, 513, DateTimeKind.Utc).AddTicks(7254));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 5,
                column: "StartDate",
                value: new DateTime(2022, 11, 24, 1, 16, 20, 513, DateTimeKind.Utc).AddTicks(7256));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 6,
                column: "StartDate",
                value: new DateTime(2022, 11, 24, 1, 16, 20, 513, DateTimeKind.Utc).AddTicks(7257));
        }
    }
}
