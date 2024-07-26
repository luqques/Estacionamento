using Estacionamento.Domain.Dto;
using Estacionamento.Domain.Entities;

namespace Estacionamento.Data.Repository.TabelaDePrecos
{
    public interface ITabelaDePrecosRepository
    {
        Task<TabelaDePrecosEntity> InserirPrecoHora(TabelaDePrecosDto tabelaDePrecosDto);
        Task<TabelaDePrecosEntity> ObterPrecoHoraAtual();
    }
}
