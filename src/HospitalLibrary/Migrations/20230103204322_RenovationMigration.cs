using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HospitalLibrary.Migrations
{
    public partial class RenovationMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "EquipmentTransfers",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Renovation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoomId = table.Column<int>(type: "integer", nullable: false),
                    DateRange_Start = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateRange_End = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Renovation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Renovation_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Renovation_RoomId",
                table: "Renovation",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentTransfers_Rooms_RoomId",
                table: "EquipmentTransfers",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentTransfers_Rooms_RoomId",
                table: "EquipmentTransfers");

            migrationBuilder.DropTable(
                name: "Renovation");

            migrationBuilder.DropIndex(
                name: "IX_EquipmentTransfers_RoomId",
                table: "EquipmentTransfers");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "EquipmentTransfers");

            migrationBuilder.UpdateData(
                table: "Therapies",
                keyColumn: "Id",
                keyValue: 1,
                column: "WhenPrescribed",
                value: new DateTime(2022, 12, 29, 13, 17, 11, 643, DateTimeKind.Utc).AddTicks(8548));

            migrationBuilder.UpdateData(
                table: "Therapies",
                keyColumn: "Id",
                keyValue: 2,
                column: "WhenPrescribed",
                value: new DateTime(2022, 12, 29, 13, 17, 11, 643, DateTimeKind.Utc).AddTicks(8550));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 29, 13, 17, 11, 643, DateTimeKind.Utc).AddTicks(8497), new DateTime(2022, 12, 29, 13, 17, 11, 643, DateTimeKind.Utc).AddTicks(8496) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 29, 13, 17, 11, 643, DateTimeKind.Utc).AddTicks(8501), new DateTime(2022, 12, 29, 13, 17, 11, 643, DateTimeKind.Utc).AddTicks(8501) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 29, 13, 17, 11, 643, DateTimeKind.Utc).AddTicks(8502), new DateTime(2022, 12, 29, 13, 17, 11, 643, DateTimeKind.Utc).AddTicks(8502) });

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 4,
                column: "StartDate",
                value: new DateTime(2022, 12, 29, 13, 17, 11, 643, DateTimeKind.Utc).AddTicks(8503));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 5,
                column: "StartDate",
                value: new DateTime(2022, 12, 29, 13, 17, 11, 643, DateTimeKind.Utc).AddTicks(8504));

            migrationBuilder.UpdateData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 6,
                column: "StartDate",
                value: new DateTime(2022, 12, 29, 13, 17, 11, 643, DateTimeKind.Utc).AddTicks(8505));
        }
    }
}
