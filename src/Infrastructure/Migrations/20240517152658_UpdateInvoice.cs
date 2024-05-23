using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateInvoice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "$2a$11$aEscSRd72IB7ofJTjaUvGOGcCq5Qo0HNdNhGB7HPHo0LReULOzZPW",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "$2a$11$1qBSkS/0OYxQyLVUEmQI8OXgqB4IpO1QWqsiBkz3XHu.C/k8IyNku");

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false, defaultValueSql: "NEWID()"),
                    Total = table.Column<double>(type: "float", nullable: false),
                    Tax = table.Column<double>(type: "float", nullable: false),
                    PatientId = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false, defaultValueSql: "NEWID()"),
                    NurseId = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false, defaultValueSql: "NEWID()"),
                    HealthRecordId = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false, defaultValueSql: "NEWID()"),
                    Enable = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_HealthRecords_HealthRecordId",
                        column: x => x.HealthRecordId,
                        principalTable: "HealthRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invoices_Users_NurseId",
                        column: x => x.NurseId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoices_Users_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServicePrices",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false, defaultValueSql: "NEWID()"),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Enable = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicePrices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceDetails",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false, defaultValueSql: "NEWID()"),
                    InvoiceId = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false, defaultValueSql: "NEWID()"),
                    ServicePriceId = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false, defaultValueSql: "NEWID()"),
                    Enable = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceDetails_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceDetails_ServicePrices_ServicePriceId",
                        column: x => x.ServicePriceId,
                        principalTable: "ServicePrices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_InvoiceId",
                table: "InvoiceDetails",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_ServicePriceId",
                table: "InvoiceDetails",
                column: "ServicePriceId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_HealthRecordId",
                table: "Invoices",
                column: "HealthRecordId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_NurseId",
                table: "Invoices",
                column: "NurseId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_PatientId",
                table: "Invoices",
                column: "PatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceDetails");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "ServicePrices");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "$2a$11$1qBSkS/0OYxQyLVUEmQI8OXgqB4IpO1QWqsiBkz3XHu.C/k8IyNku",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "$2a$11$aEscSRd72IB7ofJTjaUvGOGcCq5Qo0HNdNhGB7HPHo0LReULOzZPW");
        }
    }
}
