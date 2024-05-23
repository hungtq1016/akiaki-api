using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatedb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Enable",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Enable",
                table: "Urls");

            migrationBuilder.DropColumn(
                name: "Enable",
                table: "Tokens");

            migrationBuilder.DropColumn(
                name: "Enable",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "Enable",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "Enable",
                table: "ServicePrices");

            migrationBuilder.DropColumn(
                name: "Enable",
                table: "SendEmails");

            migrationBuilder.DropColumn(
                name: "Enable",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "Enable",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "Enable",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "Enable",
                table: "PrescriptionDetails");

            migrationBuilder.DropColumn(
                name: "Enable",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "Enable",
                table: "OTPs");

            migrationBuilder.DropColumn(
                name: "Enable",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "Enable",
                table: "Locales");

            migrationBuilder.DropColumn(
                name: "Enable",
                table: "LocaleKeys");

            migrationBuilder.DropColumn(
                name: "Enable",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "Enable",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "Enable",
                table: "InvoiceDetails");

            migrationBuilder.DropColumn(
                name: "Enable",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "Enable",
                table: "HealthRecords");

            migrationBuilder.DropColumn(
                name: "Enable",
                table: "GroupUrls");

            migrationBuilder.DropColumn(
                name: "Enable",
                table: "GroupServices");

            migrationBuilder.DropColumn(
                name: "Enable",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "Enable",
                table: "Faqs");

            migrationBuilder.DropColumn(
                name: "Enable",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Enable",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Enable",
                table: "BranchTypes");

            migrationBuilder.DropColumn(
                name: "Enable",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "Enable",
                table: "BlogTag");

            migrationBuilder.DropColumn(
                name: "Enable",
                table: "Blog");

            migrationBuilder.DropColumn(
                name: "Enable",
                table: "Assignments");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "$2a$11$7gE6CdiLJUy3ENn7Z.RcsenbTit735bNIqCnADmO7Wll/TmB175zy",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "$2a$11$y06db5WGD0EBfI59j5RszujKkEDBRAUf7m2JjIBTv5RC70MdIj8d.");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Urls",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Tokens",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Tags",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "ServicePrices",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "SendEmails",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Schedules",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Roles",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Prescriptions",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "PrescriptionDetails",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Permissions",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "OTPs",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Medicines",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Locales",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "LocaleKeys",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Languages",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "InvoiceDetails",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Images",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "HealthRecords",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "GroupUrls",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "GroupServices",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Groups",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Faqs",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "BranchTypes",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Branches",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "BlogTag",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Blog",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Assignments",
                type: "int",
                nullable: false,
                defaultValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Urls");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Tokens");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "ServicePrices");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "SendEmails");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "PrescriptionDetails");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "OTPs");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Locales");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "LocaleKeys");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "InvoiceDetails");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "HealthRecords");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "GroupUrls");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "GroupServices");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Faqs");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "BranchTypes");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "BlogTag");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Blog");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Assignments");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "$2a$11$y06db5WGD0EBfI59j5RszujKkEDBRAUf7m2JjIBTv5RC70MdIj8d.",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "$2a$11$7gE6CdiLJUy3ENn7Z.RcsenbTit735bNIqCnADmO7Wll/TmB175zy");

            migrationBuilder.AddColumn<bool>(
                name: "Enable",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "Enable",
                table: "Urls",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "Enable",
                table: "Tokens",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "Enable",
                table: "Tags",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "Enable",
                table: "Services",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "Enable",
                table: "ServicePrices",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "Enable",
                table: "SendEmails",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "Enable",
                table: "Schedules",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "Enable",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "Enable",
                table: "Prescriptions",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "Enable",
                table: "PrescriptionDetails",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "Enable",
                table: "Permissions",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "Enable",
                table: "OTPs",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "Enable",
                table: "Medicines",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "Enable",
                table: "Locales",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "Enable",
                table: "LocaleKeys",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "Enable",
                table: "Languages",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "Enable",
                table: "Invoices",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "Enable",
                table: "InvoiceDetails",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "Enable",
                table: "Images",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "Enable",
                table: "HealthRecords",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "Enable",
                table: "GroupUrls",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "Enable",
                table: "GroupServices",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "Enable",
                table: "Groups",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "Enable",
                table: "Faqs",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "Enable",
                table: "Comments",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "Enable",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "Enable",
                table: "BranchTypes",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "Enable",
                table: "Branches",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "Enable",
                table: "BlogTag",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "Enable",
                table: "Blog",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "Enable",
                table: "Assignments",
                type: "bit",
                nullable: false,
                defaultValue: true);
        }
    }
}
