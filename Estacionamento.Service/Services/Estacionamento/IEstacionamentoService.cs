using Estacionamento.Domain.Dto;

namespace Estacionamento.Service.Services.Estacionamento
{
    public interface IEstacionamentoService
    {
        Task<RegistroEstacionamentoDto> RegistrarEntradaDeVeiculo(VeiculoDto veiculoDto);

        Task<bool> RegistrarSaidaDeVeiculo(int veiculoId);
    }
}
