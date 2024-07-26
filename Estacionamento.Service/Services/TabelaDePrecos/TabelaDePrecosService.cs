using Estacionamento.Data.Repository.TabelaDePrecos;
using Estacionamento.Domain.Dto;
using Estacionamento.Domain.Entities;

namespace Estacionamento.Service.Services.TabelaDePrecos
{
    public class TabelaDePrecosService : ITabelaDePrecosService
    {
        private readonly ITabelaDePrecosRepository _tabelaDePrecosRepository;

        public TabelaDePrecosService(ITabelaDePrecosRepository tabelaDePrecosRepository)
        {
            _tabelaDePrecosRepository = tabelaDePrecosRepository;
        }

        public async Task<TabelaDePrecosEntity> AlterarPrecoHora(decimal precoHora)
        {
            var tabelaPrecos = new TabelaDePrecosDto(precoHora);

            return await _tabelaDePrecosRepository.InserirPrecoHora(tabelaPrecos);
        }
    }
}
