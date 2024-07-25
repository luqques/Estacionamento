using Estacionamento.Data.Dto;
using Estacionamento.Domain.Dto;
using Estacionamento.Domain.Entities;

namespace Estacionamento.Service.Services.Estacionamento
{
    public interface IEstacionamentoService
    {
        Task<RegistroEstacionamentoDto> RegistrarEntradaDeVeiculo(VeiculoDto veiculoDto);
    }
}
