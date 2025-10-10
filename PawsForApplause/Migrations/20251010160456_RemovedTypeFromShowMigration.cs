using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawsForApplause.Migrations
{
    /// <inheritdoc />
    public partial class RemovedTypeFromShowMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Show");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Show",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
