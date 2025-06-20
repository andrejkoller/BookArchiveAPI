using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookArchiveAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddNewPropertiesToModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CoverImageUrl",
                table: "Books",
                newName: "PreviewImage");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Books",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "Books",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "PreviewImage",
                table: "Books",
                newName: "CoverImageUrl");
        }
    }
}
