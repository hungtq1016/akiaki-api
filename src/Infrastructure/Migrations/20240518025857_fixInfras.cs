using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fixInfras : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_HealthRecords_HealthRecordId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_HealthRecordId",
                table: "Invoices");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "$2a$11$Ok2ynAwQ4jalXcBwcA7MtedAhMOdsXl1BZ50oTSbIPse15zT.clX2",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "$2a$11$aEscSRd72IB7ofJTjaUvGOGcCq5Qo0HNdNhGB7HPHo0LReULOzZPW");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_HealthRecordId",
                table: "Invoices",
                column: "HealthRecordId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_HealthRecords_HealthRecordId",
                table: "Invoices",
                column: "HealthRecordId",
                principalTable: "HealthRecords",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_HealthRecords_HealthRecordId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_HealthRecordId",
                table: "Invoices");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "$2a$11$aEscSRd72IB7ofJTjaUvGOGcCq5Qo0HNdNhGB7HPHo0LReULOzZPW",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "$2a$11$Ok2ynAwQ4jalXcBwcA7MtedAhMOdsXl1BZ50oTSbIPse15zT.clX2");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_HealthRecordId",
                table: "Invoices",
                column: "HealthRecordId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_HealthRecords_HealthRecordId",
                table: "Invoices",
                column: "HealthRecordId",
                principalTable: "HealthRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
