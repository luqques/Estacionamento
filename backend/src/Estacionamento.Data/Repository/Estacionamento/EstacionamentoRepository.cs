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

        public async Task<RegistroEstacionamentoEntity> InserirEntradaVeiculo(RegistroEstacionamentoDto registroDto)
        {
            var resgitro = _mapper.Map<RegistroEstacionamentoEntity>(registroDto);

            _context.RegistrosEstacionamento.Add(resgitro);

            await _context.SaveChangesAsync();

            return _mapper.Map<RegistroEstacionamentoEntity>(resgitro);
        }

        public async Task<RegistroEstacionamentoEntity> RemoverVeiculoDoEstacionamento(RegistroEstacionamentoEntity registroEstacionamento)
        {
            _context.RegistrosEstacionamento.Update(registroEstacionamento);
            
            await _context.SaveChangesAsync();

            return registroEstacionamento;
        }

        public async Task<IEnumerable<RegistroEstacionamentoDetalhadoDto>> ListarRegistrosEstacionamentoAtivosDetalhado(bool registrosAtivos)
        {
            var registros = from RegistroEstacionamento in _context.RegistrosEstacionamento
                            join Veiculo in _context.Veiculos on RegistroEstacionamento.VeiculoId equals Veiculo.Id
                            join TabelaDePrecos in _context.TabelaDePrecos on RegistroEstacionamento.TabelaDePrecosId equals TabelaDePrecos.Id
                            where registrosAtivos == true ? (RegistroEstacionamento.DataHoraSaida == null) : (RegistroEstacionamento.DataHoraSaida != null)
                            select new RegistroEstacionamentoDetalhadoDto(Veiculo.Placa,
                                                                          RegistroEstacionamento.DataHoraEntrada,
                                                                          RegistroEstacionamento.DataHoraSaida,
                                                                          RegistroEstacionamento.Duracao,
                                                                          RegistroEstacionamento.Duracao.Value.TotalHours,
                                                                          TabelaDePrecos.PrecoHora,
                                                                          RegistroEstacionamento.ValorPagar);

            return await registros.ToListAsync();
        }

        public async Task<RegistroEstacionamentoEntity> ObterRegistroAtivo(string placa)
        {
            return await _context.RegistrosEstacionamento
                                    .Where(v => v.DataHoraSaida == null)
                                    .Where(v => v.Veiculo.Placa.Equals(placa))
                                    .FirstOrDefaultAsync();
        }
    }
}
