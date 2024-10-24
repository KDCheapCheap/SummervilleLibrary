using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SummervilleLibrary.Migrations
{
    /// <inheritdoc />
    public partial class BookModelUpdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Blurb",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "PublicationYear",
                table: "Books",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublicationYear",
                table: "Books");

            migrationBuilder.AddColumn<string>(
                name: "Blurb",
                table: "Books",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
