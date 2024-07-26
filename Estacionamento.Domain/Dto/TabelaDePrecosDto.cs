using System.ComponentModel.DataAnnotations;

namespace Estacionamento.Domain.Dto
{
    public class TabelaDePrecosDto
    {
        public TabelaDePrecosDto(decimal precoHora)
        {
            PrecoHora = precoHora;
            DataHoraCadastro = DateTime.Now;
        }

        [Required]
        public decimal PrecoHora { get; set; }

        [Required]
        public DateTime DataHoraCadastro { get; set; }
    }
}
