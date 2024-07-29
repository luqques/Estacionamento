using System.ComponentModel.DataAnnotations;

namespace Estacionamento.Domain.Entities
{
    public class VeiculoEntity : BaseEntity
    {
        [Required]
        [StringLength(10, ErrorMessage = "A placa ultrapassou o limite de 10 caracteres.")]
        public string Placa { get; set; }

        public string NomeProprietario { get; set; }

        public string Modelo { get; set; }
    }
}
