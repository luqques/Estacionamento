using Estacionamento.Domain.Dto;
using Estacionamento.Domain.Entities;

namespace Estacionamento.Service.Services.TabelaDePrecos
{
    public interface ITabelaDePrecosService
    {
        Task<TabelaDePrecosEntity> AlterarPrecoHora(decimal precoHora);
    }
}
