using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APS8_CSHARP_API.Infra.Migrations
{
    /// <inheritdoc />
    public partial class RemovidoLinkLocalInformacoesComLocal2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QualidadeArJson",
                table: "LocalInformacoes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "QualidadeArJson",
                table: "LocalInformacoes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
