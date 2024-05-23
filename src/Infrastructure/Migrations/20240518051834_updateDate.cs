using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "$2a$11$y06db5WGD0EBfI59j5RszujKkEDBRAUf7m2JjIBTv5RC70MdIj8d.",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "$2a$11$Ok2ynAwQ4jalXcBwcA7MtedAhMOdsXl1BZ50oTSbIPse15zT.clX2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Schedules",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "$2a$11$Ok2ynAwQ4jalXcBwcA7MtedAhMOdsXl1BZ50oTSbIPse15zT.clX2",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "$2a$11$y06db5WGD0EBfI59j5RszujKkEDBRAUf7m2JjIBTv5RC70MdIj8d.");

            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "Schedules",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
