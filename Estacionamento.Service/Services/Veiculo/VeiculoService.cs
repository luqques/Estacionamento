using Estacionamento.Data.VeiculoRepository;
using Estacionamento.Domain.Dto;

namespace Estacionamento.Service.Services.Veiculo
{
    public class VeiculoService : IVeiculoService
    {
        private readonly IVeiculoRepository _veiculoRepository;

        public VeiculoService(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        public async Task<VeiculoDto> CadastrarOuAtualizarVeiculo(VeiculoDto veiculoDto)
        {
            try
            {
                bool veiculoCadastrado = await ExisteVeiculoCadastrado(veiculoDto.Placa);
                if (veiculoCadastrado)
                    return await _veiculoRepository.AtualizarVeiculo(veiculoDto);

                return await _veiculoRepository.CadastrarVeiculo(veiculoDto);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<bool> ExisteVeiculoCadastrado(string placaVeiculo)
        {
            return await _veiculoRepository.ExisteVeiculoPorPlaca(placaVeiculo);
        }
    }
}
