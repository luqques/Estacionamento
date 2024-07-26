using System.ComponentModel.DataAnnotations;

namespace Estacionamento.Domain.Entities
{
    public class RegistroEstacionamentoEntity : BaseEntity
    {

        [Required]
        public VeiculoEntity Veiculo { get; set; }

        [Required]
        public int VeiculoId { get; set; }

        public TabelaDePrecosEntity TabelaDePrecos { get; set; }

        [Required]
        public DateTime DataHoraEntrada { get; set; }

        public DateTime? DataHoraSaida { get; set; }

        public decimal? ValorPagar { get; private set; }

        public int? MinutosTotais { get; private set; }

        public void CalcularTotalDeHoras()
        {
            if (DataHoraSaida is null)
                throw new ArgumentNullException("O veículo ainda não saiu do estacionamento.");

            TimeSpan total = DataHoraSaida.Value - DataHoraEntrada;
            MinutosTotais = (int)total.TotalMinutes;
        }

        public void CalcularValorAPagar(TabelaDePrecosEntity tabelaDePrecos)
        {
            if (MinutosTotais is null)
                throw new InvalidOperationException("Os minutos totais não foram calculados.");

            TabelaDePrecos = tabelaDePrecos;
            ValorPagar = tabelaDePrecos.CalcularPreco(MinutosTotais.Value);
        }
    }
}
