using Microsoft.EntityFrameworkCore.Migrations;

namespace CakeBoss.WebApi.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Kits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "varchar(60)", nullable: false),
                    Desconto = table.Column<decimal>(type: "decimal(8,2)", nullable: false, defaultValue: 0m),
                    Observacao = table.Column<string>(type: "varchar(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Kits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "varchar(60)", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(8,2)", nullable: false, defaultValue: 0m),
                    Observacao = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    Quantidade = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    KitId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Produtos_Tbl_Kits_KitId",
                        column: x => x.KitId,
                        principalTable: "Tbl_Kits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Imagens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdutoId = table.Column<int>(type: "int", nullable: false),
                    Caminho = table.Column<string>(type: "varchar(200)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(500)", nullable: false),
                    OrdemVisualizacao = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Imagens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Imagens_Tbl_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Tbl_Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Imagens_ProdutoId",
                table: "Tbl_Imagens",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Produtos_KitId",
                table: "Tbl_Produtos",
                column: "KitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Imagens");

            migrationBuilder.DropTable(
                name: "Tbl_Produtos");

            migrationBuilder.DropTable(
                name: "Tbl_Kits");
        }
    }
}
