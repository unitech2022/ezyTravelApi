using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TouristApi.Migrations
{
    public partial class Initi12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Photos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Photos");
        }
    }
}
