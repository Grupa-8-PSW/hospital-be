using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalLibrary.Migrations
{
    public partial class EquipmentsUpdatedMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Equipments",
                newName: "EquipmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EquipmentId",
                table: "Equipments",
                newName: "Id");
        }
    }
}
