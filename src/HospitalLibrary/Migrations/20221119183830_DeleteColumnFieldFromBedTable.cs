using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalLibrary.Migrations
{
    public partial class DeleteColumnFieldFromBedTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndWork", "StartWork" },
                values: new object[] { new DateTime(2022, 11, 19, 18, 38, 27, 223, DateTimeKind.Utc).AddTicks(7959), new DateTime(2022, 11, 19, 18, 38, 27, 223, DateTimeKind.Utc).AddTicks(7957) });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndWork", "StartWork" },
                values: new object[] { new DateTime(2022, 11, 19, 18, 38, 27, 223, DateTimeKind.Utc).AddTicks(7964), new DateTime(2022, 11, 19, 18, 38, 27, 223, DateTimeKind.Utc).AddTicks(7963) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 19, 18, 38, 27, 223, DateTimeKind.Utc).AddTicks(8156), new DateTime(2022, 11, 19, 18, 38, 27, 223, DateTimeKind.Utc).AddTicks(8154) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 19, 18, 38, 27, 223, DateTimeKind.Utc).AddTicks(8172), new DateTime(2022, 11, 19, 18, 38, 27, 223, DateTimeKind.Utc).AddTicks(8171) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 19, 18, 38, 27, 223, DateTimeKind.Utc).AddTicks(8178), new DateTime(2022, 11, 19, 18, 38, 27, 223, DateTimeKind.Utc).AddTicks(8177) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 4,
                column: "StartDate",
                value: new DateTime(2022, 11, 19, 18, 38, 27, 223, DateTimeKind.Utc).AddTicks(8182));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 5,
                column: "StartDate",
                value: new DateTime(2022, 11, 19, 18, 38, 27, 223, DateTimeKind.Utc).AddTicks(8187));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 6,
                column: "StartDate",
                value: new DateTime(2022, 11, 19, 18, 38, 27, 223, DateTimeKind.Utc).AddTicks(8190));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndWork", "StartWork" },
                values: new object[] { new DateTime(2022, 11, 19, 18, 27, 20, 360, DateTimeKind.Utc).AddTicks(3912), new DateTime(2022, 11, 19, 18, 27, 20, 360, DateTimeKind.Utc).AddTicks(3911) });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndWork", "StartWork" },
                values: new object[] { new DateTime(2022, 11, 19, 18, 27, 20, 360, DateTimeKind.Utc).AddTicks(3918), new DateTime(2022, 11, 19, 18, 27, 20, 360, DateTimeKind.Utc).AddTicks(3917) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 19, 18, 27, 20, 360, DateTimeKind.Utc).AddTicks(4402), new DateTime(2022, 11, 19, 18, 27, 20, 360, DateTimeKind.Utc).AddTicks(4398) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 19, 18, 27, 20, 360, DateTimeKind.Utc).AddTicks(4418), new DateTime(2022, 11, 19, 18, 27, 20, 360, DateTimeKind.Utc).AddTicks(4417) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 19, 18, 27, 20, 360, DateTimeKind.Utc).AddTicks(4424), new DateTime(2022, 11, 19, 18, 27, 20, 360, DateTimeKind.Utc).AddTicks(4423) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 4,
                column: "StartDate",
                value: new DateTime(2022, 11, 19, 18, 27, 20, 360, DateTimeKind.Utc).AddTicks(4428));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 5,
                column: "StartDate",
                value: new DateTime(2022, 11, 19, 18, 27, 20, 360, DateTimeKind.Utc).AddTicks(4434));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 6,
                column: "StartDate",
                value: new DateTime(2022, 11, 19, 18, 27, 20, 360, DateTimeKind.Utc).AddTicks(4437));
        }
    }
}
