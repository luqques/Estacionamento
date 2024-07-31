using Estacionamento.Data.Repository.Estacionamento;
using Estacionamento.Data.Repository.TabelaDePrecos;
using Estacionamento.Domain.Dto;
using Estacionamento.Domain.Entities;
using Estacionamento.Service.Services.Veiculo;

namespace Estacionamento.Service.Services.Estacionamento
{
    public class EstacionamentoService : IEstacionamentoService
    {
        private readonly IVeiculoService _veiculoService;
        private readonly IEstacionamentoRepository _estacionamentoRespository;
        private readonly ITabelaDePrecosRepository _tabelaDePrecosRepository;

        public EstacionamentoService(IVeiculoService veiculoService, 
                                     IEstacionamentoRepository estacionamentoRespository,
                                     ITabelaDePrecosRepository tabelaDePrecosRepository)
        {
            _veiculoService = veiculoService;
            _estacionamentoRespository = estacionamentoRespository;
            _tabelaDePrecosRepository = tabelaDePrecosRepository;
        }

        public async Task<RegistroEstacionamentoEntity> RegistrarEntradaDeVeiculo(VeiculoDto veiculoDto)
        {
            ArgumentNullException.ThrowIfNull(veiculoDto);

            RegistroEstacionamentoDto registroEstacionamento = new();

            registroEstacionamento.Veiculo = await _veiculoService.CadastrarOuAtualizarVeiculo(veiculoDto);

            var registroAtivo = await _estacionamentoRespository.ObterRegistroAtivo(veiculoDto.Placa);

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

            RegistroEstacionamentoEntity registroEstacionamento = await _estacionamentoRespository.ObterRegistroAtivo(placa);

            if (registroEstacionamento is null)
                throw new Exception($"O veículo de placa {placa} não está presente no estacionamento.");

            TabelaDePrecosEntity tabelaDePrecos = await _tabelaDePrecosRepository.ObterTabelaDePrecos(registroEstacionamento.TabelaDePrecosId);

            registroEstacionamento.DataHoraSaida = DateTime.Now;

            registroEstacionamento.CalcularTotalDeHoras();

            registroEstacionamento.CalcularValorAPagar(tabelaDePrecos);

            RegistroEstacionamentoEntity registroAtualizado = await _estacionamentoRespository.RemoverVeiculoDoEstacionamento(registroEstacionamento);

            RegistroEstacionamentoDetalhadoDto registroDetalhado = CriarRegistroDetalhado(registroAtualizado);

            return registroDetalhado;
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
