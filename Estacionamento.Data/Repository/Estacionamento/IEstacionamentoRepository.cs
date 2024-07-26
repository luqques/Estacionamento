using Estacionamento.Domain.Dto;

namespace Estacionamento.Data.Repository.Estacionamento
{
    public interface IEstacionamentoRepository
    {
        Task<RegistroEstacionamentoDto> InserirEntradaVeiculo(RegistroEstacionamentoDto registroEstacionamento);
        Task<bool> RemoverVeiculoDoEstacionamento(int veiculoId);
        Task<IEnumerable<RegistroEstacionamentoDetalhadoDto>> ListarRegistrosEstacionamentoDetalhado();
    }
}
