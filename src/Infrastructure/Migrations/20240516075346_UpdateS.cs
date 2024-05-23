using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDay",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Schedule");

            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "Schedule",
                newName: "Time");

            migrationBuilder.RenameColumn(
                name: "StartDay",
                table: "Schedule",
                newName: "Date");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "$2a$11$aQgUfE7zGNG8INrQUcQUUe3zooNGo19m3IrfJ1I7UYlRS6d7p3.ou",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "$2a$11$8YoxOgTH3nlX26rXlgJrK.ekAQez1MwjdPAz/6qd.dX0QrSqy8XEK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Time",
                table: "Schedule",
                newName: "StartTime");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Schedule",
                newName: "StartDay");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "$2a$11$8YoxOgTH3nlX26rXlgJrK.ekAQez1MwjdPAz/6qd.dX0QrSqy8XEK",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "$2a$11$aQgUfE7zGNG8INrQUcQUUe3zooNGo19m3IrfJ1I7UYlRS6d7p3.ou");

            migrationBuilder.AddColumn<string>(
                name: "EndDay",
                table: "Schedule",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EndTime",
                table: "Schedule",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
