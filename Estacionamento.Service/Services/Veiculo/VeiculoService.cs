using Estacionamento.Data.Repository.Veiculo;
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
                if (!ExisteVeiculoCadastrado(veiculoDto.Placa))
                    return await _veiculoRepository.AtualizarVeiculo(veiculoDto);

                return await _veiculoRepository.CadastrarVeiculo(veiculoDto);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        private Task<bool> ExisteVeiculoCadastrado(string placaVeiculo)
        {
            return _veiculoRepository.ExisteVeiculoPorPlaca(placaVeiculo);
        }
    }
}
