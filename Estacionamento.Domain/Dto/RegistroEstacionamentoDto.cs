using Estacionamento.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Estacionamento.Domain.Dto
{
    public class RegistroEstacionamentoDto
    {
        [Required]
        public VeiculoEntity Veiculo { get; set; }

        [Required]
        public int VeiculoId { get; set; }

        [Required]
        public DateTime DataHoraEntrada { get; set; } = DateTime.Now;

        //public DateTime? DataHoraSaida { get; set; }

        //public decimal? ValorPagar { get; private set; }

        //public int? MinutosTotais { get; private set; }

        public void AdicionarVeiculo(VeiculoEntity veiculo)
        {
            Veiculo = veiculo;
        }
    }
}
