using Estacionamento.Domain.Dto;

namespace Estacionamento.Service.Services.Veiculo
{
    public interface IVeiculoService
    {
        public Task<VeiculoDto> CadastrarOuAtualizarVeiculo(VeiculoDto veiculoDto);

        public Task<bool> ExisteVeiculoCadastrado(string placaVeiculo);
    }
}
