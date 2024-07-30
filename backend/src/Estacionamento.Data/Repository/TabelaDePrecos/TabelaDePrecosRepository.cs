using AutoMapper;
using Estacionamento.Data.Context;
using Estacionamento.Domain.Dto;
using Estacionamento.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Estacionamento.Data.Repository.TabelaDePrecos
{
    public class TabelaDePrecosRepository : ITabelaDePrecosRepository
    {
        private readonly MySqlContext _context;
        private IMapper _mapper;

        public TabelaDePrecosRepository(MySqlContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TabelaDePrecosEntity> InserirPrecoHora(TabelaDePrecosDto tabelaDePrecosDto)
        {
            TabelaDePrecosEntity tabelaPrecos = _mapper.Map<TabelaDePrecosEntity>(tabelaDePrecosDto);

            _context.TabelaDePrecos.Add(tabelaPrecos);

            await _context.SaveChangesAsync();

            return tabelaPrecos;
        }

        public async Task<TabelaDePrecosEntity> ObterTabelaDePrecosAtual()
        {
            return await _context.TabelaDePrecos
                                .OrderByDescending(tp => tp.Id)
                                .FirstOrDefaultAsync();
        }

        public async Task<TabelaDePrecosEntity> ObterTabelaDePrecos(int id)
        {
            return await _context.TabelaDePrecos.FirstOrDefaultAsync(tp => tp.Id == id);
        }
    }
}
