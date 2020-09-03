using Microsoft.EntityFrameworkCore.Migrations;

namespace Models.Migrations
{
    public partial class _114545 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stations_Dealers_DealerId",
                table: "Stations");

            migrationBuilder.DropIndex(
                name: "IX_Stations_DealerId",
                table: "Stations");

            migrationBuilder.CreateTable(
                name: "MaterialHistories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfficerId = table.Column<int>(nullable: false),
                    MaterialId = table.Column<int>(nullable: false),
                    SupplierId = table.Column<int>(nullable: false),
                    Quantity = table.Column<double>(nullable: false),
                    DefIdUnit = table.Column<int>(nullable: false),
                    DefIdCurrency = table.Column<int>(nullable: true),
                    Fee = table.Column<double>(nullable: false),
                    DefIdBussinessType = table.Column<int>(nullable: true),
                    DealerId = table.Column<int>(nullable: true),
                    StationId = table.Column<int>(nullable: true),
                    OperationTypeNum = table.Column<int>(nullable: false),
                    OutputType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialHistories", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaterialHistories");

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
    }
}
