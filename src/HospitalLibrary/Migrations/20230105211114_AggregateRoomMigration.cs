using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalLibrary.Migrations
{
    public partial class AggregateRoomMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentTransfers_Rooms_RoomId",
                table: "EquipmentTransfers");

            migrationBuilder.DropForeignKey(
                name: "FK_Renovation_Rooms_RoomId",
                table: "Renovation");

            migrationBuilder.DropIndex(
                name: "IX_EquipmentTransfers_RoomId",
                table: "EquipmentTransfers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Renovation",
                table: "Renovation");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "EquipmentTransfers");

            migrationBuilder.RenameTable(
                name: "Renovation",
                newName: "Renovations");

            migrationBuilder.RenameColumn(
                name: "EquipmentId",
                table: "Equipments",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Renovation_RoomId",
                table: "Renovations",
                newName: "IX_Renovations_RoomId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Renovations",
                table: "Renovations",
                column: "Id");

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
                name: "IX_Equipments_RoomId",
                table: "Equipments",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_Rooms_RoomId",
                table: "Equipments",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Renovations_Rooms_RoomId",
                table: "Renovations",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_Rooms_RoomId",
                table: "Equipments");

            migrationBuilder.DropForeignKey(
                name: "FK_Renovations_Rooms_RoomId",
                table: "Renovations");

            migrationBuilder.DropIndex(
                name: "IX_Equipments_RoomId",
                table: "Equipments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Renovations",
                table: "Renovations");

            migrationBuilder.RenameTable(
                name: "Renovations",
                newName: "Renovation");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Equipments",
                newName: "EquipmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Renovations_RoomId",
                table: "Renovation",
                newName: "IX_Renovation_RoomId");

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "EquipmentTransfers",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Renovation",
                table: "Renovation",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Therapies",
                keyColumn: "Id",
                keyValue: 1,
                column: "WhenPrescribed",
                value: new DateTime(2023, 1, 3, 20, 43, 21, 836, DateTimeKind.Utc).AddTicks(4441));

            migrationBuilder.UpdateData(
                table: "Therapies",
                keyColumn: "Id",
                keyValue: 2,
                column: "WhenPrescribed",
                value: new DateTime(2023, 1, 3, 20, 43, 21, 836, DateTimeKind.Utc).AddTicks(4443));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 1, 3, 20, 43, 21, 836, DateTimeKind.Utc).AddTicks(4392), new DateTime(2023, 1, 3, 20, 43, 21, 836, DateTimeKind.Utc).AddTicks(4391) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 1, 3, 20, 43, 21, 836, DateTimeKind.Utc).AddTicks(4396), new DateTime(2023, 1, 3, 20, 43, 21, 836, DateTimeKind.Utc).AddTicks(4395) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 1, 3, 20, 43, 21, 836, DateTimeKind.Utc).AddTicks(4397), new DateTime(2023, 1, 3, 20, 43, 21, 836, DateTimeKind.Utc).AddTicks(4397) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 4,
                column: "StartDate",
                value: new DateTime(2023, 1, 3, 20, 43, 21, 836, DateTimeKind.Utc).AddTicks(4398));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 5,
                column: "StartDate",
                value: new DateTime(2023, 1, 3, 20, 43, 21, 836, DateTimeKind.Utc).AddTicks(4399));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 6,
                column: "StartDate",
                value: new DateTime(2023, 1, 3, 20, 43, 21, 836, DateTimeKind.Utc).AddTicks(4400));

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentTransfers_RoomId",
                table: "EquipmentTransfers",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentTransfers_Rooms_RoomId",
                table: "EquipmentTransfers",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Renovation_Rooms_RoomId",
                table: "Renovation",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
