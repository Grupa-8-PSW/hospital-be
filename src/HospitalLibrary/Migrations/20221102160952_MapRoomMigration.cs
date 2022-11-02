using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalLibrary.Migrations
{
    public partial class MapRoomMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_MapRooms_RoomId",
                table: "MapRooms");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "MapRooms");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Rooms",
                newName: "Color");

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
                columns: new[] { "Color", "FloorId", "Height", "Name", "Width", "Y" },
                values: new object[] { "blue", 1, 140, "Two", 220, 338 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Color", "FloorId", "Height", "Width", "X" },
                values: new object[] { "blue", 1, 180, 300, 237 });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Color", "FloorId", "Height", "Name", "Width", "X", "Y" },
                values: new object[] { 4, "blue", 2, 100, "Tre", 200, 230, 338 });

            migrationBuilder.CreateIndex(
                name: "IX_FloorRoom_RoomsId",
                table: "FloorRoom",
                column: "RoomsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FloorRoom");

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 4);

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

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "MapRooms",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1,
                column: "Number",
                value: "101A");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FloorId", "Name", "Number" },
                values: new object[] { 2, "Too", "204" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FloorId", "Number" },
                values: new object[] { 3, "305B" });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_FloorId",
                table: "Rooms",
                column: "FloorId");

            migrationBuilder.CreateIndex(
                name: "IX_MapRooms_RoomId",
                table: "MapRooms",
                column: "RoomId",
                unique: true);

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
    }
}
