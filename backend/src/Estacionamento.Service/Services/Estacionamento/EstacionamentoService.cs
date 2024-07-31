using Estacionamento.Data.Repository.Estacionamento;
using Estacionamento.Data.Repository.TabelaDePrecos;
using Estacionamento.Data.VeiculoRepository;
using Estacionamento.Domain.Dto;
using Estacionamento.Domain.Entities;
using Estacionamento.Service.Services.Veiculo;

namespace Estacionamento.Service.Services.Estacionamento
{
    public class EstacionamentoService : IEstacionamentoService
    {
        private readonly IVeiculoService _veiculoService;
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IEstacionamentoRepository _estacionamentoRespository;
        private readonly ITabelaDePrecosRepository _tabelaDePrecosRepository;

        public EstacionamentoService(IVeiculoService veiculoService,
                                     IVeiculoRepository veiculoRepository,
                                     IEstacionamentoRepository estacionamentoRespository,
                                     ITabelaDePrecosRepository tabelaDePrecosRepository)
        {
            _veiculoService = veiculoService;
            _veiculoRepository = veiculoRepository;
            _estacionamentoRespository = estacionamentoRespository;
            _tabelaDePrecosRepository = tabelaDePrecosRepository;
        }

        public async Task<RegistroEstacionamentoEntity> RegistrarEntradaDeVeiculo(VeiculoDto veiculoDto)
        {
            ArgumentNullException.ThrowIfNull(veiculoDto);

            RegistroEstacionamentoDto registroEstacionamento = new();

            registroEstacionamento.Veiculo = await _veiculoService.CadastrarOuAtualizarVeiculo(veiculoDto);

            var registroAtivo = await _estacionamentoRespository.ObterRegistroAtivoPorPlaca(veiculoDto.Placa);

            if (registroAtivo is not null)
                throw new ArgumentException("Este veículo já está no estacionamento!");

            registroEstacionamento.TabelaDePrecos = await _tabelaDePrecosRepository.ObterTabelaDePrecosAtual();

            return await _estacionamentoRespository.InserirEntradaVeiculo(registroEstacionamento);
        }

        public async Task<IEnumerable<RegistroEstacionamentoDetalhadoDto>> ListarRegistrosAtivosDetalhado(bool registrosAtivos)
        {
            return await _estacionamentoRespository.ListarRegistrosEstacionamentoAtivosDetalhado(registrosAtivos);
        }

        public async Task<RegistroEstacionamentoDetalhadoDto> RegistrarSaidaDeVeiculo(string placa)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(nameof(placa));

            RegistroEstacionamentoEntity registroEstacionamento = await _estacionamentoRespository.ObterRegistroAtivoPorPlaca(placa);

            if (registroEstacionamento is null)
                throw new Exception($"O veículo de placa {placa} não está presente no estacionamento.");

            registroEstacionamento.TabelaDePrecos = await _tabelaDePrecosRepository.ObterTabelaDePrecosPorId(registroEstacionamento.TabelaDePrecosId);
            registroEstacionamento.Veiculo = await _veiculoRepository.ObterVeiculoPorId(registroEstacionamento.VeiculoId);
            
            registroEstacionamento.CalcularTotalDeHoras();
            registroEstacionamento.CalcularValorAPagar();

            registroEstacionamento = await _estacionamentoRespository.RemoverVeiculoDoEstacionamento(registroEstacionamento);

            return CriarRegistroDetalhado(registroEstacionamento);
        }

        private RegistroEstacionamentoDetalhadoDto CriarRegistroDetalhado(RegistroEstacionamentoEntity registroAtualizado)
        {
            return new RegistroEstacionamentoDetalhadoDto(registroAtualizado.Veiculo.Placa,
                                                          registroAtualizado.DataHoraEntrada,
                                                          registroAtualizado.DataHoraSaida,
                                                          registroAtualizado.Duracao,
                                                          registroAtualizado.Duracao.Value.TotalHours,
                                                          registroAtualizado.TabelaDePrecos.PrecoHora,
                                                          registroAtualizado.ValorPagar);
        }
    }
}
