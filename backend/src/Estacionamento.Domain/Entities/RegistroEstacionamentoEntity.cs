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

        public TimeSpan? Duracao { get; private set; }

        public void CalcularTotalDeHoras()
        {
            DataHoraSaida = DateTime.Now;
            Duracao = DataHoraSaida.Value - DataHoraEntrada;
        }

        public void CalcularValorAPagar()
        {
            if (Duracao is null)
                throw new InvalidOperationException("Os minutos totais não foram calculados.");

            ValorPagar = TabelaDePrecos.CalcularPreco((int)Duracao.Value.TotalMinutes);
        }
    }
}
