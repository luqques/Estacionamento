using Estacionamento.Domain.Entities;

namespace Estacionamento.UnitTests
{
    public class TabelaPrecosTests
    {
        [Theory(DisplayName = "Garante que o cálculo de valor total referente a quantidade de minutos esteja correto")] //TODO: Corrigir lógica de horas e preços
        [InlineData(30, 1.0)]
        [InlineData(60, 2.0)]
        [InlineData(70, 2.0)]
        [InlineData(75, 3.0)]
        [InlineData(125, 3.0)]
        [InlineData(135, 4.0)]
        public void Dado_QuantidadeDeHoras_Deve_CalcularPrecoCorretamente(int minutos, decimal precoTotalExpected)
        {
            //Arrange
            var tabelaDePrecos = new TabelaDePrecosEntity(precoHora: 2m);

            //Act
            decimal precoTotal = tabelaDePrecos.CalcularPreco(minutos);

            //Assert
            Assert.Equal(precoTotal, precoTotalExpected);
        }
    }
}