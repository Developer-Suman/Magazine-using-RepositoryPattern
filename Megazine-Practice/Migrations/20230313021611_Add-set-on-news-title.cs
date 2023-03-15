using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Megazine_Practice.Migrations
{
    public partial class Addsetonnewstitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "news",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "news",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "news");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "news");
        }
    }
}
