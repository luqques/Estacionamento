using Estacionamento.Domain.Dto;
using Estacionamento.Domain.Entities;

namespace Estacionamento.Data.VeiculoRepository
{
    public interface IVeiculoRepository
    {
        Task<VeiculoEntity> CadastrarVeiculo(VeiculoDto veiculoDto);

        Task<bool> ExisteVeiculoPorPlaca(string placaVeiculo);

        Task<VeiculoEntity> AtualizarVeiculo(VeiculoDto veiculoDto);

        Task<bool> ExisteVeiculoPorId(int id);

        Task<bool> RemoverVeiculo(int id);
    }
}
