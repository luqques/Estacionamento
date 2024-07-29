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
            try
            {
                bool veiculoCadastrado = await ExisteVeiculoCadastrado(id: null, veiculoDto.Placa);
                if (veiculoCadastrado)
                    return await _veiculoRepository.AtualizarVeiculo(veiculoDto);

                return await _veiculoRepository.CadastrarVeiculo(veiculoDto);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<bool> RemoverVeiculo(int id)
        {
            try
            {
                bool veiculoCadastrado = await ExisteVeiculoCadastrado(id, placaVeiculo: null);

                if (veiculoCadastrado)
                    return await _veiculoRepository.RemoverVeiculo(id);

                return false;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        private async Task<bool> ExisteVeiculoCadastrado(int? id, string? placaVeiculo)
        {
            if (id is not null)
                return await _veiculoRepository.ExisteVeiculoPorId(id ?? 0);

            if (placaVeiculo is not null)
                return await _veiculoRepository.ExisteVeiculoPorPlaca(placaVeiculo);

            return false;
        }
    }
}
