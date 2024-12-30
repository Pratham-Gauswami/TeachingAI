using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeachingAI1.Migrations
{
    /// <inheritdoc />
    public partial class AddIsLoggedInAndLastActivityToUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsLoggedIn",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastActivity",
                table: "Users",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsLoggedIn",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastActivity",
                table: "Users");
        }
    }
}
