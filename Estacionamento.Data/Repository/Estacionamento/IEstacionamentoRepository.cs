using Estacionamento.Domain.Dto;
using Estacionamento.Domain.Entities;

namespace Estacionamento.Data.Repository.Estacionamento
{
    public interface IEstacionamentoRepository
    {
        Task<RegistroEstacionamentoEntity> InserirEntradaVeiculo(RegistroEstacionamentoDto registroEstacionamento);
        Task<bool> RemoverVeiculoDoEstacionamento(int veiculoId);
        Task<IEnumerable<RegistroEstacionamentoDetalhadoDto>> ListarRegistrosEstacionamentoDetalhado();
    }
}
