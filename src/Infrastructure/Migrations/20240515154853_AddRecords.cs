using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRecords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "$2a$11$8YoxOgTH3nlX26rXlgJrK.ekAQez1MwjdPAz/6qd.dX0QrSqy8XEK",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "$2a$11$F/3u7NG5Dsekul/yNmEnie9nv7y/nHeYUONi9iHKb0nph733WsYEu");

            migrationBuilder.CreateTable(
                name: "HealthRecords",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false, defaultValueSql: "NEWID()"),
                    BirthDay = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    BloodPressure = table.Column<int>(type: "int", nullable: false),
                    Temperature = table.Column<int>(type: "int", nullable: false),
                    HeartBeat = table.Column<int>(type: "int", nullable: false),
                    Anamnesis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Diagnosis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false, defaultValueSql: "NEWID()"),
                    Enable = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HealthRecords_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HealthRecords_UserId",
                table: "HealthRecords",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HealthRecords");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "$2a$11$F/3u7NG5Dsekul/yNmEnie9nv7y/nHeYUONi9iHKb0nph733WsYEu",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "$2a$11$8YoxOgTH3nlX26rXlgJrK.ekAQez1MwjdPAz/6qd.dX0QrSqy8XEK");
        }
    }
}
