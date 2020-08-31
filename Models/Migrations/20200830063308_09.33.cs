using Microsoft.EntityFrameworkCore.Migrations;

namespace Models.Migrations
{
    public partial class _0933 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dealers_Dealers_DealerId",
                table: "Dealers");

            migrationBuilder.DropIndex(
                name: "IX_Dealers_DealerId",
                table: "Dealers");

            migrationBuilder.DropColumn(
                name: "DealerId",
                table: "Dealers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DealerId",
                table: "Dealers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dealers_DealerId",
                table: "Dealers",
                column: "DealerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dealers_Dealers_DealerId",
                table: "Dealers",
                column: "DealerId",
                principalTable: "Dealers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
