using System.ComponentModel.DataAnnotations;

namespace Estacionamento.Domain.Entities
{
    public class TabelaDePrecosEntity : BaseEntity
    {
        public TabelaDePrecosEntity(decimal precoHora)
        {
            PrecoHora = precoHora;
            DataHoraCadastro = DateTime.Now;
        }

        [Required]
        public decimal PrecoHora { get; set; }

        [Required]
        public DateTime DataHoraCadastro { get; set; }

        public decimal CalcularPreco(int minutos)
        {
            if (minutos <= 0)
                return 0;

            decimal horasCompletas = minutos / 60m;
            int minutosRestantes = minutos % 60;
            
            decimal precoFinal = 0m;
            if (minutos <= 30)
            {
                precoFinal = PrecoHora / 2;
            }
            else
            {
                precoFinal = horasCompletas * PrecoHora;

                if (minutosRestantes > 10)
                {
                    precoFinal += PrecoHora;
                }
            }

            return precoFinal;
        }
    }
}
