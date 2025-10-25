using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawsForApplause.Migrations
{
    /// <inheritdoc />
    public partial class NewLocalHostDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "Venue");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "Venue",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
