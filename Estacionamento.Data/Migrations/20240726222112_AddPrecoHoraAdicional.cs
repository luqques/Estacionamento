using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Estacionamento.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPrecoHoraAdicional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PrecoHoraAdicional",
                table: "TabelaDePrecos",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrecoHoraAdicional",
                table: "TabelaDePrecos");
        }
    }
}
