using AutoMapper;
using Estacionamento.Data.Context;
using Estacionamento.Data.Dto;
using Estacionamento.Domain.Entities;

namespace Estacionamento.Data.Repository.Estacionamento
{
    public class EstacionamentoRepository : IEstacionamentoRepository
    {
        private readonly MySqlContext _context;
        private IMapper _mapper;

        public EstacionamentoRepository(MySqlContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RegistroEstacionamentoDto> InserirEntradaVeiculo(RegistroEstacionamentoDto registroDto)
        {
            RegistroEstacionamento resgitro = _mapper.Map<RegistroEstacionamento>(registroDto);

            _context.RegistrosEstacionamento.Add(resgitro);
            await _context.SaveChangesAsync();

            return _mapper.Map<RegistroEstacionamentoDto>(resgitro);
        }
    }
}
