using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewUserSite.Migrations
{
    /// <inheritdoc />
    public partial class AddAutoApproveNewUserRequestsPreference : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AutoApproveNewUserRequests",
                table: "ApplicationPreferences",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "ApplicationPreferences",
                keyColumn: "Id",
                keyValue: 1,
                column: "AutoApproveNewUserRequests",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AutoApproveNewUserRequests",
                table: "ApplicationPreferences");
        }
    }
}
