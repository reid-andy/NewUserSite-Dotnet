using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewUserSite.Migrations
{
    /// <inheritdoc />
    public partial class ApplicationPreferencesDefaults : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Template",
                table: "ApplicationPreferences",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "Job Title",
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AlterColumn<string>(
                name: "OrganizationalUnit",
                table: "ApplicationPreferences",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "Department",
                oldClrType: typeof(string),
                oldType: "longtext");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Template",
                table: "ApplicationPreferences",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100,
                oldDefaultValue: "Job Title");

            migrationBuilder.AlterColumn<string>(
                name: "OrganizationalUnit",
                table: "ApplicationPreferences",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100,
                oldDefaultValue: "Department");
        }
    }
}
