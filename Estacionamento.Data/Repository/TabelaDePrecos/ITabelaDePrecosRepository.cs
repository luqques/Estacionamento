using Estacionamento.Domain.Entities;

namespace Estacionamento.Data.Repository.TabelaDePrecos
{
    public interface ITabelaDePrecosRepository
    {
        Task<TabelaDePrecosEntity> ObterPrecoDaHora();
    }
}
