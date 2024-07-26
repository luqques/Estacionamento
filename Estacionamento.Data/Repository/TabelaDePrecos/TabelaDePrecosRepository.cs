using AutoMapper;
using Estacionamento.Data.Context;
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

        public async Task<TabelaDePrecosEntity> ObterPrecoDaHora()
        {
            decimal precoHoraMinimo = 2m;

            var tabelaDePrecos = await _context.TabelaDePrecos
                .OrderByDescending(tp => tp.Id)
                .FirstOrDefaultAsync();

            return tabelaDePrecos ?? new TabelaDePrecosEntity(precoHoraMinimo);
        }
    }
}
