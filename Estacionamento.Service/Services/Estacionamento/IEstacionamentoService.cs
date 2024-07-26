using Estacionamento.Domain.Dto;

namespace Estacionamento.Service.Services.Estacionamento
{
    public interface IEstacionamentoService
    {
        Task<VeiculoDto> RegistrarEntradaDeVeiculo(VeiculoDto veiculoDto);
        Task<bool> RegistrarSaidaDeVeiculo(int veiculoId);
        Task<RegistroEstacionamentoDetalhadoDto> ListarRegistrosDetalhado();
    }
}
