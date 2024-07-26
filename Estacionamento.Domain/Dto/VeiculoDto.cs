using Estacionamento.Domain.Entities;
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

        internal VeiculoEntity MapToEntity()
        {
            return new VeiculoEntity()
            {
                Id = this.Id,
                Placa = this.Placa,
                Modelo = this.Modelo,
                NomeProprietario = this.NomeProprietario
            };
        }
    }
}