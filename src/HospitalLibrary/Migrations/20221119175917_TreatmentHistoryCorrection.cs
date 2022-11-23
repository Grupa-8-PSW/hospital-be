using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalLibrary.Migrations
{
    public partial class TreatmentHistoryCorrection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "TreatmentHistories",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Beds",
                keyColumn: "Id",
                keyValue: 1,
                column: "Available",
                value: false);

            migrationBuilder.UpdateData(
                table: "Beds",
                keyColumn: "Id",
                keyValue: 2,
                column: "Available",
                value: false);

            migrationBuilder.UpdateData(
                table: "Beds",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Available", "RoomId" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                table: "Beds",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Available", "RoomId" },
                values: new object[] { false, 1 });

            migrationBuilder.UpdateData(
                table: "Beds",
                keyColumn: "Id",
                keyValue: 5,
                column: "Available",
                value: true);

            migrationBuilder.UpdateData(
                table: "Beds",
                keyColumn: "Id",
                keyValue: 6,
                column: "Available",
                value: true);

            migrationBuilder.InsertData(
                table: "Beds",
                columns: new[] { "Id", "Available", "RoomId" },
                values: new object[,]
                {
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
                columns: new[] { "EndDate", "RoomId", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 19, 17, 59, 14, 523, DateTimeKind.Utc).AddTicks(6891), 1, new DateTime(2022, 11, 19, 17, 59, 14, 523, DateTimeKind.Utc).AddTicks(6889) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "RoomId", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 19, 17, 59, 14, 523, DateTimeKind.Utc).AddTicks(6906), 1, new DateTime(2022, 11, 19, 17, 59, 14, 523, DateTimeKind.Utc).AddTicks(6905) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BedId", "EndDate", "RoomId", "StartDate" },
                values: new object[] { 4, new DateTime(2022, 11, 19, 17, 59, 14, 523, DateTimeKind.Utc).AddTicks(6911), 2, new DateTime(2022, 11, 19, 17, 59, 14, 523, DateTimeKind.Utc).AddTicks(6910) });

            migrationBuilder.InsertData(
                table: "TreatmentHistories",
                columns: new[] { "Id", "Active", "BedId", "DischargeReason", "EndDate", "PatientId", "Reason", "RoomId", "StartDate" },
                values: new object[,]
                {
                    { 4, true, 1, "abc", null, 1, "reason1", 1, new DateTime(2022, 11, 19, 17, 59, 14, 523, DateTimeKind.Utc).AddTicks(6917) },
                    { 5, true, 2, "abc", null, 2, "reason2", 1, new DateTime(2022, 11, 19, 17, 59, 14, 523, DateTimeKind.Utc).AddTicks(6919) },
                    { 6, true, 4, "abc", null, 3, "reason3", 2, new DateTime(2022, 11, 19, 17, 59, 14, 523, DateTimeKind.Utc).AddTicks(6924) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentHistories_RoomId",
                table: "TreatmentHistories",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_TreatmentHistories_Rooms_RoomId",
                table: "TreatmentHistories",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TreatmentHistories_Rooms_RoomId",
                table: "TreatmentHistories");

            migrationBuilder.DropIndex(
                name: "IX_TreatmentHistories_RoomId",
                table: "TreatmentHistories");

            migrationBuilder.DeleteData(
                table: "Beds",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Beds",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Beds",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Beds",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Beds",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Beds",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Beds",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Beds",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Beds",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Beds",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Beds",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Beds",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Beds",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Beds",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Beds",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Beds",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "TreatmentHistories");

            migrationBuilder.UpdateData(
                table: "Beds",
                keyColumn: "Id",
                keyValue: 1,
                column: "Available",
                value: true);

            migrationBuilder.UpdateData(
                table: "Beds",
                keyColumn: "Id",
                keyValue: 2,
                column: "Available",
                value: true);

            migrationBuilder.UpdateData(
                table: "Beds",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Available", "RoomId" },
                values: new object[] { false, 2 });

            migrationBuilder.UpdateData(
                table: "Beds",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Available", "RoomId" },
                values: new object[] { true, 2 });

            migrationBuilder.UpdateData(
                table: "Beds",
                keyColumn: "Id",
                keyValue: 5,
                column: "Available",
                value: false);

            migrationBuilder.UpdateData(
                table: "Beds",
                keyColumn: "Id",
                keyValue: 6,
                column: "Available",
                value: false);

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
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 19, 0, 7, 30, 597, DateTimeKind.Utc).AddTicks(2031), new DateTime(2022, 11, 19, 0, 7, 30, 597, DateTimeKind.Utc).AddTicks(2030) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 19, 0, 7, 30, 597, DateTimeKind.Utc).AddTicks(2053), new DateTime(2022, 11, 19, 0, 7, 30, 597, DateTimeKind.Utc).AddTicks(2052) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BedId", "EndDate", "StartDate" },
                values: new object[] { 3, new DateTime(2022, 11, 19, 0, 7, 30, 597, DateTimeKind.Utc).AddTicks(2059), new DateTime(2022, 11, 19, 0, 7, 30, 597, DateTimeKind.Utc).AddTicks(2058) });
        }
    }
}
