using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalLibrary.Migrations
{
    public partial class MapFixRelationshipMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Floor_Buildings_BuildingId",
                table: "Floor");

            migrationBuilder.DropForeignKey(
                name: "FK_Room_Floor_FloorId",
                table: "Room");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Room",
                table: "Room");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Floor",
                table: "Floor");

            migrationBuilder.RenameTable(
                name: "Room",
                newName: "Rooms");

            migrationBuilder.RenameTable(
                name: "Floor",
                newName: "Floors");

            migrationBuilder.RenameIndex(
                name: "IX_Room_FloorId",
                table: "Rooms",
                newName: "IX_Rooms_FloorId");

            migrationBuilder.RenameIndex(
                name: "IX_Floor_BuildingId",
                table: "Floors",
                newName: "IX_Floors_BuildingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Floors",
                table: "Floors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Floors_Buildings_BuildingId",
                table: "Floors",
                column: "BuildingId",
                principalTable: "Buildings",
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
                name: "FK_Floors_Buildings_BuildingId",
                table: "Floors");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Floors_FloorId",
                table: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Floors",
                table: "Floors");

            migrationBuilder.RenameTable(
                name: "Rooms",
                newName: "Room");

            migrationBuilder.RenameTable(
                name: "Floors",
                newName: "Floor");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_FloorId",
                table: "Room",
                newName: "IX_Room_FloorId");

            migrationBuilder.RenameIndex(
                name: "IX_Floors_BuildingId",
                table: "Floor",
                newName: "IX_Floor_BuildingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Room",
                table: "Room",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Floor",
                table: "Floor",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Floor_Buildings_BuildingId",
                table: "Floor",
                column: "BuildingId",
                principalTable: "Buildings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Room_Floor_FloorId",
                table: "Room",
                column: "FloorId",
                principalTable: "Floor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
