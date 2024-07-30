using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Estacionamento.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TabelaDePrecos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PrecoHora = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabelaDePrecos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Veiculo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Placa = table.Column<string>(type: "varchar(10)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NomeProprietario = table.Column<string>(type: "varchar(250)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Modelo = table.Column<string>(type: "varchar(250)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculo", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RegistroEstacionamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    VeiculoId = table.Column<int>(type: "int", nullable: false),
                    TabelaDePrecosId = table.Column<int>(type: "int", nullable: true),
                    DataHoraEntrada = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataHoraSaida = table.Column<DateTime>(type: "datetime", nullable: true),
                    ValorPagar = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    MinutosTotais = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroEstacionamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegistroEstacionamento_TabelaDePrecos_TabelaDePrecosId",
                        column: x => x.TabelaDePrecosId,
                        principalTable: "TabelaDePrecos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RegistroEstacionamento_Veiculo_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroEstacionamento_TabelaDePrecosId",
                table: "RegistroEstacionamento",
                column: "TabelaDePrecosId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroEstacionamento_VeiculoId",
                table: "RegistroEstacionamento",
                column: "VeiculoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegistroEstacionamento");

            migrationBuilder.DropTable(
                name: "TabelaDePrecos");

            migrationBuilder.DropTable(
                name: "Veiculo");
        }
    }
}
