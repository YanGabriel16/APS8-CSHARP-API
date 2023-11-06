using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APS8_CSHARP_API.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AlteradoLocais6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocalInformacoes_Locais_LocalId",
                table: "LocalInformacoes");

            migrationBuilder.AddForeignKey(
                name: "FK_LocalInformacoes_Locais_LocalId",
                table: "LocalInformacoes",
                column: "LocalId",
                principalTable: "Locais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocalInformacoes_Locais_LocalId",
                table: "LocalInformacoes");

            migrationBuilder.AddForeignKey(
                name: "FK_LocalInformacoes_Locais_LocalId",
                table: "LocalInformacoes",
                column: "LocalId",
                principalTable: "Locais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
