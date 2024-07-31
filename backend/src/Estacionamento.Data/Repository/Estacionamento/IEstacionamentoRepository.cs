using Estacionamento.Domain.Dto;
using Estacionamento.Domain.Entities;

namespace Estacionamento.Data.Repository.Estacionamento
{
    public interface IEstacionamentoRepository
    {
        Task<RegistroEstacionamentoEntity> InserirEntradaVeiculo(RegistroEstacionamentoDto registroEstacionamento);
        Task<RegistroEstacionamentoEntity> RemoverVeiculoDoEstacionamento(RegistroEstacionamentoEntity registroEstacionamento);
        Task<IEnumerable<RegistroEstacionamentoDetalhadoDto>> ListarRegistrosEstacionamentoAtivosDetalhado(bool registrosAtivos);
        Task<RegistroEstacionamentoEntity> ObterRegistroAtivo(string placa);
    }
}
