using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalLibrary.Migrations
{
    public partial class addedDoctorSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndWork", "StartWork" },
                values: new object[] { new DateTime(2022, 11, 15, 1, 23, 40, 708, DateTimeKind.Utc).AddTicks(2590), new DateTime(2022, 11, 15, 1, 23, 40, 708, DateTimeKind.Utc).AddTicks(2588) });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "EndWork", "FirstName", "LastName", "RoomId", "StartWork" },
                values: new object[] { 2, new DateTime(2022, 11, 15, 1, 23, 40, 708, DateTimeKind.Utc).AddTicks(2594), "firstNam2", "lastName2", 1, new DateTime(2022, 11, 15, 1, 23, 40, 708, DateTimeKind.Utc).AddTicks(2593) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndWork", "StartWork" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
