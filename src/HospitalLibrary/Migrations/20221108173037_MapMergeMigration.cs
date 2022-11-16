using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HospitalLibrary.Migrations
{
    public partial class MapMergeMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Rooms",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Bed",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoomId = table.Column<int>(type: "integer", nullable: false),
                    Available = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bed", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bed_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    EquipmentId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<int>(type: "integer", nullable: false),
                    RoomId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.EquipmentId);
                });

            migrationBuilder.CreateTable(
                name: "Forms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    StartHourWorkDay = table.Column<string>(type: "text", nullable: false),
                    EndHourWorkDay = table.Column<string>(type: "text", nullable: false),
                    StartHourSaturday = table.Column<string>(type: "text", nullable: false),
                    EndHourSaturday = table.Column<string>(type: "text", nullable: false),
                    StartHourSunday = table.Column<string>(type: "text", nullable: false),
                    EndHourSunday = table.Column<string>(type: "text", nullable: false),
                    RoomId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MapForms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    StartHourWorkDay = table.Column<string>(type: "text", nullable: false),
                    EndHourWorkDay = table.Column<string>(type: "text", nullable: false),
                    StartHourSaturday = table.Column<string>(type: "text", nullable: false),
                    EndHourSaturday = table.Column<string>(type: "text", nullable: false),
                    StartHourSunday = table.Column<string>(type: "text", nullable: false),
                    EndHourSunday = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MapForms", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "EquipmentId", "Amount", "Name", "RoomId" },
                values: new object[,]
                {
                    { 1, 2, "Krevet", 1 },
                    { 2, 2, "Stetoskop", 1 },
                    { 3, 4, "Stolica", 1 },
                    { 4, 20, "Stolica", 2 },
                    { 5, 2, "Aparat za kafu", 2 },
                    { 6, 4, "Fotelja", 2 },
                    { 7, 2, "Spric za ispiranje usiju", 3 },
                    { 8, 3, "Otoskop", 3 },
                    { 9, 2, "Stetoskop", 4 },
                    { 10, 3, "Bolnicki krevet", 4 },
                    { 11, 2, "Aparat za merenje pritiska", 4 },
                    { 12, 4, "Stolica", 5 },
                    { 13, 50, "Zavoji", 6 },
                    { 14, 24, "Spricevi", 6 },
                    { 15, 12, "Gips", 6 },
                    { 16, 200, "Flasteri", 6 },
                    { 17, 20, "Bolnicki krevet", 7 },
                    { 18, 20, "Infuzija", 7 },
                    { 19, 20, "Stolica", 8 },
                    { 20, 2, "Stetoskop", 9 },
                    { 21, 4, "Stolica", 10 },
                    { 22, 2, "Krevet", 11 },
                    { 23, 2, "Stetoskop", 12 },
                    { 24, 4, "Infuzija", 13 },
                    { 25, 1, "Fotelja", 13 },
                    { 26, 20, "Stolica", 13 }
                });

            migrationBuilder.InsertData(
                table: "Forms",
                columns: new[] { "Id", "Description", "EndHourSaturday", "EndHourSunday", "EndHourWorkDay", "Name", "RoomId", "StartHourSaturday", "StartHourSunday", "StartHourWorkDay" },
                values: new object[,]
                {
                    { 1, "Pregledi za decu", "17:00h", "CLOSED", "17:00h", "101,Pedijatrija", 1, "12:00h", "CLOSED", "10:00h" },
                    { 2, "Opustanje za radnike i posetioce", "17:00h", "CLOSED", "17:00h", "102,Kafeterija", 2, "12:00h", "CLOSED", "10:00h" },
                    { 3, "UHO,GRLO,NOS", "17:00h", "CLOSED", "17:00h", "103,Otorinolaringologija", 3, "12:00h", "CLOSED", "10:00h" },
                    { 4, "Pregled misica i povreda", "17:00h", "CLOSED", "17:00h", "201,Fizioterapeut", 4, "12:00h", "CLOSED", "10:00h" },
                    { 5, "Pregledi za decu", "17:00h", "CLOSED", "17:00h", "202,Stomatologija", 5, "12:00h", "CLOSED", "10:00h" },
                    { 6, "Stanje robe u objektu", "17:00h", "CLOSED", "17:00h", "301,Magacin", 6, "12:00h", "CLOSED", "10:00h" },
                    { 7, "Kreveti i sve potrebno za oporavku", "17:00h", "CLOSED", "17:00h", "302,Opsta nega", 7, "12:00h", "CLOSED", "10:00h" },
                    { 8, "Stolice i fotelje za cekanje", "17:00h", "CLOSED", "17:00h", "303,Cekaonica", 8, "12:00h", "CLOSED", "10:00h" },
                    { 9, "...", "17:00h", "CLOSED", "17:00h", "101a,Kardiologija", 9, "12:00h", "CLOSED", "10:00h" },
                    { 10, "...", "17:00h", "CLOSED", "17:00h", "102a,Vaskularne bolesti", 10, "12:00h", "CLOSED", "10:00h" },
                    { 11, "...,...,...", "17:00h", "CLOSED", "17:00h", "103a,Hirurgija", 11, "12:00h", "CLOSED", "10:00h" },
                    { 12, "... ... ... ...", "17:00h", "CLOSED", "17:00h", "201a,Papirologija", 12, "12:00h", "CLOSED", "10:00h" },
                    { 13, "...", "17:00h", "CLOSED", "17:00h", "202a,Prijavna soba", 13, "12:00h", "CLOSED", "10:00h" },
                    { 14, "...", "17:00h", "CLOSED", "17:00h", "203a,Uplasta/isplata", 14, "12:00h", "CLOSED", "10:00h" },
                    { 15, "...", "17:00h", "CLOSED", "17:00h", "204a,Izgubljeno/nadjeno", 15, "12:00h", "CLOSED", "10:00h" },
                    { 16, "...", "17:00h", "CLOSED", "17:00h", "101b,Onkologija", 16, "12:00h", "CLOSED", "10:00h" },
                    { 17, "...", "17:00h", "CLOSED", "17:00h", "102b,Pedijatrija", 17, "12:00h", "CLOSED", "10:00h" },
                    { 18, "...", "17:00h", "CLOSED", "17:00h", "201b,Gastronomija", 18, "12:00h", "CLOSED", "10:00h" },
                    { 19, "...", "17:00h", "CLOSED", "17:00h", "301b,Magacin", 19, "12:00h", "CLOSED", "10:00h" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bed_RoomId",
                table: "Bed",
                column: "RoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bed");

            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "Forms");

            migrationBuilder.DropTable(
                name: "MapForms");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Rooms");
        }
    }
}
