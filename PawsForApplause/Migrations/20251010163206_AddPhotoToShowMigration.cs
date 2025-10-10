using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawsForApplause.Migrations
{
    /// <inheritdoc />
    public partial class AddPhotoToShowMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Filename",
                table: "Show",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Filename",
                table: "Show");
        }
    }
}
