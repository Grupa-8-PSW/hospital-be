using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalLibrary.Migrations
{
    public partial class DeleteVirtualFromRoomFieldInBedModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndWork", "StartWork" },
                values: new object[] { new DateTime(2022, 11, 19, 18, 23, 28, 757, DateTimeKind.Utc).AddTicks(8031), new DateTime(2022, 11, 19, 18, 23, 28, 757, DateTimeKind.Utc).AddTicks(8028) });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndWork", "StartWork" },
                values: new object[] { new DateTime(2022, 11, 19, 18, 23, 28, 757, DateTimeKind.Utc).AddTicks(8036), new DateTime(2022, 11, 19, 18, 23, 28, 757, DateTimeKind.Utc).AddTicks(8035) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 19, 18, 23, 28, 757, DateTimeKind.Utc).AddTicks(8242), new DateTime(2022, 11, 19, 18, 23, 28, 757, DateTimeKind.Utc).AddTicks(8239) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 19, 18, 23, 28, 757, DateTimeKind.Utc).AddTicks(8260), new DateTime(2022, 11, 19, 18, 23, 28, 757, DateTimeKind.Utc).AddTicks(8259) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 19, 18, 23, 28, 757, DateTimeKind.Utc).AddTicks(8265), new DateTime(2022, 11, 19, 18, 23, 28, 757, DateTimeKind.Utc).AddTicks(8264) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 4,
                column: "StartDate",
                value: new DateTime(2022, 11, 19, 18, 23, 28, 757, DateTimeKind.Utc).AddTicks(8268));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 5,
                column: "StartDate",
                value: new DateTime(2022, 11, 19, 18, 23, 28, 757, DateTimeKind.Utc).AddTicks(8275));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 6,
                column: "StartDate",
                value: new DateTime(2022, 11, 19, 18, 23, 28, 757, DateTimeKind.Utc).AddTicks(8280));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndWork", "StartWork" },
                values: new object[] { new DateTime(2022, 11, 19, 17, 59, 14, 523, DateTimeKind.Utc).AddTicks(6707), new DateTime(2022, 11, 19, 17, 59, 14, 523, DateTimeKind.Utc).AddTicks(6704) });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndWork", "StartWork" },
                values: new object[] { new DateTime(2022, 11, 19, 17, 59, 14, 523, DateTimeKind.Utc).AddTicks(6715), new DateTime(2022, 11, 19, 17, 59, 14, 523, DateTimeKind.Utc).AddTicks(6714) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 19, 17, 59, 14, 523, DateTimeKind.Utc).AddTicks(6891), new DateTime(2022, 11, 19, 17, 59, 14, 523, DateTimeKind.Utc).AddTicks(6889) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 19, 17, 59, 14, 523, DateTimeKind.Utc).AddTicks(6906), new DateTime(2022, 11, 19, 17, 59, 14, 523, DateTimeKind.Utc).AddTicks(6905) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 19, 17, 59, 14, 523, DateTimeKind.Utc).AddTicks(6911), new DateTime(2022, 11, 19, 17, 59, 14, 523, DateTimeKind.Utc).AddTicks(6910) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 4,
                column: "StartDate",
                value: new DateTime(2022, 11, 19, 17, 59, 14, 523, DateTimeKind.Utc).AddTicks(6917));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 5,
                column: "StartDate",
                value: new DateTime(2022, 11, 19, 17, 59, 14, 523, DateTimeKind.Utc).AddTicks(6919));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 6,
                column: "StartDate",
                value: new DateTime(2022, 11, 19, 17, 59, 14, 523, DateTimeKind.Utc).AddTicks(6924));
        }
    }
}
