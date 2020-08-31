using Microsoft.EntityFrameworkCore.Migrations;

namespace Models.Migrations
{
    public partial class BussinessTypeIdColoumdAddedIntoStations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BussinessTypeId",
                table: "Stations",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BussinessTypeId",
                table: "Stations");
        }
    }
}
