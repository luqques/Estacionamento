using System.ComponentModel.DataAnnotations;

namespace Estacionamento.Domain.Dto
{
    public class RegistroEstacionamentoDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int VeiculoId { get; set; }

        [Required]
        public DateTime DataHoraEntrada { get; set; }

        public DateTime? DataHoraSaida { get; set; }

        public decimal? ValorCobrado { get; set; }
    }
}
