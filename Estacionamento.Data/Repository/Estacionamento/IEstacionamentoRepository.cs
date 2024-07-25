using Estacionamento.Domain.Dto;

namespace Estacionamento.Data.Repository.Estacionamento
{
    public interface IEstacionamentoRepository
    {
        Task<RegistroEstacionamentoDto> InserirEntradaVeiculo(RegistroEstacionamentoDto registroEstacionamento);
    }
}
