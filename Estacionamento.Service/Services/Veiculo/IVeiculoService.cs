using Estacionamento.Domain.Dto;

namespace Estacionamento.Service.Services.Veiculo
{
    public interface IVeiculoService
    {
        Task<VeiculoDto> CadastrarOuAtualizarVeiculo(VeiculoDto veiculoDto);

        Task<bool> ExisteVeiculoCadastrado(string placaVeiculo);
    }
}
