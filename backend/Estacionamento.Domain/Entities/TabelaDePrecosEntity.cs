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

        public decimal CalcularPreco(int minutos)
        {
            decimal precoTotal = 0;
            int horasTotais = minutos / 60;
            int minutosAdicionais = minutos % 60;

            if (minutos <= 30)
            {
                precoTotal = PrecoHora / 2;
            }
            else
            {
                precoTotal = PrecoHora * horasTotais;

                if (minutosAdicionais > 10)
                    precoTotal += PrecoHoraAdicional;
            }

            return precoTotal;
        }
    }
}
