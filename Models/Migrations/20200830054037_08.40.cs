using Microsoft.EntityFrameworkCore.Migrations;

namespace Models.Migrations
{
    public partial class _0840 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Stations_DealerId",
                table: "Stations",
                column: "DealerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stations_Dealers_DealerId",
                table: "Stations",
                column: "DealerId",
                principalTable: "Dealers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stations_Dealers_DealerId",
                table: "Stations");

            migrationBuilder.DropIndex(
                name: "IX_Stations_DealerId",
                table: "Stations");
        }
    }
}
