using AutoMapper;
using Estacionamento.Data.Context;
using Estacionamento.Domain.Dto;
using Estacionamento.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Estacionamento.Data.Repository.Veiculo
{
    public class VeiculoRepository : IVeiculoRepository
    {
        private readonly MySqlContext _context;
        private IMapper _mapper;

        public VeiculoRepository(MySqlContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<VeiculoDto> CadastrarVeiculo(VeiculoDto veiculoDto)
        {
            Veiculo veiculo = _mapper.Map<Veiculo>(veiculoDto);

            _context.Veiculos.Add(veiculo);
            await _context.SaveChangesAsync();

            return _mapper.Map<Veiculo>(veiculo);
        }

        public Task<VeiculoDto> AtualizarVeiculo(VeiculoDto veiculoDto)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExisteVeiculoPorPlaca(string placaVeiculo)
        {
            return await _context.Veiculos.AnyAsync(v => v.Placa == placaVeiculo);
        }
    }
}
