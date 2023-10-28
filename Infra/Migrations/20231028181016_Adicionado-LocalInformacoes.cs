using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APS8_CSHARP_API.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AdicionadoLocalInformacoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CEP",
                table: "Locais",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "Locais",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Locais",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Locais",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Pais",
                table: "Locais",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LocalInformacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClimaticosJson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QualidadeArJson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocalId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DataCriado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizado = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalInformacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocalInformacoes_Locais_LocalId",
                        column: x => x.LocalId,
                        principalTable: "Locais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LocalInformacoes_LocalId",
                table: "LocalInformacoes",
                column: "LocalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocalInformacoes");

            migrationBuilder.DropColumn(
                name: "CEP",
                table: "Locais");

            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "Locais");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Locais");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Locais");

            migrationBuilder.DropColumn(
                name: "Pais",
                table: "Locais");
        }
    }
}
