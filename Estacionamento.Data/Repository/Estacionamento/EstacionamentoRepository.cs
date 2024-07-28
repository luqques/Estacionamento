using AutoMapper;
using Estacionamento.Data.Context;
using Estacionamento.Data.Repository.TabelaDePrecos;
using Estacionamento.Domain.Dto;
using Estacionamento.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

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

        public async Task<RegistroEstacionamentoEntity> InserirEntradaVeiculo(RegistroEstacionamentoDto registroDto)
        {
            registroDto.TabelaDePrecos = await _tabelaDePrecosRepository.ObterPrecoHoraAtual();

            var resgitro = _mapper.Map<RegistroEstacionamentoEntity>(registroDto);

            _context.RegistrosEstacionamento.Add(resgitro);
            await _context.SaveChangesAsync();

            return _mapper.Map<RegistroEstacionamentoEntity>(resgitro);
        }

        public async Task<bool> RemoverVeiculoDoEstacionamento(int veiculoId)
        {
            var registroEstacionamento = _context.RegistrosEstacionamento
                                                    .Where(v => v.VeiculoId == veiculoId)
                                                    .FirstOrDefault();

            if (registroEstacionamento is null)
                return false;

            TabelaDePrecosEntity tabelaDePrecos = await _tabelaDePrecosRepository.ObterTabelaDePrecos(registroEstacionamento.TabelaDePrecosId);

            registroEstacionamento.DataHoraSaida = DateTime.Now;
            registroEstacionamento.CalcularTotalDeHoras();
            registroEstacionamento.CalcularValorAPagar(tabelaDePrecos);

            _context.RegistrosEstacionamento.Update(registroEstacionamento);
            
            return (await _context.SaveChangesAsync()) == 1;
        }

        public async Task<IEnumerable<RegistroEstacionamentoDetalhadoDto>> ListarRegistrosEstacionamentoAtivosDetalhado()
        {
            var registros = from RegistroEstacionamento in _context.RegistrosEstacionamento
                            join Veiculo in _context.Veiculos on RegistroEstacionamento.VeiculoId equals Veiculo.Id
                            join TabelaDePrecos in _context.TabelaDePrecos on RegistroEstacionamento.TabelaDePrecosId equals TabelaDePrecos.Id
                            where RegistroEstacionamento.DataHoraSaida == null
                            select new RegistroEstacionamentoDetalhadoDto
                            {
                                Placa = Veiculo.Placa,
                                DataHoraEntrada = RegistroEstacionamento.DataHoraEntrada,
                                DataHoraSaida = RegistroEstacionamento.DataHoraSaida,
                                Duracao = RegistroEstacionamento.MinutosTotais,
                                TempoCobradoHoras = RegistroEstacionamento.MinutosTotais / 60,
                                PrecoHora = TabelaDePrecos.PrecoHora,
                                ValorPagar = RegistroEstacionamento.ValorPagar
                            };

            return await registros.ToListAsync().ConfigureAwait(false);
        }
    }
}
