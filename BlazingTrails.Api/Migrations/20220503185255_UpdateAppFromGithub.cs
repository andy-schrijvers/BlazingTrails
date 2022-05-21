using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazingTrails.Api.Migrations
{
    public partial class UpdateAppFromGithub : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFavourite",
                table: "Trails");

            migrationBuilder.RenameColumn(
                name: "Lng",
                table: "Waypoints",
                newName: "Longitude");

            migrationBuilder.RenameColumn(
                name: "Lat",
                table: "Waypoints",
                newName: "Latitude");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Longitude",
                table: "Waypoints",
                newName: "Lng");

            migrationBuilder.RenameColumn(
                name: "Latitude",
                table: "Waypoints",
                newName: "Lat");

            migrationBuilder.AddColumn<bool>(
                name: "IsFavourite",
                table: "Trails",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
