using Estacionamento.Data.VeiculoRepository;
using Estacionamento.Domain.Dto;
using Estacionamento.Domain.Entities;

namespace Estacionamento.Service.Services.Veiculo
{
    public class VeiculoService : IVeiculoService
    {
        private readonly IVeiculoRepository _veiculoRepository;

        public VeiculoService(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        public async Task<VeiculoEntity> CadastrarOuAtualizarVeiculo(VeiculoDto veiculoDto)
        {
            bool veiculoCadastrado = await ExisteVeiculoCadastrado(veiculoDto.Placa);

            if (veiculoCadastrado)
                return await _veiculoRepository.AtualizarVeiculo(veiculoDto);
                
            return await _veiculoRepository.CadastrarVeiculo(veiculoDto);
        }

        public async Task<bool> RemoverVeiculo(string placaVeiculo)
        {
            bool veiculoCadastrado = await ExisteVeiculoCadastrado(placaVeiculo);

            if (veiculoCadastrado)
                return await _veiculoRepository.RemoverVeiculo(placaVeiculo);

            return false;
        }

        private async Task<bool> ExisteVeiculoCadastrado(string placaVeiculo)
        {
            if (placaVeiculo is not null)
                return await _veiculoRepository.ExisteVeiculoPorPlaca(placaVeiculo);

            return false;
        }
    }
}
