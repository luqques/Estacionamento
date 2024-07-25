using System.ComponentModel.DataAnnotations;

namespace Estacionamento.Domain.Entities
{
    public class RegistroEstacionamento : BaseEntity
    {
        [Required]
        public int VeiculoId { get; set; }

        [Required]
        public DateTime DataHoraEntrada { get; set; }
        
        public DateTime? DataHoraSaida { get; set; }
        
        public double? ValorCobrado { get; set; }
    }
}
