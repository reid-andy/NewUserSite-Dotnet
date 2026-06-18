using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewUserSite.Migrations
{
    /// <inheritdoc />
    public partial class addDomainsBack : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DomainId",
                table: "NewUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NewUsers_DomainId",
                table: "NewUsers",
                column: "DomainId");

            migrationBuilder.AddForeignKey(
                name: "FK_NewUsers_Domains_DomainId",
                table: "NewUsers",
                column: "DomainId",
                principalTable: "Domains",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewUsers_Domains_DomainId",
                table: "NewUsers");

            migrationBuilder.DropIndex(
                name: "IX_NewUsers_DomainId",
                table: "NewUsers");

            migrationBuilder.DropColumn(
                name: "DomainId",
                table: "NewUsers");
        }
    }
}
