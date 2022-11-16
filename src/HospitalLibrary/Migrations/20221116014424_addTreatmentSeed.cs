using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalLibrary.Migrations
{
    public partial class addTreatmentSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Therapies_TreatmentHistories_TreatmentHistoryId",
                table: "Therapies");

            migrationBuilder.AlterColumn<string>(
                name: "Reason",
                table: "TreatmentHistories",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "TreatmentHistoryId",
                table: "Therapies",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndWork", "StartWork" },
                values: new object[] { new DateTime(2022, 11, 16, 1, 44, 22, 327, DateTimeKind.Utc).AddTicks(436), new DateTime(2022, 11, 16, 1, 44, 22, 327, DateTimeKind.Utc).AddTicks(433) });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndWork", "StartWork" },
                values: new object[] { new DateTime(2022, 11, 16, 1, 44, 22, 327, DateTimeKind.Utc).AddTicks(439), new DateTime(2022, 11, 16, 1, 44, 22, 327, DateTimeKind.Utc).AddTicks(438) });

            migrationBuilder.AddForeignKey(
                name: "FK_Therapies_TreatmentHistories_TreatmentHistoryId",
                table: "Therapies",
                column: "TreatmentHistoryId",
                principalTable: "TreatmentHistories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Therapies_TreatmentHistories_TreatmentHistoryId",
                table: "Therapies");

            migrationBuilder.AlterColumn<string>(
                name: "Reason",
                table: "TreatmentHistories",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TreatmentHistoryId",
                table: "Therapies",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndWork", "StartWork" },
                values: new object[] { new DateTime(2022, 11, 15, 1, 23, 40, 708, DateTimeKind.Utc).AddTicks(2590), new DateTime(2022, 11, 15, 1, 23, 40, 708, DateTimeKind.Utc).AddTicks(2588) });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndWork", "StartWork" },
                values: new object[] { new DateTime(2022, 11, 15, 1, 23, 40, 708, DateTimeKind.Utc).AddTicks(2594), new DateTime(2022, 11, 15, 1, 23, 40, 708, DateTimeKind.Utc).AddTicks(2593) });

            migrationBuilder.AddForeignKey(
                name: "FK_Therapies_TreatmentHistories_TreatmentHistoryId",
                table: "Therapies",
                column: "TreatmentHistoryId",
                principalTable: "TreatmentHistories",
                principalColumn: "Id");
        }
    }
}
