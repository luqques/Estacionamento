using Estacionamento.Domain.Dto;
using Estacionamento.Domain.Entities;

namespace Estacionamento.Service.Services.Estacionamento
{
    public interface IEstacionamentoService
    {
        Task<RegistroEstacionamentoEntity> RegistrarEntradaDeVeiculo(VeiculoDto veiculoDto);
        Task<RegistroEstacionamentoDetalhadoDto> RegistrarSaidaDeVeiculo(string placa);
        Task<IEnumerable<RegistroEstacionamentoDetalhadoDto>> ListarRegistrosAtivosDetalhado(bool registrosAtivos);
    }
}
