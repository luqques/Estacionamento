using Estacionamento.Domain.Entities;

namespace Estacionamento.UnitTests
{
    public class TabelaPrecosTests
    {
        [Fact]
        public void Dado_QuantidadeDeHoras_Deve_CalcularPrecoCorretamente()
        {
            //Arrange
            TabelaDePrecosEntity tabelaDePrecos = new();

            tabelaDePrecos.PrecoHora = 2;
            int minutos = 90;

            //Act
            decimal precoTotal = tabelaDePrecos.CalcularPreco(minutos);

            //Assert
            Assert.True(precoTotal == 3);
        }
    }
}