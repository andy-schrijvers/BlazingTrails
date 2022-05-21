﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazingTrails.Api.Migrations
{
    public partial class UpdateWaypointPrecision3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                table: "Waypoints",
                type: "decimal(8,5)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                table: "Waypoints",
                type: "decimal(8,5)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                table: "Waypoints",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8,5)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                table: "Waypoints",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8,5)");
        }
    }
}
