using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APS8_CSHARP_API.Infra.Migrations
{
    /// <inheritdoc />
    public partial class RemovidoLinkLocalInformacoesComLocal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocalInformacoes_Locais_LocalId",
                table: "LocalInformacoes");

            migrationBuilder.DropIndex(
                name: "IX_LocalInformacoes_LocalId",
                table: "LocalInformacoes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_LocalInformacoes_LocalId",
                table: "LocalInformacoes",
                column: "LocalId");

            migrationBuilder.AddForeignKey(
                name: "FK_LocalInformacoes_Locais_LocalId",
                table: "LocalInformacoes",
                column: "LocalId",
                principalTable: "Locais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
