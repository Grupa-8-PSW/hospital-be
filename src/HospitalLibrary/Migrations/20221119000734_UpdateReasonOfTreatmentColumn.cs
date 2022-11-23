using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalLibrary.Migrations
{
    public partial class UpdateReasonOfTreatmentColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Reason",
                table: "TreatmentHistories",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndWork", "StartWork" },
                values: new object[] { new DateTime(2022, 11, 19, 0, 7, 30, 597, DateTimeKind.Utc).AddTicks(1847), new DateTime(2022, 11, 19, 0, 7, 30, 597, DateTimeKind.Utc).AddTicks(1845) });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndWork", "StartWork" },
                values: new object[] { new DateTime(2022, 11, 19, 0, 7, 30, 597, DateTimeKind.Utc).AddTicks(1851), new DateTime(2022, 11, 19, 0, 7, 30, 597, DateTimeKind.Utc).AddTicks(1850) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Active", "EndDate", "Reason", "StartDate" },
                values: new object[] { false, new DateTime(2022, 11, 19, 0, 7, 30, 597, DateTimeKind.Utc).AddTicks(2031), "reason1", new DateTime(2022, 11, 19, 0, 7, 30, 597, DateTimeKind.Utc).AddTicks(2030) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Active", "EndDate", "Reason", "StartDate" },
                values: new object[] { false, new DateTime(2022, 11, 19, 0, 7, 30, 597, DateTimeKind.Utc).AddTicks(2053), "reason2", new DateTime(2022, 11, 19, 0, 7, 30, 597, DateTimeKind.Utc).AddTicks(2052) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Active", "EndDate", "Reason", "StartDate" },
                values: new object[] { false, new DateTime(2022, 11, 19, 0, 7, 30, 597, DateTimeKind.Utc).AddTicks(2059), "reason3", new DateTime(2022, 11, 19, 0, 7, 30, 597, DateTimeKind.Utc).AddTicks(2058) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Reason",
                table: "TreatmentHistories",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndWork", "StartWork" },
                values: new object[] { new DateTime(2022, 11, 16, 1, 56, 46, 40, DateTimeKind.Utc).AddTicks(9800), new DateTime(2022, 11, 16, 1, 56, 46, 40, DateTimeKind.Utc).AddTicks(9798) });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndWork", "StartWork" },
                values: new object[] { new DateTime(2022, 11, 16, 1, 56, 46, 40, DateTimeKind.Utc).AddTicks(9805), new DateTime(2022, 11, 16, 1, 56, 46, 40, DateTimeKind.Utc).AddTicks(9804) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Active", "EndDate", "Reason", "StartDate" },
                values: new object[] { true, new DateTime(2022, 11, 16, 1, 56, 46, 40, DateTimeKind.Utc).AddTicks(9918), null, new DateTime(2022, 11, 16, 1, 56, 46, 40, DateTimeKind.Utc).AddTicks(9917) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Active", "EndDate", "Reason", "StartDate" },
                values: new object[] { true, new DateTime(2022, 11, 16, 1, 56, 46, 40, DateTimeKind.Utc).AddTicks(9928), null, new DateTime(2022, 11, 16, 1, 56, 46, 40, DateTimeKind.Utc).AddTicks(9927) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Active", "EndDate", "Reason", "StartDate" },
                values: new object[] { true, new DateTime(2022, 11, 16, 1, 56, 46, 40, DateTimeKind.Utc).AddTicks(9932), null, new DateTime(2022, 11, 16, 1, 56, 46, 40, DateTimeKind.Utc).AddTicks(9931) });
        }
    }
}
