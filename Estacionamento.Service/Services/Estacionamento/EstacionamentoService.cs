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
            try
            {
                ArgumentNullException.ThrowIfNull(veiculoDto);

                var registroEstacionamento = new RegistroEstacionamentoDto();

                var veiculo = await _veiculoService.CadastrarOuAtualizarVeiculo(veiculoDto);

                registroEstacionamento.AdicionarVeiculo(veiculo);

                return await _estacionamentoRespository.InserirEntradaVeiculo(registroEstacionamento);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<RegistroEstacionamentoDetalhadoDto>> ListarRegistrosDetalhado()
        {
            try
            {
                return await _estacionamentoRespository.ListarRegistrosEstacionamentoDetalhado();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> RegistrarSaidaDeVeiculo(int veiculoId)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(veiculoId);

                return await _estacionamentoRespository.RemoverVeiculoDoEstacionamento(veiculoId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
