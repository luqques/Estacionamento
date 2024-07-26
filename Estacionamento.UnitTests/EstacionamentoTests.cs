using Estacionamento.Domain.Entities;

namespace Estacionamento.UnitTests
{
    public class EstacionamentoTests
    {
        [Fact]
        public void Dado_RangeDeTempo_Deve_CalcularTempoTotal()
        {
            //Arrange
            RegistroEstacionamentoEntity registro = new();

            registro.DataHoraEntrada = new DateTime(2024, 07, 25, 06, 00, 00);
            registro.DataHoraSaida = new DateTime(2024, 07, 25, 07, 30, 00);

            //Act
            registro.CalcularTotalDeHoras();

            //Assert
            Assert.True(registro.MinutosTotais == 90);
        }

        [Fact]
        public void Dado_RangeDeTempo_Deve_CalcularPrecoTotal()
        {
            //Arrange
            var registro = new RegistroEstacionamentoEntity();
            var tabelaDePrecos = new TabelaDePrecosEntity(precoHora: 2m);

            registro.DataHoraEntrada = new DateTime(2024, 07, 25, 06, 00, 00);
            registro.DataHoraSaida = new DateTime(2024, 07, 25, 07, 30, 00);

            //Act
            registro.CalcularTotalDeHoras();
            registro.CalcularValorAPagar(tabelaDePrecos);

            //Assert
            Assert.True(registro.ValorPagar == 5m);
        }
    }
}
