using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewUserSite.Migrations
{
    /// <inheritdoc />
    public partial class NewUserRequestTableUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "NewUsers",
                newName: "RequestedDate");

            migrationBuilder.AddColumn<string>(
                name: "ApprovedBy",
                table: "NewUsers",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedDate",
                table: "NewUsers",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "NewUsers",
                type: "longtext",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovedBy",
                table: "NewUsers");

            migrationBuilder.DropColumn(
                name: "ApprovedDate",
                table: "NewUsers");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "NewUsers");

            migrationBuilder.RenameColumn(
                name: "RequestedDate",
                table: "NewUsers",
                newName: "CreatedDate");
        }
    }
}
