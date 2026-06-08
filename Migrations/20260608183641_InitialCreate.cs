using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace NewUserSite.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ADOrganizationalUnit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true),
                    ADDistinguishedName = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADOrganizationalUnit", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AdSearchers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(type: "longtext", nullable: true),
                    Password = table.Column<string>(type: "longtext", nullable: true),
                    DomainControllerLocation = table.Column<string>(type: "longtext", nullable: true),
                    DomainControllerRoot = table.Column<string>(type: "longtext", nullable: true),
                    TemplateOU = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdSearchers", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AppUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(type: "longtext", nullable: true),
                    EmailAddress = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUser", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "NewUserTemplate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    TemplateName = table.Column<string>(type: "longtext", nullable: true),
                    TemplateSAMAccountName = table.Column<string>(type: "longtext", nullable: true),
                    ADOrganizationalUnitId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewUserTemplate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewUserTemplate_ADOrganizationalUnit_ADOrganizationalUnitId",
                        column: x => x.ADOrganizationalUnitId,
                        principalTable: "ADOrganizationalUnit",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "NewUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "longtext", nullable: true),
                    LastName = table.Column<string>(type: "longtext", nullable: true),
                    AdOrganizationalUnitId = table.Column<int>(type: "int", nullable: true),
                    NewUserTemplateId = table.Column<int>(type: "int", nullable: true),
                    SupervisorEmail = table.Column<string>(type: "longtext", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewUsers_ADOrganizationalUnit_AdOrganizationalUnitId",
                        column: x => x.AdOrganizationalUnitId,
                        principalTable: "ADOrganizationalUnit",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NewUsers_AppUser_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AppUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NewUsers_NewUserTemplate_NewUserTemplateId",
                        column: x => x.NewUserTemplateId,
                        principalTable: "NewUserTemplate",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_NewUsers_AdOrganizationalUnitId",
                table: "NewUsers",
                column: "AdOrganizationalUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_NewUsers_CreatedById",
                table: "NewUsers",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_NewUsers_NewUserTemplateId",
                table: "NewUsers",
                column: "NewUserTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_NewUserTemplate_ADOrganizationalUnitId",
                table: "NewUserTemplate",
                column: "ADOrganizationalUnitId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdSearchers");

            migrationBuilder.DropTable(
                name: "NewUsers");

            migrationBuilder.DropTable(
                name: "AppUser");

            migrationBuilder.DropTable(
                name: "NewUserTemplate");

            migrationBuilder.DropTable(
                name: "ADOrganizationalUnit");
        }
    }
}
