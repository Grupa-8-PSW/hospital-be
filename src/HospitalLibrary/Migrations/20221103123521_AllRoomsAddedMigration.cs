using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalLibrary.Migrations
{
    public partial class AllRoomsAddedMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Pedijatrija");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Kafeterija");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Otorinolaringologija");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Name", "X", "Y" },
                values: new object[] { "Fizioterapeut", 270, 378 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Stomatologija");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Magacin");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Name", "Y" },
                values: new object[] { "Opsta nega", 338 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "FloorId", "Name", "X", "Y" },
                values: new object[] { 3, "Cekaonica", 330, 158 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "FloorId", "Height", "Name", "Width", "Y" },
                values: new object[] { 4, 170, "Kardiologija", 320, 0 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "FloorId", "Name", "Y" },
                values: new object[] { 4, "Vaskularne bolesti", 365 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "FloorId", "Name", "X", "Y" },
                values: new object[] { 4, "Hirurgija", 245, 0 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "FloorId", "Name", "Y" },
                values: new object[] { 5, "Papirologija", 0 });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Color", "FloorId", "Height", "Name", "Width", "X", "Y" },
                values: new object[,]
                {
                    { 13, "blue", 5, 140, "Prijavna soba", 220, 200, 0 },
                    { 14, "blue", 5, 140, "Uplasta/isplata", 220, 0, 350 },
                    { 15, "blue", 5, 140, "Izgubljeno/nadjeno", 220, 200, 350 },
                    { 16, "blue", 6, 190, "Onkologija", 320, 0, 0 },
                    { 17, "blue", 6, 240, "Onkologija", 250, 200, 300 },
                    { 18, "blue", 7, 280, "Gastronomija", 420, 50, 100 },
                    { 19, "blue", 8, 170, "Magacin", 320, 100, 138 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "One");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Two");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Thre");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Name", "X", "Y" },
                values: new object[] { "Four", 230, 338 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Five");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Six");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Name", "Y" },
                values: new object[] { "Seven", 138 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "FloorId", "Name", "X", "Y" },
                values: new object[] { 4, "Seven", 0, 138 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "FloorId", "Height", "Name", "Width", "Y" },
                values: new object[] { 5, 140, "Seven", 220, 138 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "FloorId", "Name", "Y" },
                values: new object[] { 6, "Seven", 138 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "FloorId", "Name", "X", "Y" },
                values: new object[] { 7, "Seven", 0, 138 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "FloorId", "Name", "Y" },
                values: new object[] { 8, "Seven", 138 });
        }
    }
}
