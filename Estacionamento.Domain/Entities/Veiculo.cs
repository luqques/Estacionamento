using System.ComponentModel.DataAnnotations;

namespace Estacionamento.Domain.Entities
{
    public class Veiculo : BaseEntity
    {
        [Required]
        public string Placa { get; set; }

        [Required]
        public string NomeProprietario { get; set; }

        [Required]
        public string Modelo { get; set; }
    }
}
