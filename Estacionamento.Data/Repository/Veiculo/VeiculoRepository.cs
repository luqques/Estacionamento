﻿using AutoMapper;
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

        public async Task<VeiculoDto> AtualizarVeiculo(VeiculoDto veiculoDto)
        {
            VeiculoEntity veiculo = _mapper.Map<VeiculoEntity>(veiculoDto);

            _context.Veiculos.Update(veiculo);
            await _context.SaveChangesAsync();
            
            return _mapper.Map<VeiculoDto>(veiculo);
        }

        public async Task<bool> RemoverVeiculo(int id)
        {
            var veiculo = await _context.Veiculos.FindAsync(id);

            if (veiculo is null)
                return false;

            _context.Veiculos.Remove(veiculo);

            return (await _context.SaveChangesAsync()) == 1;
        }

        public async Task<bool> ExisteVeiculoPorPlaca(string placaVeiculo)
        {
            return await _context.Veiculos.AnyAsync(v => v.Placa == placaVeiculo);
        }

        public async Task<bool> ExisteVeiculoPorId(int id)
        {
            return await _context.Veiculos.AnyAsync(v => v.Id == id);
        }
    }
}
