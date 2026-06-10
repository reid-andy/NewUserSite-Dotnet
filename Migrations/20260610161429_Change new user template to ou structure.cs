using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace NewUserSite.Migrations
{
    /// <inheritdoc />
    public partial class Changenewusertemplatetooustructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewUsers_ADOrganizationalUnit_AdOrganizationalUnitId",
                table: "NewUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_NewUsers_AppUser_CreatedById",
                table: "NewUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_NewUsers_NewUserTemplate_NewUserTemplateId",
                table: "NewUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_NewUserTemplate_ADOrganizationalUnit_ADOrganizationalUnitId",
                table: "NewUserTemplate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdSearchers",
                table: "AdSearchers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NewUserTemplate",
                table: "NewUserTemplate");

            migrationBuilder.DropIndex(
                name: "IX_NewUserTemplate_ADOrganizationalUnitId",
                table: "NewUserTemplate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUser",
                table: "AppUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ADOrganizationalUnit",
                table: "ADOrganizationalUnit");

            migrationBuilder.DropColumn(
                name: "ADOrganizationalUnitId",
                table: "NewUserTemplate");

            migrationBuilder.RenameTable(
                name: "AdSearchers",
                newName: "ADSearchers");

            migrationBuilder.RenameTable(
                name: "NewUserTemplate",
                newName: "NewUserTemplates");

            migrationBuilder.RenameTable(
                name: "AppUser",
                newName: "AppUsers");

            migrationBuilder.RenameTable(
                name: "ADOrganizationalUnit",
                newName: "AdOrganizationalUnits");

            migrationBuilder.AddColumn<int>(
                name: "NotificationId",
                table: "AppUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NewUserTemplateId",
                table: "AdOrganizationalUnits",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ADSearchers",
                table: "ADSearchers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NewUserTemplates",
                table: "NewUserTemplates",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUsers",
                table: "AppUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdOrganizationalUnits",
                table: "AdOrganizationalUnits",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Hardware",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hardware", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IsEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    NotificationText = table.Column<string>(type: "longtext", nullable: true),
                    NotificationSubject = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_NotificationId",
                table: "AppUsers",
                column: "NotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_AdOrganizationalUnits_NewUserTemplateId",
                table: "AdOrganizationalUnits",
                column: "NewUserTemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdOrganizationalUnits_NewUserTemplates_NewUserTemplateId",
                table: "AdOrganizationalUnits",
                column: "NewUserTemplateId",
                principalTable: "NewUserTemplates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_Notifications_NotificationId",
                table: "AppUsers",
                column: "NotificationId",
                principalTable: "Notifications",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NewUsers_AdOrganizationalUnits_AdOrganizationalUnitId",
                table: "NewUsers",
                column: "AdOrganizationalUnitId",
                principalTable: "AdOrganizationalUnits",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NewUsers_AppUsers_CreatedById",
                table: "NewUsers",
                column: "CreatedById",
                principalTable: "AppUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NewUsers_NewUserTemplates_NewUserTemplateId",
                table: "NewUsers",
                column: "NewUserTemplateId",
                principalTable: "NewUserTemplates",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdOrganizationalUnits_NewUserTemplates_NewUserTemplateId",
                table: "AdOrganizationalUnits");

            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_Notifications_NotificationId",
                table: "AppUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_NewUsers_AdOrganizationalUnits_AdOrganizationalUnitId",
                table: "NewUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_NewUsers_AppUsers_CreatedById",
                table: "NewUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_NewUsers_NewUserTemplates_NewUserTemplateId",
                table: "NewUsers");

            migrationBuilder.DropTable(
                name: "Hardware");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ADSearchers",
                table: "ADSearchers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NewUserTemplates",
                table: "NewUserTemplates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUsers",
                table: "AppUsers");

            migrationBuilder.DropIndex(
                name: "IX_AppUsers_NotificationId",
                table: "AppUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdOrganizationalUnits",
                table: "AdOrganizationalUnits");

            migrationBuilder.DropIndex(
                name: "IX_AdOrganizationalUnits_NewUserTemplateId",
                table: "AdOrganizationalUnits");

            migrationBuilder.DropColumn(
                name: "NotificationId",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "NewUserTemplateId",
                table: "AdOrganizationalUnits");

            migrationBuilder.RenameTable(
                name: "ADSearchers",
                newName: "AdSearchers");

            migrationBuilder.RenameTable(
                name: "NewUserTemplates",
                newName: "NewUserTemplate");

            migrationBuilder.RenameTable(
                name: "AppUsers",
                newName: "AppUser");

            migrationBuilder.RenameTable(
                name: "AdOrganizationalUnits",
                newName: "ADOrganizationalUnit");

            migrationBuilder.AddColumn<int>(
                name: "ADOrganizationalUnitId",
                table: "NewUserTemplate",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdSearchers",
                table: "AdSearchers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NewUserTemplate",
                table: "NewUserTemplate",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUser",
                table: "AppUser",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ADOrganizationalUnit",
                table: "ADOrganizationalUnit",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_NewUserTemplate_ADOrganizationalUnitId",
                table: "NewUserTemplate",
                column: "ADOrganizationalUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_NewUsers_ADOrganizationalUnit_AdOrganizationalUnitId",
                table: "NewUsers",
                column: "AdOrganizationalUnitId",
                principalTable: "ADOrganizationalUnit",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NewUsers_AppUser_CreatedById",
                table: "NewUsers",
                column: "CreatedById",
                principalTable: "AppUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NewUsers_NewUserTemplate_NewUserTemplateId",
                table: "NewUsers",
                column: "NewUserTemplateId",
                principalTable: "NewUserTemplate",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NewUserTemplate_ADOrganizationalUnit_ADOrganizationalUnitId",
                table: "NewUserTemplate",
                column: "ADOrganizationalUnitId",
                principalTable: "ADOrganizationalUnit",
                principalColumn: "Id");
        }
    }
}
