using Estacionamento.Data.Repository.Estacionamento;
using Estacionamento.Data.Repository.TabelaDePrecos;
using Estacionamento.Data.VeiculoRepository;
using Estacionamento.Domain.Dto;
using Estacionamento.Service.Services.Veiculo;

namespace Estacionamento.Service.Services.Estacionamento
{
    public class EstacionamentoService : IEstacionamentoService
    {
        private readonly IVeiculoService _veiculoService;
        private readonly IEstacionamentoRepository _estacionamentoRespository;
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly ITabelaDePrecosRepository _tabelaDePrecosRepository;

        public EstacionamentoService(IVeiculoService veiculoService, IEstacionamentoRepository estacionamentoRespository, IVeiculoRepository veiculoRepository)
        {
            _veiculoService = veiculoService;
            _estacionamentoRespository = estacionamentoRespository;
            _veiculoRepository = veiculoRepository;
        }

        public Task<RegistroEstacionamentoDto> RegistrarEntradaDeVeiculo(VeiculoDto veiculoDto)
        {
            ArgumentNullException.ThrowIfNull(veiculoDto);

            var veiculo = _veiculoService.CadastrarOuAtualizarVeiculo(veiculoDto);

            RegistroEstacionamentoDto registroEstacionamento = new();

            registroEstacionamento.Veiculo = veiculo;

            return _estacionamentoRespository.InserirEntradaVeiculo(registroEstacionamento);
        }

        public async Task<RegistroEstacionamentoDetalhadoDto> ListarRegistrosDetalhado()
        {
            var tabela = await _tabelaDePrecosRepository.ObterPrecoDaHora();

            return await _estacionamentoRespository.ListarRegistrosEstacionamentoDetalhado();
        }

        public Task<bool> RegistrarSaidaDeVeiculo(int veiculoId)
        {
            ArgumentNullException.ThrowIfNull(veiculoId);

            return _estacionamentoRespository.RemoverVeiculoDoEstacionamento(veiculoId);
        }
    }
}
