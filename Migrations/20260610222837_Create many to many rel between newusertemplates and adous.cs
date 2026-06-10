using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewUserSite.Migrations
{
    /// <inheritdoc />
    public partial class Createmanytomanyrelbetweennewusertemplatesandadous : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ADOrganizationalUnits_NewUserTemplates_NewUserTemplateId",
                table: "ADOrganizationalUnits");

            migrationBuilder.DropIndex(
                name: "IX_ADOrganizationalUnits_NewUserTemplateId",
                table: "ADOrganizationalUnits");

            migrationBuilder.DropColumn(
                name: "NewUserTemplateId",
                table: "ADOrganizationalUnits");

            migrationBuilder.CreateTable(
                name: "ADOrganizationalUnitNewUserTemplate",
                columns: table => new
                {
                    ADOrganizationalUnitsId = table.Column<int>(type: "int", nullable: false),
                    NewUserTemplatesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADOrganizationalUnitNewUserTemplate", x => new { x.ADOrganizationalUnitsId, x.NewUserTemplatesId });
                    table.ForeignKey(
                        name: "FK_ADOrganizationalUnitNewUserTemplate_ADOrganizationalUnits_AD~",
                        column: x => x.ADOrganizationalUnitsId,
                        principalTable: "ADOrganizationalUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ADOrganizationalUnitNewUserTemplate_NewUserTemplates_NewUser~",
                        column: x => x.NewUserTemplatesId,
                        principalTable: "NewUserTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ADOrganizationalUnitNewUserTemplate_NewUserTemplatesId",
                table: "ADOrganizationalUnitNewUserTemplate",
                column: "NewUserTemplatesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ADOrganizationalUnitNewUserTemplate");

            migrationBuilder.AddColumn<int>(
                name: "NewUserTemplateId",
                table: "ADOrganizationalUnits",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ADOrganizationalUnits_NewUserTemplateId",
                table: "ADOrganizationalUnits",
                column: "NewUserTemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_ADOrganizationalUnits_NewUserTemplates_NewUserTemplateId",
                table: "ADOrganizationalUnits",
                column: "NewUserTemplateId",
                principalTable: "NewUserTemplates",
                principalColumn: "Id");
        }
    }
}
