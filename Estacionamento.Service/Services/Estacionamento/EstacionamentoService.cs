using Estacionamento.Data.Repository.Estacionamento;
using Estacionamento.Domain.Dto;
using Estacionamento.Domain.Entities;
using Estacionamento.Service.Services.Veiculo;

namespace Estacionamento.Service.Services.Estacionamento
{
    public class EstacionamentoService : IEstacionamentoService
    {
        private readonly IVeiculoService _veiculoService;
        private readonly IEstacionamentoRepository _estacionamentoRespository;

        public EstacionamentoService(IVeiculoService veiculoService, IEstacionamentoRepository estacionamentoRespository)
        {
            _veiculoService = veiculoService;
            _estacionamentoRespository = estacionamentoRespository;
        }

        public async Task<RegistroEstacionamentoEntity> RegistrarEntradaDeVeiculo(VeiculoDto veiculoDto)
        {
            ArgumentNullException.ThrowIfNull(veiculoDto);

            var veiculo = await _veiculoService.CadastrarOuAtualizarVeiculo(veiculoDto);

            var registroEstacionamento = new RegistroEstacionamentoDto();

            registroEstacionamento.AdicionarVeiculo(veiculo);

            return await _estacionamentoRespository.InserirEntradaVeiculo(registroEstacionamento);
        }

        public async Task<IEnumerable<RegistroEstacionamentoDetalhadoDto>> ListarRegistrosDetalhado()
        {
            return await _estacionamentoRespository.ListarRegistrosEstacionamentoDetalhado();
        }

        public async Task<bool> RegistrarSaidaDeVeiculo(int veiculoId)
        {
            ArgumentNullException.ThrowIfNull(veiculoId);

            return await _estacionamentoRespository.RemoverVeiculoDoEstacionamento(veiculoId);
        }
    }
}
