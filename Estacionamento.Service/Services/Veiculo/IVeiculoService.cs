using Estacionamento.Domain.Dto;
using Estacionamento.Domain.Entities;

namespace Estacionamento.Service.Services.Veiculo
{
    public interface IVeiculoService
    {
        Task<VeiculoEntity> CadastrarOuAtualizarVeiculo(VeiculoDto veiculoDto);

        Task<bool> RemoverVeiculo(int id);
    }
}
