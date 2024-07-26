using Estacionamento.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Estacionamento.Domain.Dto
{
    public class VeiculoDto
    {
        [Required]
        public string Placa { get; set; }
        
        public string NomeProprietario { get; set; }
        
        public string Modelo { get; set; }

        public VeiculoEntity MapToEntity()
        {
            return new VeiculoEntity()
            {
                Placa = this.Placa,
                Modelo = this.Modelo,
                NomeProprietario = this.NomeProprietario
            };
        }
    }
}