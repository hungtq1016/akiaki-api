using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Users_UserId",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_UserId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Schedules");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "$2a$11$Yap0haGjdiU0lyVa/9CZmOc823Z.pxdsufrL4i4Hh.NgZ7CBPnDPq",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "$2a$11$zrbhSBOXGvjcCtalbn0tPe703azzXqMsj0bwj8s4Hc5S7ykSz68sK");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Schedules",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Schedules");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "$2a$11$zrbhSBOXGvjcCtalbn0tPe703azzXqMsj0bwj8s4Hc5S7ykSz68sK",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "$2a$11$Yap0haGjdiU0lyVa/9CZmOc823Z.pxdsufrL4i4Hh.NgZ7CBPnDPq");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Schedules",
                type: "varchar(36)",
                maxLength: 36,
                nullable: false,
                defaultValueSql: "NEWID()");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_UserId",
                table: "Schedules",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Users_UserId",
                table: "Schedules",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
