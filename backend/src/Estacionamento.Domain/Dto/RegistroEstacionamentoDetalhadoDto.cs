using System.ComponentModel.DataAnnotations;

namespace Estacionamento.Domain.Dto
{
    public class RegistroEstacionamentoDetalhadoDto
    {
        public RegistroEstacionamentoDetalhadoDto(string placa, 
                                                DateTime dataHoraEntrada, 
                                                DateTime? dataHoraSaida, 
                                                TimeSpan? duracao, 
                                                double? tempoCobradoHoras, 
                                                decimal? precoHora, 
                                                decimal? valorPagar)
        {
            Placa = placa;
            DataHoraEntrada = dataHoraEntrada;
            DataHoraSaida = dataHoraSaida;
            Duracao = duracao;

            if (tempoCobradoHoras is not null)
                TempoCobradoHoras = (int)tempoCobradoHoras == 0 ? 1 : (int)tempoCobradoHoras;

            PrecoHora = precoHora;
            ValorPagar = valorPagar;
        }

        public string Placa { get; set; }
        public DateTime DataHoraEntrada { get; set; }
        public DateTime? DataHoraSaida { get; set; }
        public TimeSpan? Duracao { get; set; }
        public int? TempoCobradoHoras { get; set; }
        public decimal? PrecoHora { get; set; }
        public decimal? ValorPagar { get; set; }
    }
}
