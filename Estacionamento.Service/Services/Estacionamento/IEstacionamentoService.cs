using Estacionamento.Domain.Dto;
using Estacionamento.Domain.Entities;

namespace Estacionamento.Service.Services.Estacionamento
{
    public interface IEstacionamentoService
    {
        Task<RegistroEstacionamentoEntity> RegistrarEntradaDeVeiculo(VeiculoDto veiculoDto);
        Task<bool> RegistrarSaidaDeVeiculo(int veiculoId);
        Task<IEnumerable<RegistroEstacionamentoDetalhadoDto>> ListarRegistrosDetalhado();
    }
}
