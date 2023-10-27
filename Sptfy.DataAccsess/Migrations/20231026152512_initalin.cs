using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sptfy.DataAccsess.Migrations
{
    /// <inheritdoc />
    public partial class initalin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MusicUrl",
                table: "Musics",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MusicUrl",
                table: "Musics");
        }
    }
}
