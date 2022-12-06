using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HospitalLibrary.Migrations
{
    public partial class MergeRefactorMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FloorRoom");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "X",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Y",
                table: "Rooms");

            migrationBuilder.RenameColumn(
                name: "Color",
                table: "Rooms",
                newName: "Number");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "MapRooms",
                newName: "RoomId");

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "MapRooms",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateTable(
                name: "EquipmentTransfers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Amount = table.Column<int>(type: "integer", nullable: false),
                    FromRoomId = table.Column<int>(type: "integer", nullable: false),
                    ToRoomId = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: false),
                    EquipmentName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentTransfers", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndWork", "FirstName", "LastName", "StartWork" },
                values: new object[] { new DateTime(2022, 11, 22, 18, 10, 10, 0, DateTimeKind.Utc), "Pera", "Peric", new DateTime(2022, 11, 22, 10, 10, 10, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndWork", "FirstName", "LastName", "RoomId", "StartWork" },
                values: new object[] { new DateTime(2022, 11, 22, 19, 10, 10, 0, DateTimeKind.Utc), "Sergej", "Milinkovic-Savic", 1, new DateTime(2022, 11, 22, 10, 10, 10, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Examinations",
                columns: new[] { "Id", "DoctorId", "Duration", "PatientId", "RoomId", "StartTime" },
                values: new object[,]
                {
                    { 1, 1, 300, 1, 1, new DateTime(2022, 11, 22, 2, 0, 0, 0, DateTimeKind.Utc) },
                    { 2, 2, 120, 2, 2, new DateTime(2022, 11, 22, 7, 30, 0, 0, DateTimeKind.Utc) },
                    { 3, 1, 420, 3, 1, new DateTime(2022, 11, 22, 11, 30, 0, 0, DateTimeKind.Utc) },
                    { 4, 2, 150, 4, 2, new DateTime(2022, 11, 22, 20, 30, 0, 0, DateTimeKind.Utc) }
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

            migrationBuilder.InsertData(
                table: "MapRooms",
                columns: new[] { "RoomId", "Color", "Height", "Width", "X", "Y" },
                values: new object[,]
                {
                    { 1, "blue", 160, 260, 0, 0 },
                    { 2, "blue", 140, 220, 0, 338 },
                    { 3, "blue", 180, 300, 237, 0 },
                    { 4, "blue", 100, 200, 270, 378 },
                    { 5, "blue", 180, 360, 0, 0 },
                    { 6, "blue", 180, 260, 0, 0 },
                    { 7, "blue", 140, 220, 0, 338 },
                    { 8, "blue", 140, 220, 330, 158 },
                    { 9, "blue", 170, 320, 0, 0 },
                    { 10, "blue", 140, 220, 0, 365 },
                    { 11, "blue", 140, 220, 245, 0 },
                    { 12, "blue", 140, 220, 0, 0 },
                    { 13, "blue", 140, 220, 200, 0 },
                    { 14, "blue", 140, 220, 0, 350 },
                    { 15, "blue", 140, 220, 200, 350 },
                    { 16, "blue", 190, 320, 0, 0 },
                    { 17, "blue", 240, 250, 200, 300 },
                    { 18, "blue", 280, 420, 50, 100 },
                    { 19, "blue", 170, 320, 100, 138 }
                });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "Number", "Type" },
                values: new object[] { "Neurohirurgija", "101", 3 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Number", "Type" },
                values: new object[] { "102", 2 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3,
                column: "Number",
                value: "103");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 4,
                column: "Number",
                value: "201");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 5,
                column: "Number",
                value: "202");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Number", "Type" },
                values: new object[] { "301", 4 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 7,
                column: "Number",
                value: "302");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 8,
                column: "Number",
                value: "303");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Number", "Type" },
                values: new object[] { "101a", 3 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 10,
                column: "Number",
                value: "102a");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Number", "Type" },
                values: new object[] { "103a", 3 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 12,
                column: "Number",
                value: "201a");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 13,
                column: "Number",
                value: "202a");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 14,
                column: "Number",
                value: "203a");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 15,
                column: "Number",
                value: "204a");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 16,
                column: "Number",
                value: "101b");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Name", "Number", "Type" },
                values: new object[] { "Endokrinologija", "102b", 3 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 18,
                column: "Number",
                value: "201b");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Number", "Type" },
                values: new object[] { "301b", 4 });

            migrationBuilder.UpdateData(
                table: "Therapies",
                keyColumn: "Id",
                keyValue: 1,
                column: "WhenPrescribed",
                value: new DateTime(2022, 12, 6, 22, 57, 58, 982, DateTimeKind.Utc).AddTicks(4529));

            migrationBuilder.UpdateData(
                table: "Therapies",
                keyColumn: "Id",
                keyValue: 2,
                column: "WhenPrescribed",
                value: new DateTime(2022, 12, 6, 22, 57, 58, 982, DateTimeKind.Utc).AddTicks(4530));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 6, 22, 57, 58, 982, DateTimeKind.Utc).AddTicks(4484), new DateTime(2022, 12, 6, 22, 57, 58, 982, DateTimeKind.Utc).AddTicks(4483) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 6, 22, 57, 58, 982, DateTimeKind.Utc).AddTicks(4488), new DateTime(2022, 12, 6, 22, 57, 58, 982, DateTimeKind.Utc).AddTicks(4488) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 6, 22, 57, 58, 982, DateTimeKind.Utc).AddTicks(4489), new DateTime(2022, 12, 6, 22, 57, 58, 982, DateTimeKind.Utc).AddTicks(4489) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 4,
                column: "StartDate",
                value: new DateTime(2022, 12, 6, 22, 57, 58, 982, DateTimeKind.Utc).AddTicks(4490));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 5,
                column: "StartDate",
                value: new DateTime(2022, 12, 6, 22, 57, 58, 982, DateTimeKind.Utc).AddTicks(4491));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 6,
                column: "StartDate",
                value: new DateTime(2022, 12, 6, 22, 57, 58, 982, DateTimeKind.Utc).AddTicks(4492));

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_FloorId",
                table: "Rooms",
                column: "FloorId");

            migrationBuilder.AddForeignKey(
                name: "FK_MapRooms_Rooms_RoomId",
                table: "MapRooms",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Floors_FloorId",
                table: "Rooms",
                column: "FloorId",
                principalTable: "Floors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MapRooms_Rooms_RoomId",
                table: "MapRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Floors_FloorId",
                table: "Rooms");

            migrationBuilder.DropTable(
                name: "EquipmentTransfers");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_FloorId",
                table: "Rooms");

            migrationBuilder.DeleteData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MapRooms",
                keyColumn: "RoomId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MapRooms",
                keyColumn: "RoomId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MapRooms",
                keyColumn: "RoomId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MapRooms",
                keyColumn: "RoomId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MapRooms",
                keyColumn: "RoomId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MapRooms",
                keyColumn: "RoomId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MapRooms",
                keyColumn: "RoomId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "MapRooms",
                keyColumn: "RoomId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "MapRooms",
                keyColumn: "RoomId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "MapRooms",
                keyColumn: "RoomId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "MapRooms",
                keyColumn: "RoomId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "MapRooms",
                keyColumn: "RoomId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "MapRooms",
                keyColumn: "RoomId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "MapRooms",
                keyColumn: "RoomId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "MapRooms",
                keyColumn: "RoomId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "MapRooms",
                keyColumn: "RoomId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "MapRooms",
                keyColumn: "RoomId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "MapRooms",
                keyColumn: "RoomId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "MapRooms",
                keyColumn: "RoomId",
                keyValue: 19);

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Rooms",
                newName: "Color");

            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "MapRooms",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "Height",
                table: "Rooms",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Width",
                table: "Rooms",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "X",
                table: "Rooms",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Y",
                table: "Rooms",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "MapRooms",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateTable(
                name: "FloorRoom",
                columns: table => new
                {
                    FloorsId = table.Column<int>(type: "integer", nullable: false),
                    RoomsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FloorRoom", x => new { x.FloorsId, x.RoomsId });
                    table.ForeignKey(
                        name: "FK_FloorRoom_Floors_FloorsId",
                        column: x => x.FloorsId,
                        principalTable: "Floors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FloorRoom_Rooms_RoomsId",
                        column: x => x.RoomsId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                columns: new[] { "Color", "Height", "Name", "Type", "Width" },
                values: new object[] { "blue", 160, "Pedijatrija", 0, 260 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Color", "Height", "Type", "Width", "Y" },
                values: new object[] { "blue", 140, 0, 220, 338 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Color", "Height", "Width", "X" },
                values: new object[] { "blue", 180, 300, 237 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Color", "Height", "Width", "X", "Y" },
                values: new object[] { "blue", 100, 200, 270, 378 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Color", "Height", "Width" },
                values: new object[] { "blue", 180, 360 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Color", "Height", "Type", "Width" },
                values: new object[] { "blue", 180, 0, 260 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Color", "Height", "Width", "Y" },
                values: new object[] { "blue", 140, 220, 338 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Color", "Height", "Width", "X", "Y" },
                values: new object[] { "blue", 140, 220, 330, 158 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Color", "Height", "Type", "Width" },
                values: new object[] { "blue", 170, 0, 320 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Color", "Height", "Width", "Y" },
                values: new object[] { "blue", 140, 220, 365 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Color", "Height", "Type", "Width", "X" },
                values: new object[] { "blue", 140, 0, 220, 245 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Color", "Height", "Width" },
                values: new object[] { "blue", 140, 220 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Color", "Height", "Width", "X" },
                values: new object[] { "blue", 140, 220, 200 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Color", "Height", "Width", "Y" },
                values: new object[] { "blue", 140, 220, 350 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Color", "Height", "Width", "X", "Y" },
                values: new object[] { "blue", 140, 220, 200, 350 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Color", "Height", "Width" },
                values: new object[] { "blue", 190, 320 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Color", "Height", "Name", "Type", "Width", "X", "Y" },
                values: new object[] { "blue", 240, "Onkologija", 0, 250, 200, 300 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Color", "Height", "Width", "X", "Y" },
                values: new object[] { "blue", 280, 420, 50, 100 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Color", "Height", "Type", "Width", "X", "Y" },
                values: new object[] { "blue", 170, 0, 320, 100, 138 });

            migrationBuilder.UpdateData(
                table: "Therapies",
                keyColumn: "Id",
                keyValue: 1,
                column: "WhenPrescribed",
                value: new DateTime(2022, 12, 6, 11, 36, 22, 933, DateTimeKind.Utc).AddTicks(3006));

            migrationBuilder.UpdateData(
                table: "Therapies",
                keyColumn: "Id",
                keyValue: 2,
                column: "WhenPrescribed",
                value: new DateTime(2022, 12, 6, 11, 36, 22, 933, DateTimeKind.Utc).AddTicks(3007));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 6, 11, 36, 22, 933, DateTimeKind.Utc).AddTicks(2975), new DateTime(2022, 12, 6, 11, 36, 22, 933, DateTimeKind.Utc).AddTicks(2974) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 6, 11, 36, 22, 933, DateTimeKind.Utc).AddTicks(2978), new DateTime(2022, 12, 6, 11, 36, 22, 933, DateTimeKind.Utc).AddTicks(2978) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 6, 11, 36, 22, 933, DateTimeKind.Utc).AddTicks(2979), new DateTime(2022, 12, 6, 11, 36, 22, 933, DateTimeKind.Utc).AddTicks(2979) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 4,
                column: "StartDate",
                value: new DateTime(2022, 12, 6, 11, 36, 22, 933, DateTimeKind.Utc).AddTicks(2980));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 5,
                column: "StartDate",
                value: new DateTime(2022, 12, 6, 11, 36, 22, 933, DateTimeKind.Utc).AddTicks(2980));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 6,
                column: "StartDate",
                value: new DateTime(2022, 12, 6, 11, 36, 22, 933, DateTimeKind.Utc).AddTicks(2981));

            migrationBuilder.CreateIndex(
                name: "IX_FloorRoom_RoomsId",
                table: "FloorRoom",
                column: "RoomsId");
        }
    }
}
