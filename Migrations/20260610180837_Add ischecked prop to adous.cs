using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewUserSite.Migrations
{
    /// <inheritdoc />
    public partial class Addischeckedproptoadous : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdOrganizationalUnits_NewUserTemplates_NewUserTemplateId",
                table: "AdOrganizationalUnits");

            migrationBuilder.DropForeignKey(
                name: "FK_NewUsers_AdOrganizationalUnits_AdOrganizationalUnitId",
                table: "NewUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdOrganizationalUnits",
                table: "AdOrganizationalUnits");

            migrationBuilder.RenameTable(
                name: "AdOrganizationalUnits",
                newName: "ADOrganizationalUnits");

            migrationBuilder.RenameIndex(
                name: "IX_AdOrganizationalUnits_NewUserTemplateId",
                table: "ADOrganizationalUnits",
                newName: "IX_ADOrganizationalUnits_NewUserTemplateId");

            migrationBuilder.AddColumn<bool>(
                name: "IsChecked",
                table: "ADOrganizationalUnits",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ADOrganizationalUnits",
                table: "ADOrganizationalUnits",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ADOrganizationalUnits_NewUserTemplates_NewUserTemplateId",
                table: "ADOrganizationalUnits",
                column: "NewUserTemplateId",
                principalTable: "NewUserTemplates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NewUsers_ADOrganizationalUnits_AdOrganizationalUnitId",
                table: "NewUsers",
                column: "AdOrganizationalUnitId",
                principalTable: "ADOrganizationalUnits",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ADOrganizationalUnits_NewUserTemplates_NewUserTemplateId",
                table: "ADOrganizationalUnits");

            migrationBuilder.DropForeignKey(
                name: "FK_NewUsers_ADOrganizationalUnits_AdOrganizationalUnitId",
                table: "NewUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ADOrganizationalUnits",
                table: "ADOrganizationalUnits");

            migrationBuilder.DropColumn(
                name: "IsChecked",
                table: "ADOrganizationalUnits");

            migrationBuilder.RenameTable(
                name: "ADOrganizationalUnits",
                newName: "AdOrganizationalUnits");

            migrationBuilder.RenameIndex(
                name: "IX_ADOrganizationalUnits_NewUserTemplateId",
                table: "AdOrganizationalUnits",
                newName: "IX_AdOrganizationalUnits_NewUserTemplateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdOrganizationalUnits",
                table: "AdOrganizationalUnits",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdOrganizationalUnits_NewUserTemplates_NewUserTemplateId",
                table: "AdOrganizationalUnits",
                column: "NewUserTemplateId",
                principalTable: "NewUserTemplates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NewUsers_AdOrganizationalUnits_AdOrganizationalUnitId",
                table: "NewUsers",
                column: "AdOrganizationalUnitId",
                principalTable: "AdOrganizationalUnits",
                principalColumn: "Id");
        }
    }
}
