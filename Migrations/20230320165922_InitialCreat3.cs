using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TouristApi.Migrations
{
    public partial class InitialCreat3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageFlag",
                table: "Cities",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageFlag",
                table: "Cities");
        }
    }
}
