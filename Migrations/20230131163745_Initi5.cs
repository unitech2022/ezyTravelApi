using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TouristApi.Migrations
{
    public partial class Initi5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Photos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Photos");
        }
    }
}
