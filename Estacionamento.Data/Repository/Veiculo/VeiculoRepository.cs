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

        public async Task<VeiculoDto> CadastrarVeiculo(VeiculoDto veiculoDto)
        {
            VeiculoEntity veiculo = _mapper.Map<VeiculoEntity>(veiculoDto);

            _context.Veiculos.Add(veiculo);
            await _context.SaveChangesAsync();

            return _mapper.Map<VeiculoDto>(veiculo);
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
