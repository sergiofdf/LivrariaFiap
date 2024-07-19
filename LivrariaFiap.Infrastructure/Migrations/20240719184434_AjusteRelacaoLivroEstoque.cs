using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LivrariaFiap.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AjusteRelacaoLivroEstoque : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Estoque_LivroId",
                table: "Estoque");

            migrationBuilder.CreateIndex(
                name: "IX_Estoque_LivroId",
                table: "Estoque",
                column: "LivroId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Estoque_LivroId",
                table: "Estoque");

            migrationBuilder.CreateIndex(
                name: "IX_Estoque_LivroId",
                table: "Estoque",
                column: "LivroId");
        }
    }
}
