using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawsForApplause.Migrations
{
    /// <inheritdoc />
    public partial class RemovedLocationFromShowMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Show");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Venue",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Show",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Venue");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "User");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Show");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Show",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
