using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPISamples.Migrations
{
    public partial class SecondVersion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "IMDB_Rating",
                table: "Movie",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IMDB_Rating",
                table: "Movie");
        }
    }
}
