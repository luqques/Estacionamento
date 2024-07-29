using Estacionamento.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Estacionamento.Domain.Dto
{
    public class RegistroEstacionamentoDto
    {
        private VeiculoEntity _veiculoEntity;

        [Required]
        public VeiculoEntity Veiculo
        {
            get { return _veiculoEntity; }
            set
            {
                _veiculoEntity = value;
                VeiculoId = value.Id;
            }
        }

        [Required]
        public int VeiculoId { get; private set; }

        private TabelaDePrecosEntity _tabelaDePrecosEntity;

        [Required]
        public TabelaDePrecosEntity TabelaDePrecos
        {
            get { return _tabelaDePrecosEntity; }
            set
            {
                _tabelaDePrecosEntity = value;
                TabelaDePrecosId = value.Id;
            }
        }

        [Required]
        public int TabelaDePrecosId { get; private set; }

        [Required]
        public DateTime DataHoraEntrada { get; set; } = DateTime.Now;

        public void AdicionarVeiculo(VeiculoEntity veiculo)
        {
            Veiculo = veiculo;
        }
    }
}
