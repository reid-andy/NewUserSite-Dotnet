using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewUserSite.Migrations
{
    /// <inheritdoc />
    public partial class AddDomainTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewUsers_ADOrganizationalUnits_AdOrganizationalUnitId",
                table: "NewUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_NewUsers_AppUsers_CreatedById",
                table: "NewUsers");

            migrationBuilder.DropIndex(
                name: "IX_NewUsers_CreatedById",
                table: "NewUsers");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "NewUsers");

            migrationBuilder.RenameColumn(
                name: "AdOrganizationalUnitId",
                table: "NewUsers",
                newName: "ADOrganizationalUnitId");

            migrationBuilder.RenameIndex(
                name: "IX_NewUsers_AdOrganizationalUnitId",
                table: "NewUsers",
                newName: "IX_NewUsers_ADOrganizationalUnitId");

            migrationBuilder.AddColumn<int>(
                name: "PermissionLevel",
                table: "AppUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_NewUsers_ADOrganizationalUnits_ADOrganizationalUnitId",
                table: "NewUsers",
                column: "ADOrganizationalUnitId",
                principalTable: "ADOrganizationalUnits",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewUsers_ADOrganizationalUnits_ADOrganizationalUnitId",
                table: "NewUsers");

            migrationBuilder.DropColumn(
                name: "PermissionLevel",
                table: "AppUsers");

            migrationBuilder.RenameColumn(
                name: "ADOrganizationalUnitId",
                table: "NewUsers",
                newName: "AdOrganizationalUnitId");

            migrationBuilder.RenameIndex(
                name: "IX_NewUsers_ADOrganizationalUnitId",
                table: "NewUsers",
                newName: "IX_NewUsers_AdOrganizationalUnitId");

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "NewUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NewUsers_CreatedById",
                table: "NewUsers",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_NewUsers_ADOrganizationalUnits_AdOrganizationalUnitId",
                table: "NewUsers",
                column: "AdOrganizationalUnitId",
                principalTable: "ADOrganizationalUnits",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NewUsers_AppUsers_CreatedById",
                table: "NewUsers",
                column: "CreatedById",
                principalTable: "AppUsers",
                principalColumn: "Id");
        }
    }
}
