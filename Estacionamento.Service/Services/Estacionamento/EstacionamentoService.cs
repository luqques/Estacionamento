using Estacionamento.Data.Repository.Estacionamento;
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

        public EstacionamentoService(IVeiculoService veiculoService, IEstacionamentoRepository estacionamentoRespository, IVeiculoRepository veiculoRepository)
        {
            _veiculoService = veiculoService;
            _estacionamentoRespository = estacionamentoRespository;
            _veiculoRepository = veiculoRepository;
        }

        public Task<RegistroEstacionamentoDto> RegistrarEntradaDeVeiculo(VeiculoDto veiculoDto)
        {
            ArgumentNullException.ThrowIfNull(veiculoDto);

            _veiculoService.CadastrarOuAtualizarVeiculo(veiculoDto);

            RegistroEstacionamentoDto registroEstacionamento = new();

            return _estacionamentoRespository.InserirEntradaVeiculo(registroEstacionamento);
        }

        public Task<bool> RegistrarSaidaDeVeiculo(int veiculoId)
        {
            ArgumentNullException.ThrowIfNull(veiculoId);

            return _estacionamentoRespository.RemoverVeiculoDoEstacionamento(veiculoId);
        }
    }
}
