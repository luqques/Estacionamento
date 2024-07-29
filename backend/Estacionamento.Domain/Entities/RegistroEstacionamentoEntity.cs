using System.ComponentModel.DataAnnotations;

namespace Estacionamento.Domain.Entities
{
    public class RegistroEstacionamentoEntity : BaseEntity
    {
        private VeiculoEntity _veiculoEntity;

        [Required]
        public VeiculoEntity Veiculo
        {
            get { return _veiculoEntity; }
            set
            {
                _veiculoEntity = value;
                VeiculoId = value.Id;
            }
        }

        [Required]
        public int VeiculoId { get; private set; }

        private TabelaDePrecosEntity _tabelaDePrecosEntity;

        [Required]
        public TabelaDePrecosEntity TabelaDePrecos
        {
            get { return _tabelaDePrecosEntity; }
            set 
            {
                _tabelaDePrecosEntity = value;
                TabelaDePrecosId = _tabelaDePrecosEntity.Id;
            }
        }

        [Required]
        public int TabelaDePrecosId { get; private set; }

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
