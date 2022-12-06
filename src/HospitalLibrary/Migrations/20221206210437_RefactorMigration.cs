using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HospitalLibrary.Migrations
{
    public partial class RefactorMigration : Migration
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
                column: "Number",
                value: "101");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2,
                column: "Number",
                value: "102");

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
                column: "Number",
                value: "301");

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
                column: "Number",
                value: "101a");

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
                column: "Number",
                value: "103a");

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
                column: "Number",
                value: "102b");

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
                column: "Number",
                value: "301b");

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 6, 21, 4, 36, 731, DateTimeKind.Utc).AddTicks(9845), new DateTime(2022, 12, 6, 21, 4, 36, 731, DateTimeKind.Utc).AddTicks(9844) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 6, 21, 4, 36, 731, DateTimeKind.Utc).AddTicks(9848), new DateTime(2022, 12, 6, 21, 4, 36, 731, DateTimeKind.Utc).AddTicks(9848) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 6, 21, 4, 36, 731, DateTimeKind.Utc).AddTicks(9850), new DateTime(2022, 12, 6, 21, 4, 36, 731, DateTimeKind.Utc).AddTicks(9850) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 4,
                column: "StartDate",
                value: new DateTime(2022, 12, 6, 21, 4, 36, 731, DateTimeKind.Utc).AddTicks(9852));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 5,
                column: "StartDate",
                value: new DateTime(2022, 12, 6, 21, 4, 36, 731, DateTimeKind.Utc).AddTicks(9853));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 6,
                column: "StartDate",
                value: new DateTime(2022, 12, 6, 21, 4, 36, 731, DateTimeKind.Utc).AddTicks(9853));

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

            migrationBuilder.DropIndex(
                name: "IX_Rooms_FloorId",
                table: "Rooms");

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
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Color", "Height", "Width" },
                values: new object[] { "blue", 160, 260 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Color", "Height", "Width", "Y" },
                values: new object[] { "blue", 140, 220, 338 });

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
                columns: new[] { "Color", "Height", "Width" },
                values: new object[] { "blue", 180, 260 });

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
                columns: new[] { "Color", "Height", "Width" },
                values: new object[] { "blue", 170, 320 });

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
                columns: new[] { "Color", "Height", "Width", "X" },
                values: new object[] { "blue", 140, 220, 245 });

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
                columns: new[] { "Color", "Height", "Width", "X", "Y" },
                values: new object[] { "blue", 240, 250, 200, 300 });

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
                columns: new[] { "Color", "Height", "Width", "X", "Y" },
                values: new object[] { "blue", 170, 320, 100, 138 });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 6, 20, 6, 57, 831, DateTimeKind.Utc).AddTicks(8509), new DateTime(2022, 12, 6, 20, 6, 57, 831, DateTimeKind.Utc).AddTicks(8508) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 6, 20, 6, 57, 831, DateTimeKind.Utc).AddTicks(8513), new DateTime(2022, 12, 6, 20, 6, 57, 831, DateTimeKind.Utc).AddTicks(8513) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 6, 20, 6, 57, 831, DateTimeKind.Utc).AddTicks(8515), new DateTime(2022, 12, 6, 20, 6, 57, 831, DateTimeKind.Utc).AddTicks(8514) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 4,
                column: "StartDate",
                value: new DateTime(2022, 12, 6, 20, 6, 57, 831, DateTimeKind.Utc).AddTicks(8515));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 5,
                column: "StartDate",
                value: new DateTime(2022, 12, 6, 20, 6, 57, 831, DateTimeKind.Utc).AddTicks(8516));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 6,
                column: "StartDate",
                value: new DateTime(2022, 12, 6, 20, 6, 57, 831, DateTimeKind.Utc).AddTicks(8517));

            migrationBuilder.CreateIndex(
                name: "IX_FloorRoom_RoomsId",
                table: "FloorRoom",
                column: "RoomsId");
        }
    }
}
