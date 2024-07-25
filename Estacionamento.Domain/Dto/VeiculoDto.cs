using System.ComponentModel.DataAnnotations;

namespace Estacionamento.Domain.Dto
{
    public class VeiculoDto
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string Placa { get; set; }
        
        public string NomeProprietario { get; set; }
        
        public string Modelo { get; set; }
    }
}