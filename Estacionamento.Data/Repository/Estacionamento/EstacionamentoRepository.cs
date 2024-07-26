using AutoMapper;
using Estacionamento.Data.Context;
using Estacionamento.Data.Repository.TabelaDePrecos;
using Estacionamento.Domain.Dto;
using Estacionamento.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Estacionamento.Data.Repository.Estacionamento
{
    public class EstacionamentoRepository : IEstacionamentoRepository
    {
        private readonly ITabelaDePrecosRepository _tabelaDePrecosRepository;
        private readonly MySqlContext _context;
        private IMapper _mapper;

        public EstacionamentoRepository(MySqlContext context, IMapper mapper, ITabelaDePrecosRepository tabelaDePrecosRepository)
        {
            _context = context;
            _mapper = mapper;
            _tabelaDePrecosRepository = tabelaDePrecosRepository;
        }

        public async Task<RegistroEstacionamentoDto> InserirEntradaVeiculo(RegistroEstacionamentoDto registroDto)
        {
            RegistroEstacionamentoEntity resgitro = _mapper.Map<RegistroEstacionamentoEntity>(registroDto);

            _context.RegistrosEstacionamento.Add(resgitro);
            await _context.SaveChangesAsync();

            return _mapper.Map<RegistroEstacionamentoDto>(resgitro);
        }

        public async Task<bool> RemoverVeiculoDoEstacionamento(int veiculoId)
        {
            TabelaDePrecosEntity tabelaPrecos = await _tabelaDePrecosRepository.ObterPrecoDaHora();

            var registroEstacionamento = await _context.RegistrosEstacionamento.FindAsync(veiculoId);

            if (registroEstacionamento is null)
                return false;

            registroEstacionamento.DataHoraSaida = DateTime.Now;
            registroEstacionamento.CalcularTotalDeHoras();
            registroEstacionamento.CalcularValorAPagar(tabelaPrecos);

            _context.RegistrosEstacionamento.Update(registroEstacionamento);
            
            return (await _context.SaveChangesAsync()) == 1;
        }

        public async Task<IEnumerable<RegistroEstacionamentoDetalhadoDto>> ListarRegistrosEstacionamentoDetalhado()
        {
            var tabelaPreco = await _tabelaDePrecosRepository.ObterPrecoDaHora();

            var registros = await _context.RegistrosEstacionamento
                .Select(r => new RegistroEstacionamentoDetalhadoDto
                {
                    Placa = r.Veiculo.Placa,
                    DataHoraEntrada = r.DataHoraEntrada,
                    DataHoraSaida = r.DataHoraSaida,
                    Duracao = (r.DataHoraSaida.HasValue ? (r.DataHoraSaida.Value - r.DataHoraEntrada).ToString(@"hh\:mm\:ss") : "N/A"),
                    TempoCobradoHoras = (r.MinutosTotais.HasValue ? (int)Math.Ceiling((decimal)r.MinutosTotais.Value / 60) : 0),
                    PrecoHora = tabelaPreco.PrecoHora,
                    ValorPagar = r.ValorPagar ?? 0
                })
                .ToListAsync();

            return registros;
        }
    }
}
