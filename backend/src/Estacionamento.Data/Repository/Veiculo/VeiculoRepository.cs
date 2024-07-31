using AutoMapper;
using Estacionamento.Data.Context;
using Estacionamento.Domain.Dto;
using Estacionamento.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Estacionamento.Data.VeiculoRepository
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

        public async Task<VeiculoEntity> CadastrarVeiculo(VeiculoDto veiculoDto)
        {
            VeiculoEntity veiculo = _mapper.Map<VeiculoEntity>(veiculoDto);

            _context.Veiculos.Add(veiculo);
            await _context.SaveChangesAsync();

            return _mapper.Map<VeiculoEntity>(veiculo);
        }

        public async Task<VeiculoEntity> AtualizarVeiculo(VeiculoDto veiculoDto)
        {
            VeiculoEntity veiculo = _context.Veiculos
                .Where(v => v.Placa == veiculoDto.Placa)
                .FirstOrDefault();

            _context.Veiculos.Update(veiculo);

            await _context.SaveChangesAsync();
            
            return _mapper.Map<VeiculoEntity>(veiculo);
        }

        public async Task<bool> RemoverVeiculo(string placaVeiculo)
        {
            var veiculo = await _context.Veiculos
                .Where(v => v.Placa.Equals(placaVeiculo))
                .FirstOrDefaultAsync();

            if (veiculo is null)
                return false;

            _context.Veiculos.Remove(veiculo);

            return (await _context.SaveChangesAsync()) == 1;
        }

        public async Task<bool> ExisteVeiculoPorPlaca(string placaVeiculo)
        {
            return await _context.Veiculos.AnyAsync(v => v.Placa == placaVeiculo);
        }
    }
}
