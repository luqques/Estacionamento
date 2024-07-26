using System.ComponentModel.DataAnnotations;

namespace Estacionamento.Domain.Entities
{
    public class VeiculoEntity : BaseEntity
    {
        [Required]
        public string Placa { get; set; }

        public string? NomeProprietario { get; set; }

        public string? Modelo { get; set; }
    }
}
