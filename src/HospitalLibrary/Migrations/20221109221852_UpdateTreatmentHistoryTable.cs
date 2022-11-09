using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalLibrary.Migrations
{
    public partial class UpdateTreatmentHistoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bed_Rooms_RoomId",
                table: "Bed");

            migrationBuilder.DropForeignKey(
                name: "FK_TreatmentHistories_Bed_BedId",
                table: "TreatmentHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bed",
                table: "Bed");

            migrationBuilder.RenameTable(
                name: "Bed",
                newName: "Beds");

            migrationBuilder.RenameIndex(
                name: "IX_Bed_RoomId",
                table: "Beds",
                newName: "IX_Beds_RoomId");

            migrationBuilder.AddColumn<string>(
                name: "Reason",
                table: "TreatmentHistories",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Beds",
                table: "Beds",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Beds_Rooms_RoomId",
                table: "Beds",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TreatmentHistories_Beds_BedId",
                table: "TreatmentHistories",
                column: "BedId",
                principalTable: "Beds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beds_Rooms_RoomId",
                table: "Beds");

            migrationBuilder.DropForeignKey(
                name: "FK_TreatmentHistories_Beds_BedId",
                table: "TreatmentHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Beds",
                table: "Beds");

            migrationBuilder.DropColumn(
                name: "Reason",
                table: "TreatmentHistories");

            migrationBuilder.RenameTable(
                name: "Beds",
                newName: "Bed");

            migrationBuilder.RenameIndex(
                name: "IX_Beds_RoomId",
                table: "Bed",
                newName: "IX_Bed_RoomId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bed",
                table: "Bed",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bed_Rooms_RoomId",
                table: "Bed",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TreatmentHistories_Bed_BedId",
                table: "TreatmentHistories",
                column: "BedId",
                principalTable: "Bed",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
