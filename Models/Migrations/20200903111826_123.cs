using Microsoft.EntityFrameworkCore.Migrations;

namespace Models.Migrations
{
    public partial class _123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Definations_DefinationId",
                table: "Materials");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Definations_DefinationId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "DefinationId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "DefId",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "DefinationId",
                table: "Materials");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Product",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "DefId",
                table: "Product",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "Product",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DefiId",
                table: "Materials",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Recipt",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    MaterialId = table.Column<int>(nullable: false),
                    Value = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipt_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recipt_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_DefId",
                table: "Product",
                column: "DefId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_DefiId",
                table: "Materials",
                column: "DefiId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipt_MaterialId",
                table: "Recipt",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipt_ProductId",
                table: "Recipt",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Definations_DefiId",
                table: "Materials",
                column: "DefiId",
                principalTable: "Definations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Definations_DefId",
                table: "Product",
                column: "DefId",
                principalTable: "Definations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Definations_DefiId",
                table: "Materials");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Definations_DefId",
                table: "Product");

            migrationBuilder.DropTable(
                name: "Recipt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_DefId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Materials_DefiId",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "DefId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "DefiId",
                table: "Materials");

            migrationBuilder.AddColumn<int>(
                name: "DefinationId",
                table: "Product",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefId",
                table: "Materials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DefinationId",
                table: "Materials",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Definations_DefinationId",
                table: "Materials",
                column: "DefinationId",
                principalTable: "Definations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Definations_DefinationId",
                table: "Product",
                column: "DefinationId",
                principalTable: "Definations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
