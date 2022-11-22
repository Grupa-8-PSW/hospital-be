using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HospitalLibrary.Migrations
{
    public partial class BloodUnitReqUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bed_Rooms_RoomId",
                table: "Bed");

            migrationBuilder.DropForeignKey(
                name: "FK_Therapy_Doctors_DoctorId",
                table: "Therapy");

            migrationBuilder.DropForeignKey(
                name: "FK_Therapy_TreatmentHistories_TreatmentHistoryId",
                table: "Therapy");

            migrationBuilder.DropForeignKey(
                name: "FK_TreatmentHistories_Bed_BedId",
                table: "TreatmentHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Therapy",
                table: "Therapy");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bed",
                table: "Bed");

            migrationBuilder.DropColumn(
                name: "BloodType",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Pin",
                table: "Patients");

            migrationBuilder.RenameTable(
                name: "Therapy",
                newName: "Therapies");

            migrationBuilder.RenameTable(
                name: "Bed",
                newName: "Beds");

            migrationBuilder.RenameColumn(
                name: "PrescribedId",
                table: "Therapies",
                newName: "TherapyType");

            migrationBuilder.RenameIndex(
                name: "IX_Therapy_TreatmentHistoryId",
                table: "Therapies",
                newName: "IX_Therapies_TreatmentHistoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Therapy_DoctorId",
                table: "Therapies",
                newName: "IX_Therapies_DoctorId");

            migrationBuilder.RenameIndex(
                name: "IX_Bed_RoomId",
                table: "Beds",
                newName: "IX_Beds_RoomId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "TreatmentHistories",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<string>(
                name: "Reason",
                table: "TreatmentHistories",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TreatmentHistoryId",
                table: "Therapies",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TherapySubject",
                table: "Therapies",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Therapies",
                table: "Therapies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Beds",
                table: "Beds",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Bloods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bloods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BloodUnitRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    AmountL = table.Column<int>(type: "integer", nullable: false),
                    Reason = table.Column<string>(type: "text", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DoctorId = table.Column<int>(type: "integer", nullable: false),
                    ManagerComment = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodUnitRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BloodUnitRequests_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BloodUnits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DatePrescribed = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    BloodType = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodUnits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicalDrugs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalDrugs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Beds",
                columns: new[] { "Id", "Available", "RoomId" },
                values: new object[,]
                {
                    { 1, true, 1 },
                    { 2, true, 1 },
                    { 3, false, 2 },
                    { 4, true, 2 },
                    { 5, false, 3 },
                    { 6, false, 3 }
                });

            migrationBuilder.InsertData(
                table: "Bloods",
                columns: new[] { "Id", "Quantity", "Type" },
                values: new object[,]
                {
                    { 1, 100, 0 },
                    { 2, 100, 1 },
                    { 3, 100, 2 },
                    { 4, 100, 3 },
                    { 5, 100, 4 },
                    { 6, 100, 5 },
                    { 7, 100, 6 },
                    { 8, 100, 7 }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "EndWork", "FirstName", "LastName", "RoomId", "StartWork" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 11, 22, 11, 5, 24, 359, DateTimeKind.Utc).AddTicks(1130), "firstName", "lastName", 1, new DateTime(2022, 11, 22, 11, 5, 24, 359, DateTimeKind.Utc).AddTicks(1129) },
                    { 2, new DateTime(2022, 11, 22, 11, 5, 24, 359, DateTimeKind.Utc).AddTicks(1164), "firstNam2", "lastName2", 1, new DateTime(2022, 11, 22, 11, 5, 24, 359, DateTimeKind.Utc).AddTicks(1164) }
                });

            migrationBuilder.InsertData(
                table: "MedicalDrugs",
                columns: new[] { "Id", "Amount", "Code", "Name" },
                values: new object[] { 1, 0, "Code1", "Drugs1" });

            migrationBuilder.InsertData(
                table: "TreatmentHistories",
                columns: new[] { "Id", "Active", "BedId", "DischargeReason", "EndDate", "PatientId", "Reason", "StartDate" },
                values: new object[,]
                {
                    { 1, true, 1, "abc", new DateTime(2022, 11, 22, 11, 5, 24, 359, DateTimeKind.Utc).AddTicks(1195), 1, null, new DateTime(2022, 11, 22, 11, 5, 24, 359, DateTimeKind.Utc).AddTicks(1195) },
                    { 2, true, 2, "abc", new DateTime(2022, 11, 22, 11, 5, 24, 359, DateTimeKind.Utc).AddTicks(1200), 2, null, new DateTime(2022, 11, 22, 11, 5, 24, 359, DateTimeKind.Utc).AddTicks(1200) },
                    { 3, true, 3, "abc", new DateTime(2022, 11, 22, 11, 5, 24, 359, DateTimeKind.Utc).AddTicks(1201), 3, null, new DateTime(2022, 11, 22, 11, 5, 24, 359, DateTimeKind.Utc).AddTicks(1201) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bloods_Type",
                table: "Bloods",
                column: "Type",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BloodUnitRequests_DoctorId",
                table: "BloodUnitRequests",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalDrugs_Code",
                table: "MedicalDrugs",
                column: "Code",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Beds_Rooms_RoomId",
                table: "Beds",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Therapies_Doctors_DoctorId",
                table: "Therapies",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Therapies_TreatmentHistories_TreatmentHistoryId",
                table: "Therapies",
                column: "TreatmentHistoryId",
                principalTable: "TreatmentHistories",
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
                name: "FK_Therapies_Doctors_DoctorId",
                table: "Therapies");

            migrationBuilder.DropForeignKey(
                name: "FK_Therapies_TreatmentHistories_TreatmentHistoryId",
                table: "Therapies");

            migrationBuilder.DropForeignKey(
                name: "FK_TreatmentHistories_Beds_BedId",
                table: "TreatmentHistories");

            migrationBuilder.DropTable(
                name: "Bloods");

            migrationBuilder.DropTable(
                name: "BloodUnitRequests");

            migrationBuilder.DropTable(
                name: "BloodUnits");

            migrationBuilder.DropTable(
                name: "MedicalDrugs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Therapies",
                table: "Therapies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Beds",
                table: "Beds");

            migrationBuilder.DeleteData(
                table: "Beds",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Beds",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Beds",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TreatmentHistories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Beds",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Beds",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Beds",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Reason",
                table: "TreatmentHistories");

            migrationBuilder.DropColumn(
                name: "TherapySubject",
                table: "Therapies");

            migrationBuilder.RenameTable(
                name: "Therapies",
                newName: "Therapy");

            migrationBuilder.RenameTable(
                name: "Beds",
                newName: "Bed");

            migrationBuilder.RenameColumn(
                name: "TherapyType",
                table: "Therapy",
                newName: "PrescribedId");

            migrationBuilder.RenameIndex(
                name: "IX_Therapies_TreatmentHistoryId",
                table: "Therapy",
                newName: "IX_Therapy_TreatmentHistoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Therapies_DoctorId",
                table: "Therapy",
                newName: "IX_Therapy_DoctorId");

            migrationBuilder.RenameIndex(
                name: "IX_Beds_RoomId",
                table: "Bed",
                newName: "IX_Bed_RoomId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "TreatmentHistories",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BloodType",
                table: "Patients",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Patients",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Patients",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Pin",
                table: "Patients",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "TreatmentHistoryId",
                table: "Therapy",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Therapy",
                table: "Therapy",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bed",
                table: "Bed",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Pin" },
                values: new object[] { "peraperic@gmail.com", "2201000120492" });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BloodType", "Email", "Pin" },
                values: new object[] { 7, "markomarkovic@gmail.com", "1412995012451" });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BloodType", "Email", "Pin" },
                values: new object[] { 5, "dusanbaljinac@gmail.com", "2008004124293" });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BloodType", "Email", "Pin" },
                values: new object[] { 3, "slobodanradulovic@gmail.com", "1111978020204" });

            migrationBuilder.AddForeignKey(
                name: "FK_Bed_Rooms_RoomId",
                table: "Bed",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Therapy_Doctors_DoctorId",
                table: "Therapy",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Therapy_TreatmentHistories_TreatmentHistoryId",
                table: "Therapy",
                column: "TreatmentHistoryId",
                principalTable: "TreatmentHistories",
                principalColumn: "Id");

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
