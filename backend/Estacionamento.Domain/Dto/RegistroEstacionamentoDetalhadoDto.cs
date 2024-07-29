﻿using System.ComponentModel.DataAnnotations;

namespace Estacionamento.Domain.Dto
{
    public class RegistroEstacionamentoDetalhadoDto
    {
        public string Placa { get; set; }
        public DateTime DataHoraEntrada { get; set; }
        public DateTime? DataHoraSaida { get; set; }
        public int? Duracao { get; set; }
        public decimal? TempoCobradoHoras { get; set; }
        public decimal? PrecoHora { get; set; }
        public decimal? ValorPagar { get; set; }
    }
}