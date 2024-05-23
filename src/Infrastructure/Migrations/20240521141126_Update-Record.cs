using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRecord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HealthRecords_Users_UserId",
                table: "HealthRecords");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "HealthRecords",
                newName: "PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_HealthRecords_UserId",
                table: "HealthRecords",
                newName: "IX_HealthRecords_PatientId");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "$2a$11$iAAZfw4qWmcWb8cZFiEjkuwBZo2nkoWQ2R6z9EXTjdwJm949drB0i",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "$2a$11$qbHG/j5i/dcFfbhoOniLJOgIJihDcWeX1H3W7aRAI0x3/knX/Vg2G");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "TreatmentDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DoctorId",
                table: "HealthRecords",
                type: "varchar(36)",
                maxLength: 36,
                nullable: false,
                defaultValueSql: "NEWID()");

            migrationBuilder.CreateIndex(
                name: "IX_HealthRecords_DoctorId",
                table: "HealthRecords",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_HealthRecords_Users_DoctorId",
                table: "HealthRecords",
                column: "DoctorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HealthRecords_Users_PatientId",
                table: "HealthRecords",
                column: "PatientId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HealthRecords_Users_DoctorId",
                table: "HealthRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_HealthRecords_Users_PatientId",
                table: "HealthRecords");

            migrationBuilder.DropIndex(
                name: "IX_HealthRecords_DoctorId",
                table: "HealthRecords");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "TreatmentDetails");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "HealthRecords");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "HealthRecords",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_HealthRecords_PatientId",
                table: "HealthRecords",
                newName: "IX_HealthRecords_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "$2a$11$qbHG/j5i/dcFfbhoOniLJOgIJihDcWeX1H3W7aRAI0x3/knX/Vg2G",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "$2a$11$iAAZfw4qWmcWb8cZFiEjkuwBZo2nkoWQ2R6z9EXTjdwJm949drB0i");

            migrationBuilder.AddForeignKey(
                name: "FK_HealthRecords_Users_UserId",
                table: "HealthRecords",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
