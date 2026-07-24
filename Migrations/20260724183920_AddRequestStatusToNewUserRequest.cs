using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewUserSite.Migrations
{
    /// <inheritdoc />
    public partial class AddRequestStatusToNewUserRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RequestStatus",
                table: "NewUsers",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequestStatus",
                table: "NewUsers");
        }
    }
}
