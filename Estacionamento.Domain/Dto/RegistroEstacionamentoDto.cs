using Estacionamento.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Estacionamento.Domain.Dto
{
    public class RegistroEstacionamentoDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public VeiculoEntity Veiculo { get; set; }

        [Required]
        public DateTime DataHoraEntrada { get; set; } = DateTime.Now;

        public DateTime? DataHoraSaida { get; set; }

        public decimal? ValorPagar { get; private set; }

        public int? MinutosTotais { get; private set; }

        public void AdicionarVeiculo(VeiculoDto veiculoDto)
        {
            Veiculo = veiculoDto.MapToEntity();
        }
    }
}
