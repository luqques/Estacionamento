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
        
        private decimal _precoHora;

        public decimal PrecoHora
        {
            get { return _precoHora; }
            set
            {
                _precoHora = value;
                PrecoHoraAdicional = value / 2m;
            }
        }

        public decimal PrecoHoraAdicional { get; private set; }

        [Required]
        public DateTime DataHoraCadastro { get; set; }
    }
}
