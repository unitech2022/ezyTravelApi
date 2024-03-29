﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TouristApi.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lat",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "Lng",
                table: "Places");

            migrationBuilder.AddColumn<string>(
                name: "LatLng",
                table: "Places",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LatLng",
                table: "Places");

            migrationBuilder.AddColumn<double>(
                name: "Lat",
                table: "Places",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Lng",
                table: "Places",
                type: "double",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
